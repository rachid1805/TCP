using System;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Common;

namespace ClientManagement
{
  /// <summary>
  /// The command client command class.
  /// </summary>
  public class ClientManager
  {
    private Socket _clientSocket;
    private readonly Semaphore _semaphore;
    private BackgroundWorker _receiverThread;
    private IPEndPoint _serverEP;
    private string _userName;
    private string _password;
    private readonly bool _login;

    #region Contsructors

    /// <summary>
    /// Cretaes a command client instance.
    /// </summary>
    /// <param name="server">The remote server to connect.</param>
    /// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
    public ClientManager(IPEndPoint server, string netName, bool login)
    {
      _serverEP = server;
      _userName = netName;
      _login = login;
      _semaphore = new Semaphore(1, 1);
      System.Net.NetworkInformation.NetworkChange.NetworkAvailabilityChanged += new System.Net.NetworkInformation.NetworkAvailabilityChangedEventHandler(NetworkChange_NetworkAvailabilityChanged);
    }

    /// <summary>
    /// Cretaes a command client instance.
    /// </summary>
    ///<param name="serverIP">The IP of remote server.</param>
    ///<param name="port">The port of remote server.</param>
    /// <param name="netName">The string that will send to the server and then to other clients, to identify this client to all clients.</param>
    public ClientManager(IPAddress serverIP, int port, string netName, bool login)
      :this(new IPEndPoint(serverIP, port), netName, login)
    {
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// [Gets] The value that specifies the current client is connected or not.
    /// </summary>
    public bool Connected
    {
      get
      {
        if (_clientSocket != null)
        {
          return _clientSocket.Connected;
        }
        return false;
      }
    }
    /// <summary>
    /// [Gets] The IP address of the remote server.If this client is disconnected,this property returns IPAddress.None.
    /// </summary>
    public IPAddress ServerIP
    {
      get
      {
        if (Connected)
        {
          return _serverEP.Address;
        }
        return IPAddress.None;
      }
    }

    /// <summary>
    /// [Gets] The comunication port of the remote server.If this client is disconnected,this property returns -1.
    /// </summary>
    public int ServerPort
    {
      get
      {
        if (Connected)
        {
          return _serverEP.Port;
        }
        return -1;
      }
    }
    /// <summary>
    /// [Gets] The IP address of this client.If this client is disconnected,this property returns IPAddress.None.
    /// </summary>
    public IPAddress IP
    {
      get
      {
        if (Connected)
        {
          return ((IPEndPoint) _clientSocket.LocalEndPoint).Address;
        }
        return IPAddress.None;
      }
    }
    /// <summary>
    /// [Gets] The comunication port of this client.If this client is disconnected,this property returns -1.
    /// </summary>
    public int Port
    {
      get
      {
        if (Connected)
        {
          return ((IPEndPoint) _clientSocket.LocalEndPoint).Port;
        }
        return -1;
      }
    }

    /// <summary>
    /// [Gets/Sets] The string that will sent to the server and then to other clients, to identify this client to them.
    /// </summary>
    public string UserName
    {
      get { return _userName; }
      set { _userName = value; }
    }

    public string Password
    {
      get { return _password; }
      set { _password = value; }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Connect the current instance of command client to the server.This method throws ServerNotFoundException on failur.Run this method and handle the 'ConnectingSuccessed' and 'ConnectingFailed' to get the connection state.
    /// </summary>
    public void ConnectToServer()
    {
      BackgroundWorker connectionThread = new BackgroundWorker();
      connectionThread.DoWork += new DoWorkEventHandler(ConnectionThread_DoWork);
      connectionThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ConnectionThread_RunWorkerCompleted);
      connectionThread.RunWorkerAsync();
    }

    private void ConnectionThread_RunWorkerCompleted(object sender , RunWorkerCompletedEventArgs e)
    {
      if (!((bool) e.Result))
      {
        OnConnectingFailed(new EventArgs());
      }
      else
      {
        OnConnectingSuccessed(new EventArgs());
      }

      ((BackgroundWorker) sender).Dispose();
    }

    private void ConnectionThread_DoWork(object sender , DoWorkEventArgs e)
    {
      try
      {
        _clientSocket = new Socket(AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp);
        _clientSocket.Connect(_serverEP);
        e.Result = true;
        _receiverThread = new BackgroundWorker();
        _receiverThread.WorkerSupportsCancellation = true;
        _receiverThread.DoWork += new DoWorkEventHandler(StartReceive);
        _receiverThread.RunWorkerAsync();
        
        CommandType cmdType;
        if (_login)
        {
          cmdType = CommandType.ClientLogIn;
        }
        else
        {
          cmdType = CommandType.ClientSignUp;
        }
        CommandContainer cmd = new CommandContainer(cmdType, new ProfileContainer(_userName, _password));
        SendCommand(cmd);
      }
      catch
      {
        e.Result = false;
      }
    }
    /// <summary>
    /// Sends a command to the server if the connection is alive.
    /// </summary>
    /// <param name="cmd">The command to send.</param>
    public void SendCommand(CommandContainer cmd)
    {
      if (_clientSocket != null && _clientSocket.Connected)
      {
        BackgroundWorker senderThread = new BackgroundWorker();
        senderThread.DoWork += new DoWorkEventHandler(SenderThread_DoWork);
        senderThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SenderThread_RunWorkerCompleted);
        senderThread.WorkerSupportsCancellation = true;
        senderThread.RunWorkerAsync(cmd);
      }
      else
      {
        OnCommandFailed(new EventArgs());
      }
    }
        
