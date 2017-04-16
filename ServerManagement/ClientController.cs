using System;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using Common;

namespace ServerManagement
{
  /// <summary>
  /// The class that contains some methods and properties to manage the remote clients.
  /// </summary>
  public class ClientController
  {
    private readonly Socket _socket;
    private string _clientName;
    private readonly BackgroundWorker _receiverThread;
    private readonly Semaphore _semaphore;
    private bool _inLine;

    #region Constructor

    /// <summary>
    /// Creates an instance of ClientManager class to comunicate with remote clients.
    /// </summary>
    /// <param name="clientSocket">The socket of ClientManager.</param>
    public ClientController(Socket clientSocket)
    {
      _socket = clientSocket;
      _semaphore = new Semaphore(1, 1);
      _receiverThread = new BackgroundWorker();
      _receiverThread.DoWork += new DoWorkEventHandler(StartReceive);
      _receiverThread.RunWorkerAsync();
    }

    #endregion

    /// <summary>
    /// Gets the IP address of connected remote client.This is 'IPAddress.None' if the client is not connected.
    /// </summary>
    public IPAddress IP
    {
      get
      {
        if (_socket != null)
        {
          return ((IPEndPoint)_socket.RemoteEndPoint).Address;
        }
        return IPAddress.None;
      }
    }
    /// <summary>
    /// Gets the port number of connected remote client.This is -1 if the client is not connected.
    /// </summary>
    public int Port
    {
      get
      {
        if (_socket != null)
        {
          return ((IPEndPoint)_socket.RemoteEndPoint).Port;
        }
        return -1;
      }
    }
    /// <summary>
    /// [Gets] The value that specifies the remote client is connected to this server or not.
    /// </summary>
    public bool Connected
    {
      get
      {
        if (_socket != null)
        {
          return _socket.Connected;
        }
        return false;
      }
    }
        
    /// <summary>
    /// The name of remote client.
    /// </summary>
    public string ClientName
    {
      get { return _clientName; }
      set { _clientName = value; }
    }

    /// <summary>
    /// The inline status of remote client.
    /// </summary>
    public bool InLine
    {
      get { return _inLine; }
      set { _inLine = value; }
    }

    #region Private Methods

    private void StartReceive(object sender, DoWorkEventArgs e)
    {
      while (_socket.Connected)
      {
        // Read the command object.
        var bytes = new byte[8192];
        try
        {
          var readBytes = _socket.Receive(bytes);
          if (readBytes == 0)
            break;
          CommandContainer command = (CommandContainer)SerializerManager.Deserialize(bytes);

          if ((command.CommandType == CommandType.ClientSignUp) || (command.CommandType == CommandType.ClientLogIn))
          {
            ProfileContainer profile = (ProfileContainer)command.Data;
            _clientName = profile.UserName;
          }

          OnCommandReceived(new CommandEventArgs(command));
        }
        catch (Exception)
        {
        }
      }
      OnDisconnected(new ClientEventArgs(_socket));
      Disconnect();
    }

    private void SenderThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (!e.Cancelled && e.Error == null && ((bool) e.Result))
      {
        OnCommandSent(new EventArgs());
      }
      else
      {
        OnCommandFailed(new EventArgs());
      }

      ((BackgroundWorker)sender).Dispose();
      GC.Collect();
    }

    private void SenderThread_DoWork(object sender, DoWorkEventArgs e)
    {
      CommandContainer cmd = (CommandContainer)e.Argument;
      e.Result = SendCommandToClient(cmd);
    }

    private bool SendCommandToClient(CommandContainer cmd)
    {
      try
      {
        _semaphore.WaitOne();
        
        var bytes = SerializerManager.Serialize(cmd);
        _socket.Send(bytes);

        _semaphore.Release();

        return true;
      }
      catch
      {
        _semaphore.Release();
        return false;
      }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Sends a command to the remote client if the connection is alive.
    /// </summary>
    /// <param name="cmd">The command to send.</param>
    public void SendCommand(CommandContainer cmd)
    {
      if (_socket != null && _socket.Connected)
      {
        BackgroundWorker senderThread = new BackgroundWorker();
        senderThread.DoWork += new DoWorkEventHandler(SenderThread_DoWork);
        senderThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SenderThread_RunWorkerCompleted);
        senderThread.RunWorkerAsync(cmd);
      }
      else
      {
        OnCommandFailed(new EventArgs());
      }
    }
    
    /// <summary>
    /// Disconnect the current client manager from the remote client and returns true if the client had been disconnected from the server.
    /// </summary>
    /// <returns>True if the remote client had been disconnected from the server,otherwise false.</returns>
    public bool Disconnect()
    {
      if (_socket != null && _socket.Connected)
      {
        try
        {
          _socket.Shutdown(SocketShutdown.Both);
          _socket.Close();
          return true;
        }
        catch
        {
          return false;
        }
      }
      return true;
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs when a command received from a remote client.
    /// </summary>
    public event CommandReceivedEventHandler CommandReceived;

    /// <summary>
    /// Occurs when a command received from a remote client.
    /// </summary>
    /// <param name="e">Received command.</param>
    protected virtual void OnCommandReceived(CommandEventArgs e)
    {
      if (CommandReceived != null)
      {
        CommandReceived(this, e);
      }
    }

    /// <summary>
    /// Occurs when a command had been sent to the remote client successfully.
    /// </summary>
    public event CommandSentEventHandler CommandSent;

    /// <summary>
    /// Occurs when a command had been sent to the remote client successfully.
    /// </summary>
    /// <param name="e">The sent command.</param>
    protected virtual void OnCommandSent(EventArgs e)
    {
      if (CommandSent != null)
      {
        CommandSent(this, e);
      }
    }

    /// <summary>
    /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
    /// </summary>
    public event CommandSendingFailedEventHandler CommandFailed;

    /// <summary>
    /// Occurs when a command sending action had been failed.This is because disconnection or sending exception.
    /// </summary>
    /// <param name="e">The sent command.</param>
    protected virtual void OnCommandFailed(EventArgs e)
    {
      if (CommandFailed != null)
      {
        CommandFailed(this, e);
      }
    }

    /// <summary>
    /// Occurs when a client disconnected from this server.
    /// </summary>
    public event ClientDisconnectedEventHandler DisconnectedClient;

    /// <summary>
    /// Occurs when a client disconnected from this server.
    /// </summary>
    /// <param name="e">Client information.</param>
    protected virtual void OnDisconnected(ClientEventArgs e)
    {
      if (DisconnectedClient != null)
      {
        DisconnectedClient(this, e);
      }
    }

    #endregion
  }
}
