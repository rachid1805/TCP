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
    private readonly MessagesContainer _messagesContainer;

    #region Contsructor

    public ServerManager(string hostNameOrAddress, int port)
    {
      _clients = new List<ClientController>();
      _usersManager = new UsersManager();
      _roomsContainer = new RoomsContainer();
      _messagesContainer = new MessagesContainer();

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
      _clients.Add(clientController);
      UpdateConsole("Opened.", clientController.IP, clientController.Port);
    }

    private void CommandReceived(object sender, CommandEventArgs e)
    {
      // An incoming command needs to be processed.

      var clientController = (ClientController)sender;
      switch (e.Command.CommandType)
      {
        case CommandType.ClientSignUp:
          SignUp(clientController, (ProfileContainer)e.Command.Data);
          break;

        case CommandType.ClientLogIn:
          Login(clientController, (ProfileContainer)e.Command.Data);
          break;

        case CommandType.ClientLogOff:
          Logoff((ProfileContainer)e.Command.Data);
          break;

        case CommandType.RequestClientList:
          SendCommandToClient(sender, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
          break;

        case CommandType.CreateRoom:
          CreateRoom(clientController, (RoomContainer)e.Command.Data);
          break;

        case CommandType.ConnectToRoom:
          ConnectToRoom(clientController, (RoomUsersContainer)e.Command.Data);
          break;

        case CommandType.RequestRoomList:
          SendCommandToAllClients(sender, new CommandContainer(CommandType.RoomList, _roomsContainer));
          break;

        case CommandType.UserDisconnectedFromRoom:
          DisconnectFromRoom(clientController, (RoomUsersContainer)e.Command.Data);
          break;

        case CommandType.RequestRoomArchive:
          SendRoomArchive(clientController, (RoomContainer)e.Command.Data);
          break;

        case CommandType.Message:
          ReceiveMessage(clientController, (MessageContainer)e.Command.Data);
          break;

        case CommandType.RemoveMessage:
          RemoveMessage(clientController, (MessageContainer)e.Command.Data);
          break;

        case CommandType.LikeMessage:
          LikeMessage(clientController, (MessageContainer)e.Command.Data);
          break;

        case CommandType.RequestUserProfile:
          RequestUserProfile(clientController, (ProfileContainer)e.Command.Data);
          break;
      }
    }

    private void ClientDisconnected(object sender, ClientEventArgs e)
    {
      RemoveClientManager(e.IP, e.Port);
    }

    private bool RemoveClientManager(IPAddress ip, int port)
    {
      lock (this)
      {
        int index = IndexOfClient(ip, port);
        if (index != -1)
        {
          string name = _clients[index].ClientName;
          var alreadyConnected = _clients[index].InLine;
          _clients.RemoveAt(index);
          UpdateConsole("Closed.", ip, port);

          if (alreadyConnected)
          {
            // Inform all connected clients that a client had been disconnected.
            _usersManager.UpdateUserStatus(name, false);
            _roomsContainer.RemoveUser(name);
            SendCommandToAllClients(this, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
            SendCommandToAllClients(this, new CommandContainer(CommandType.RoomList, _roomsContainer));
            return true;
          }
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
      var castSender = (ClientController)sender;
      foreach (ClientController client in _clients)
      {
        if (client.IP.Equals(castSender.IP) && client.Port.Equals(castSender.Port))
        {
          client.SendCommand(command);
          return;
        }
      }
    }

    private void SendCommandToAllClients(object sender, CommandContainer command)
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

    private void SignUp(ClientController clientController, ProfileContainer newProfile)
    {
      var registrationStatus = _usersManager.RegisterNewUser(newProfile);
      if (registrationStatus == RegistrationStatus.Successful)
      {
        Console.WriteLine("New registred client {0}", newProfile.UserName);
        _clients[IndexOfClient(clientController.IP, clientController.Port)].InLine = true;
        SendCommandToClient(clientController, new CommandContainer(CommandType.ValidCredentials, null));
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.RoomList, _roomsContainer));
      }
      else
      {
        Console.WriteLine("Already registred client {0}", newProfile.UserName);
        SendCommandToClient(clientController, new CommandContainer(CommandType.UserAlreadyExists, null));
      }
    }

    private void Login(ClientController clientController, ProfileContainer profile)
    {
      if (_usersManager.IsRegistredUser(profile.UserName, profile.Password))
      {
        if (!_usersManager.IsConnectedUser(profile.UserName))
        {
          _usersManager.UpdateUserStatus(profile.UserName, true);
          _clients[IndexOfClient(clientController.IP, clientController.Port)].InLine = true;
          Console.WriteLine("Client {0} has been connected", profile.UserName);
          SendCommandToClient(clientController, new CommandContainer(CommandType.ValidCredentials, null));
          SendCommandToAllClients(clientController, new CommandContainer(CommandType.UsersConnectionStatus, new UsersStatusContainer(_usersManager.RegistredUsers.ClientsStatus)));
          SendCommandToAllClients(clientController, new CommandContainer(CommandType.RoomList, _roomsContainer));
          _usersManager.GetUserProfile(profile.UserName).LastConnected = DateTime.Now;
         
        }
        else
        {
          Console.WriteLine("Already connected client {0}", profile.UserName);
          SendCommandToClient(clientController, new CommandContainer(CommandType.UserAlreadyConnected, null));
        }
      }
      else
      {
        Console.WriteLine("Connection of client {0} refused", profile.UserName);
        SendCommandToClient(clientController, new CommandContainer(CommandType.InvalidCredentials, null));
      }
    }

    private void Logoff(ProfileContainer profile)
    {
      if (_usersManager.IsRegistredUser(profile.UserName, profile.Password))
      {
        if (_usersManager.IsConnectedUser(profile.UserName))
        {
          Console.WriteLine("Client {0} has been disconnected", profile.UserName);
        }
        else
        {
          Console.WriteLine("Client {0} has not been connected before", profile.UserName);
        }
      }
      else
      {
        Console.WriteLine("Disonnection of client {0} refused", profile.UserName);
      }
    }

    private void CreateRoom(ClientController clientController, RoomContainer newRoom)
    {
      var newRoomUsers = new RoomUsersContainer(newRoom);
      if (!_roomsContainer.RoomExist(newRoomUsers))
      {
        _roomsContainer.AddRoom(newRoomUsers);
        _messagesContainer.AddRoomArchive(new RoomArchiveContainer(newRoom));
        Console.WriteLine("New room created {0}", newRoomUsers.GetRoom().Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomCreated, null));
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.RoomList, _roomsContainer));
      }
      else
      {
        Console.WriteLine("Room {0} already exists", newRoomUsers.GetRoom().Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomAlreadyExists, null));
      }
    }

    private void ConnectToRoom(ClientController clientController, RoomUsersContainer roomConnect)
    {
      if (_roomsContainer.RoomExist(roomConnect))
      {
        _roomsContainer.AddUsers(roomConnect);
        foreach (string user in roomConnect.GetRoomUsersList())
        {
          Console.WriteLine("User {0} added to room {1}", user, roomConnect.GetRoom().Name);
        }
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.RoomList, _roomsContainer));
      }
      else
      {
        Console.WriteLine("Room {0} does not exists", roomConnect.GetRoom().Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomDoesNotExists, null));
      }
    }

    private void DisconnectFromRoom(ClientController clientController, RoomUsersContainer roomDisconnect)
    {
      if (_roomsContainer.RoomExist(roomDisconnect))
      {
        _roomsContainer.RemoveUserFromRoom(roomDisconnect);
        foreach (string user in roomDisconnect.GetRoomUsersList())
        {
          Console.WriteLine("User {0} disconnect from room {1}", user, roomDisconnect.GetRoom().Name);
        }
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.RoomList, _roomsContainer));
      }
      else
      {
        Console.WriteLine("Room {0} does not exists", roomDisconnect.GetRoom().Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomDoesNotExists, null));
      }
    }

    private void SendRoomArchive(ClientController clientController, RoomContainer roomRequestHistory)
    {
      var roomArchive = _messagesContainer.GetRoomArchive(roomRequestHistory);

      if (roomArchive != null)
      {
        Console.WriteLine("Room archive sent to room {0} ", roomRequestHistory.Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomArchive, roomArchive));
      }
      else
      {
        Console.WriteLine("Room {0} does not exists", roomRequestHistory.Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomDoesNotExists, null));
      }
    }

    private void ReceiveMessage(ClientController clientController, MessageContainer message)
    {
      if (_messagesContainer.AddNewMessage(message))
      {
        Console.WriteLine("Message sent to room {0}", message.Room.Name);
        foreach (RoomUsersContainer roomUser in _roomsContainer.GetAllRooms())
        {
          if (roomUser.GetRoom().Name.Equals(message.Room.Name))
          {
            foreach (string user in roomUser.GetRoomUsersList())
            {
              foreach (ClientController client in _clients)
              {
                if (client.ClientName.Equals(user)) //user is is message room
                {
                  if (!client.ClientName.Equals(message.User)) //don't send to user that created the message
                  {
                    SendCommandToClient(client, new CommandContainer(CommandType.Message, message));
                  }
                }
              }
            }
          }
        }
      }
      else
      {
        Console.WriteLine("Room {0} does not exists", message.Room.Name);
        SendCommandToClient(clientController, new CommandContainer(CommandType.RoomDoesNotExists, null));
      }
    }

    private void RemoveMessage(ClientController clientController, MessageContainer message)
    {
      if (_messagesContainer.RemoveMessage(message))
      {
        Console.WriteLine("Removed {0} message from room {1}", message.User, message.Room.Name);
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.RemoveMessage, new MessageContainer(message)));
      }
      else
      {
        Console.WriteLine("Can't remove {0} message from room {1}", message.User, message.Room.Name);
      }
    }

    private void LikeMessage(ClientController clientController, MessageContainer message)
    {
      if (_messagesContainer.LikeMessage(message))
      {
        Console.WriteLine("Liked {0} message from room {1}", message.User, message.Room.Name);
        SendCommandToAllClients(clientController, new CommandContainer(CommandType.LikeMessage, new MessageContainer(message)));
      }
      else
      {
        Console.WriteLine("Can't like {0} message from room {1}", message.User, message.Room.Name);
      }
    }

    private void RequestUserProfile(ClientController clientController, ProfileContainer profile)
    {
      if (_usersManager.IsRegistredUser(profile.UserName, profile.Password))
      {
        if (_usersManager.IsConnectedUser(profile.UserName))
        {
          ProfileContainer userProfile = _usersManager.GetUserProfile(profile.UserName);
          Console.WriteLine("Profile for user {0} has been found", userProfile.UserName);
          SendCommandToClient(clientController, new CommandContainer(CommandType.UserProfile, userProfile));      
        }    
      }
      else
      {
        Console.WriteLine("Profile {0} does not exist ", profile.UserName);
        //SendCommandToClient(clientController, new CommandContainer(CommandType.InvalidCredentials, null));
      }
    }

    #endregion
  }
}
