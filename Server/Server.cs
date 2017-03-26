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

namespace Server
{
  public class Server
  {
    private readonly IDictionary<string, Profil> _members = new Dictionary<string, Profil>();
    private readonly ConnectionManager _connectionManager = new ConnectionManager(15000);

    public void StartListening(string hostNameOrAddress, int port)
    {
      // Data buffer for incoming data.  
      byte[] bytes = new Byte[1024];

      // Bind the socket to the local endpoint and   
      // listen for incoming connections.  
      try
      {
        // Establish the local endpoint for the socket.  
        // Dns.GetHostName returns the name of the   
        // host running the application.
        IPHostEntry ipHostEntry = Dns.GetHostEntry(hostNameOrAddress);
        IPAddress[] ipv4Addresses = Array.FindAll(ipHostEntry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);
        IPEndPoint localEndPoint = new IPEndPoint(ipv4Addresses[0], port);

        // Create a TCP/IP socket.  
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        listener.Bind(localEndPoint);
        listener.Listen(10);

        // Start listening for connections.  
        while (true)
        {
          Console.WriteLine("Waiting for a connection...");
          // Program is suspended while waiting for an incoming connection.  
          Socket handler = listener.Accept();

          // An incoming connection needs to be processed.
          bytes = new byte[1024];
          int bytesRec = handler.Receive(bytes);
          Profil client = (Profil)Serializer.Deserialize(bytes);

          _connectionManager.AddNewConnection(client, handler);

          //handler.Send(msg);
          //handler.Shutdown(SocketShutdown.Both);
          //handler.Close();
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
      }

      Console.WriteLine("\nPress ENTER to continue...");
      Console.Read();
    }
  }
}