    /// <summary>
    /// Disconnect the client from the server and returns true if the client had been disconnected from the server.
    /// </summary>
    /// <returns>True if the client had been disconnected from the server,otherwise false.</returns>
    public bool Disconnect()
    {
      if (_clientSocket != null && _clientSocket.Connected)
      {
        try
        {
          _clientSocket.Shutdown(SocketShutdown.Both);
          _clientSocket.Close();
          _receiverThread.CancelAsync();
          OnDisconnectedFromServer(new ClientEventArgs(_clientSocket));
          return true;
        }
        catch
        {
          return false;
        }
      }
      else
      {
        return true;
      }
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
    /// <param name="e">The received command.</param>
    protected virtual void OnCommandReceived(CommandEventArgs e)
    {
      if ( CommandReceived != null )
      {
        Control target = CommandReceived.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(CommandReceived, new object[] {this, e});
        }
        else
        {
          CommandReceived(this , e);
        }
      }
    }

    /// <summary>
    /// Occurs when a command had been sent to the the remote server Successfully.
    /// </summary>
    public event CommandSentEventHandler CommandSent;

    /// <summary>
    /// Occurs when a command had been sent to the the remote server Successfully.
    /// </summary>
    /// <param name="e">The sent command.</param>
    protected virtual void OnCommandSent(EventArgs e)
    {
      if (CommandSent != null)
      {
        Control target = CommandSent.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(CommandSent, new object[] {this, e});
        }
        else
        {
          CommandSent(this , e);
        }
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
        Control target = CommandFailed.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(CommandFailed, new object[] {this, e});
        }
        else
        {
          CommandFailed(this , e);
        }
      }
    }

    /// <summary>
    /// Occurs when the client disconnected.
    /// </summary>
    public event ServerDisconnectedEventHandler ServerDisconnected;

    /// <summary>
    /// Occurs when the server disconnected.
    /// </summary>
    /// <param name="e">Server information.</param>
    protected virtual void OnServerDisconnected(ServerEventArgs e)
    {
      if (ServerDisconnected != null)
      {
        Control target = ServerDisconnected.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(ServerDisconnected, new object[] {this, e});
        }
        else
        {
          ServerDisconnected(this , e);
        }
      }
    }

    /// <summary>
    /// Occurs when this client disconnected from the remote server.
    /// </summary>
    public event ClientDisconnectedEventHandler DisconnectedFromServer;

    /// <summary>
    /// Occurs when this client disconnected from the remote server.
    /// </summary>
    /// <param name="e">EventArgs.</param>
    protected virtual void OnDisconnectedFromServer(ClientEventArgs e)
    {
      if (DisconnectedFromServer != null)
      {
        Control target = DisconnectedFromServer.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(DisconnectedFromServer, new object[] {this, e});
        }
        else
        {
          DisconnectedFromServer(this, e);
        }
      }
    }

    /// <summary>
    /// Occurs when this client connected to the remote server Successfully.
    /// </summary>
    public event ConnectingSuccessedEventHandler ConnectingSuccessed;

    /// <summary>
    /// Occurs when this client connected to the remote server Successfully.
    /// </summary>
    /// <param name="e">EventArgs.</param>
    protected virtual void OnConnectingSuccessed(EventArgs e)
    {
      if (ConnectingSuccessed != null)
      {
        Control target = ConnectingSuccessed.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(ConnectingSuccessed, new object[] {this, e});
        }
        else
        {
          ConnectingSuccessed(this , e);
        }
      }
    }

    /// <summary>
    /// Occurs when this client failed on connecting to server.
    /// </summary>
    public event ConnectingFailedEventHandler ConnectingFailed;

    /// <summary>
    /// Occurs when this client failed on connecting to server.
    /// </summary>
    /// <param name="e">EventArgs.</param>
    protected virtual void OnConnectingFailed(EventArgs e)
    {
      if (ConnectingFailed != null)
      {
        Control target = ConnectingFailed.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(ConnectingFailed, new object[] {this, e});
        }
        else
        {
          ConnectingFailed(this , e);
        }
      }
    }

    /// <summary>
    /// Occurs when the network had been failed.
    /// </summary>
    public event NetworkDeadEventHandler NetworkDead;

    /// <summary>
    /// Occurs when the network had been failed.
    /// </summary>
    /// <param name="e">EventArgs.</param>
    protected virtual void OnNetworkDead(EventArgs e)
    {
      if (NetworkDead != null)
      {
        Control target = NetworkDead.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(NetworkDead, new object[] {this, e});
        }
        else
        {
          NetworkDead(this , e);
        }
      }
    }

    /// <summary>
    /// Occurs when the network had been started to work.
    /// </summary>
    public event NetworkAlivedEventHandler NetworkAlived;

    /// <summary>
    /// Occurs when the network had been started to work.
    /// </summary>
    /// <param name="e">EventArgs.</param>
    protected virtual void OnNetworkAlived(EventArgs e)
    {
      if (NetworkAlived != null)
      {
        Control target = NetworkAlived.Target as Control;
        if (target != null && target.InvokeRequired)
        {
          target.Invoke(NetworkAlived, new object[] {this, e});
        }
        else
        {
          NetworkAlived(this , e);
        }
      }
    }

    #endregion

    #region Private Methods

    private void NetworkChange_NetworkAvailabilityChanged(object sender, System.Net.NetworkInformation.NetworkAvailabilityEventArgs e)
    {
      if (!e.IsAvailable)
      {
        OnNetworkDead(new EventArgs());
        OnDisconnectedFromServer(new ClientEventArgs(_clientSocket));
      }
      else
      {
        OnNetworkAlived(new EventArgs());
      }
    }

    private void StartReceive(object sender, DoWorkEventArgs e)
    {
      while (_clientSocket.Connected)
      {
        // Read the command object.
        var bytes = new byte[8192];
        try
        {
          var readBytes = _clientSocket.Receive(bytes);
          if (readBytes == 0)
            break;
          CommandContainer cmd = (CommandContainer)SerializerManager.Deserialize(bytes);

          OnCommandReceived(new CommandEventArgs(cmd));
        }
        catch (Exception exception)
        {
          Console.WriteLine(exception);
        }
      }
      OnServerDisconnected(new ServerEventArgs(_clientSocket));
      Disconnect();
    }

    private void SenderThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (!e.Cancelled && e.Error == null && ((bool)e.Result))
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
      e.Result = SendCommandToServer(cmd);
    }

    private bool SendCommandToServer(CommandContainer cmd)
    {
      try
      {
        _semaphore.WaitOne();

        byte[] cmdBytes = SerializerManager.Serialize(cmd);
        _clientSocket.Send(cmdBytes);

        _semaphore.Release();

        return true;
      }
      catch (Exception)
      {
        _semaphore.Release();
        return false;
      }
    }

    #endregion
  }
}
