using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Common;

namespace ServerManagement
{
  internal class ConnectionManager
  {
    private readonly IDictionary<string, ProfilContainer> _members;
    private readonly IDictionary<string, Socket> _openedConnections;
    private Thread _synchronizationThread;
    private readonly int _synchronizationTime;

    internal ConnectionManager(int synchronizationTime)
    {
      _synchronizationTime = synchronizationTime;
      _members = new Dictionary<string, ProfilContainer>();
      _openedConnections = new Dictionary<string, Socket>();
      _synchronizationThread = new Thread(SynchronizeClients);
      _synchronizationThread.Start();
    }

    internal void AddNewConnection(ProfilContainer client, Socket socket)
    {
      byte[] msg;

      if (client.NewUser)
      {
        if (!_members.ContainsKey(client.UserName))
        {
          client.Connected = true;
          _members.Add(client.UserName, client);
          _openedConnections.Add(client.UserName, socket);
          msg = Encoding.ASCII.GetBytes(string.Format("User {0} added successfully", client.UserName));
        }
        else
        {
          msg = Encoding.ASCII.GetBytes(string.Format("User {0} already added", client.UserName));
        }
      }
      else
      {
        if (!_members.ContainsKey(client.UserName) || !_members[client.UserName].Password.Equals(client.Password))
        {
          msg = Encoding.ASCII.GetBytes("Invalid User and/or Password");
        }
        else if (_members[client.UserName].Connected)
        {
          msg = Encoding.ASCII.GetBytes(string.Format("User {0} already connected", client.UserName));
        }
        else
        {
          _members[client.UserName].Connected = true;
          msg = Encoding.ASCII.GetBytes(string.Format("User {0} connected successfully", client.UserName));
        }
      }

      //socket.Send(msg);
    }

    private void SynchronizeClients()
    {
      while (true)
      {
        Thread.Sleep(_synchronizationTime);

        if (_members.Count != 0)
        {
          var clientsStatus = new Dictionary<string, bool>();

          foreach (var clientId in _openedConnections.Keys)
          {
            if ((_openedConnections[clientId] == null) || !_openedConnections[clientId].Connected)
            {
              // Disconnected client
              _members[clientId].Connected = false;
            }
          }

          foreach (var client in _members)
          {
            clientsStatus.Add(client.Key, client.Value.Connected);
          }

          var members = new UsersStatusContainer(clientsStatus);
          byte[] stream = SerializerManager.Serialize(members);

          foreach (var clientId in _members.Keys)
          {
            if (_members[clientId].Connected)
            {
              try
              {
                //_openedConnections[clientId].Send(stream);
              }
              catch (SocketException e)
              {
                // Disconnected client
                _openedConnections[clientId] = null;
                //Console.WriteLine(e.ToString());
              }
            }
          }
        }
      }
    }
  }
}
