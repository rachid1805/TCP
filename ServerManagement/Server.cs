using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Common;
using System.ComponentModel;

namespace ServerManagement
{
  public class Server
  {
    private readonly IDictionary<string, ProfileContainer> _members;
    private readonly ConnectionManager _connectionManager;
    private readonly IPEndPoint _localEndPoint;
    private Socket _listenerSocket;

    #region Contsructor

    public Server(string hostNameOrAddress, int port)
    {
      _members = new Dictionary<string, ProfileContainer>();
      _connectionManager = new ConnectionManager((int)Definitions.SYNCHRONIZATION_TIME);

      // Establish the local endpoint for the socket
      IPHostEntry ipHostEntry = Dns.GetHostEntry(hostNameOrAddress);
      IPAddress[] ipv4Addresses = Array.FindAll(ipHostEntry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
      _localEndPoint = new IPEndPoint(ipv4Addresses[0], port);
    }

    #endregion

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
      // Data buffer for incoming data.  
      byte[] bytes = new Byte[1024];

      // Bind the socket to the local endpoint and   
      // listen for incoming connections.  
      try
      {
        // Create a TCP/IP socket.  
        _listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        _listenerSocket.Bind(_localEndPoint);
        _listenerSocket.Listen(200);

        // Start listening for connections.  
        while (true)
        {
          Console.WriteLine("Waiting for a new connection...");
          // Program is suspended while waiting for an incoming connection.  
          Socket handler = _listenerSocket.Accept();

          // An incoming connection needs to be processed.
          bytes = new byte[8192];
          int bytesRec = handler.Receive(bytes);
          var cmd = (CommandContainer)SerializerManager.Deserialize(bytes);

          switch (cmd.CommandType)
          {
            case CommandType.ClientLoginInform:
              var profil = (ProfileContainer) cmd.Data;
              _connectionManager.AddNewConnection(profil, handler);
              Console.WriteLine("New connected client {0}", profil.UserName);
              break;
          }

          //handler.Send(msg);
          //handler.Shutdown(SocketShutdown.Both);
          //handler.Close();
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
      if (_listenerSocket != null)
      {
        _listenerSocket.Close();
      }
    }
  }
}
