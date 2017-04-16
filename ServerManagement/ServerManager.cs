using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Common;
using System.ComponentModel;

namespace ServerManagement
{
  public class ServerManager
  {
    private readonly IList<ClientController> _clients;
    private readonly IPEndPoint _localEndPoint;
    private readonly IUsersManager _usersManager;
    private Socket _listenerSocket;
    private readonly RoomsContainer _roomsContainer;

    #region Contsructor

    public ServerManager(string hostNameOrAddress, int port)
    {
      _clients = new List<ClientController>();
      _usersManager = new UsersManager();
      _roomsContainer = new RoomsContainer();

      // Establish the local endpoint for the socket
      IPHostEntry ipHostEntry = Dns.GetHostEntry(hostNameOrAddress);
      IPAddress[] ipv4Addresses = Array.FindAll(ipHostEntry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
      _localEndPoint = new IPEndPoint(ipv4Addresses[0], port);
    }

    #endregion

    #region Public

    public IPAddress Ip
    {
      get { return (_localEndPoint != null) ? _localEndPoint.Address : IPAddress.None; }
    }

    public int Port
    {
      get { return (_localEndPoint != null) ? _localEndPoint.Port : 0; }
    }

    public void StartListening(object sender, DoWorkEventArgs e)
    {
      // Bind the socket to the local endpoint and listen for incoming connections.
      try
      {
        // Create a TCP/IP socket.  
        _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        _listenerSocket.Bind(_localEndPoint);
        _listenerSocket.Listen(200);

        // Start listening for connections.  
        while (true)
        {
          // Program is suspended while waiting for an incoming connection.  
          CreateNewClientManager(_listenerSocket.Accept());
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }

      Console.WriteLine("\nPress ENTER to continue...");
      Console.Read();
    }

    public void Close()
    {
      foreach (ClientController client in _clients)
      {
        client.Disconnect();
      }

      if (_listenerSocket != null)
      {
        _listenerSocket.Close();
      }
    }

    #endregion

    #region Private

    private void CreateNewClientManager(Socket socket)
    {
      ClientController clientController = new ClientController(socket);
      clientController.CommandReceived += new CommandReceivedEventHandler(CommandReceived);
      clientController.DisconnectedClient += new ClientDisconnectedEventHandler(ClientDisconnected);
      //CheckForAbnormalDisconnection(clientController);
      _clients.Add(clientController);
      UpdateConsole("Opened.", clientController.IP, clientController.Port);
    }

    private void CommandReceived(object sender, CommandEventArgs e)
    {
      // An incoming command needs to be processed.

      switch (e.Command.CommandType)
      {
        case CommandType.ClientSignUp:
          var newProfile = (ProfileContainer)e.Command.Data;
          var registrationStatus = _usersManager.RegisterNewUser(newProfile);
          if (registrationStatus == RegistrationStatus.Successful)
          {
            Console.WriteLine("New registred client {0}", newProfile.UserName);
            SendCommandToClient(sender, new CommandContainer(CommandType.ValidCredentials, null));
            SendCommandToAllClient(sender, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
          }
          else
          {
            Console.WriteLine("Already registred client {0}", newProfile.UserName);
            SendCommandToClient(sender, new CommandContainer(CommandType.UserAlreadyExists, null));
          }
          break;
        case CommandType.ClientLogIn:
          var profile = (ProfileContainer)e.Command.Data;
          if (_usersManager.IsRegistredUser(profile.UserName, profile.Password))
          {
            _usersManager.UpdateUserStatus(profile.UserName, true);
            Console.WriteLine("New connected client {0}", profile.UserName);
            SendCommandToClient(sender, new CommandContainer(CommandType.ValidCredentials, null));
            SendCommandToAllClient(sender, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
          }
          else
          {
            Console.WriteLine("Connection of client {0} refused", profile.UserName);
            SendCommandToClient(sender, new CommandContainer(CommandType.InvalidCredentials, null));
          }
          break;
        case CommandType.RequestClientList:
          SendCommandToClient(sender, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
          break;
        case CommandType.CreateRoom:
          var newRoom = (RoomContainer)e.Command.Data;
          var newRoomUsers = new RoomUsersContainer(newRoom);  //wrap room in a RoomUsersContainer object. List of users is empty
          if (!_roomsContainer.RoomExist(newRoomUsers))         //if room does not exist
          {
            _roomsContainer.AddRoom(newRoomUsers);
            Console.WriteLine("New room created {0}", newRoomUsers.GetRoom().Name);
            SendCommandToClient(sender, new CommandContainer(CommandType.RoomCreated, null));
            SendCommandToAllClient(sender, new CommandContainer(CommandType.RoomList, _roomsContainer));
          }
          else
          {
            Console.WriteLine("Room {0} already exists", newRoomUsers.GetRoom().Name);
            SendCommandToClient(sender, new CommandContainer(CommandType.RoomAlreadyExists, null));
          }
          break;
        case CommandType.ConnectToRoom:
          var roomConnect = (RoomUsersContainer)e.Command.Data;  //receives a roomUsersContainer (room + user list)
          if (_roomsContainer.RoomExist(roomConnect))            //if room exists
          {
            _roomsContainer.AddUsers(roomConnect);
            foreach (string user in roomConnect.GetRoomUsersList())
            {
              Console.WriteLine("User {0} added to room {1}", user, roomConnect.GetRoom().Name);
            }
            SendCommandToClient(sender, new CommandContainer(CommandType.UserConnectedToRoom, null));
            SendCommandToAllClient(sender, new CommandContainer(CommandType.RoomList, _roomsContainer));
          }
          else
          {
            Console.WriteLine("Room {0} does not exists", roomConnect.GetRoom().Name);
            SendCommandToClient(sender, new CommandContainer(CommandType.RoomDoesNotExists, null));
          }
          break;
        case CommandType.RequestRoomList:
          SendCommandToAllClient(sender, new CommandContainer(CommandType.RoomList, _roomsContainer));
          break;
      }
    }

    private void ClientDisconnected(object sender, ClientEventArgs e)
    {
      if (RemoveClientManager(e.IP, e.Port))
      {
        UpdateConsole("Closed.", e.IP, e.Port);
      }
    }

    private void CheckForAbnormalDisconnection(ClientController client)
    {
      if (RemoveClientManager(client.IP, client.Port))
      {
        UpdateConsole("Closed.", client.IP, client.Port);
      }
    }

    private bool RemoveClientManager(IPAddress ip, int port)
    {
      lock (this)
      {
        int index = IndexOfClient(ip, port);
        if (index != -1)
        {
          string name = _clients[index].ClientName;
          _clients.RemoveAt(index);

          // Inform all connected clients that a client had been disconnected.
          _usersManager.UpdateUserStatus(name, false);
          SendCommandToAllClient(this, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));

          return true;
        }
        return false;
      }
    }

    private int IndexOfClient(IPAddress ip, int port)
    {
      int index = -1;
      foreach (ClientController client in _clients)
      {
        index++;
        if (client.IP.Equals(ip) && client.Port.Equals(port))
        {
          return index;
        }
      }
      return -1;
    }

    private void SendCommandToClient(object sender, CommandContainer command)
    {
      foreach (ClientController client in _clients)
      {
        if (client.ClientName.Equals(((ClientController)sender).ClientName))
        {
          client.SendCommand(command);
          return;
        }
      }
    }

    private void SendCommandToAllClient(object sender, CommandContainer command)
    {
      foreach (ClientController client in _clients)
      {
        client.SendCommand(command);
      }
    }

    private void UpdateConsole(string status, IPAddress IP, int port)
    {
      Console.WriteLine("Channel {0}{1}{2} has been {3} ( {4}|{5} )", IP.ToString(), ":", port.ToString(), status,
        DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
    }

    #endregion
  }
}
