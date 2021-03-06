using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using Proshot.UtilityLib.CommonDialogs;
using System.Net.Sockets;
using Common;
using ClientManagement;

namespace Client
{
  public partial class MainFrm : Form
  {
    private ClientManager _client;
    private List<RoomFrm> _roomWindowsList;
    private readonly IPAddress _serverIpv4;
    private readonly int _serverPort;

    #region Contsructor

    public MainFrm(string serverNameOrAddress, int serverPort)
    {
      InitializeComponent();
      _roomWindowsList = new List<RoomFrm>();

      IPHostEntry ipHostInfo = Dns.GetHostEntry(serverNameOrAddress);
      _serverIpv4 = Array.FindAll(ipHostInfo.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork)[0];
      _serverPort = serverPort;
    }

    #endregion

    #region Protected

    protected override bool ProcessCmdKey(ref Message msg , Keys keyData)
    {
      if (!ShareUtils.IsValidKeyForReadOnlyFields(keyData))
      {
        return true;
      }
      return base.ProcessCmdKey(ref msg , keyData);
    }

    #endregion

    #region Private

    private bool IsRoomWindowOpened(string remoteName)
    {
      foreach (RoomFrm roomWindow in _roomWindowsList)
      {
        if (roomWindow.RemoteName == remoteName)
        {
          return true;
        }
      }
      return false;
    }

    private RoomFrm FindRoomWindow(string remoteName)
    {
      foreach (RoomFrm roomWindow in _roomWindowsList)
      {
        if (roomWindow.RemoteName == remoteName)
        {
          return roomWindow;
        }
      }
      return null;
    }

    private void client_CommandReceived(object sender, CommandEventArgs e)
    {
      switch (e.Command.CommandType)
      {
        case CommandType.UsersConnectionStatus:
          lstViwUsers.Items.Clear();
          var clientsStatus = ((UsersStatusContainer)e.Command.Data).ClientsStatus;
          foreach (KeyValuePair<string, bool> user in clientsStatus)
          {
            AddToUsersList(user.Key, user.Value);
          }
          break;

        case CommandType.RoomList:
          ClearRoomItems();
          var roomsContainer = (RoomsContainer)e.Command.Data;
          var rooms = ((RoomsContainer)e.Command.Data).GetAllRooms();
          foreach (RoomUsersContainer room in rooms)
          {
            AddToRoomsList(room.GetRoom().Name, room.GetRoom().Description, room.GetRoomUsersList().Count);
          }
          break;

        case CommandType.UserProfile:
          var userProfileContainer = (ProfileContainer)e.Command.Data;
          ProfileFrm dlg = new ProfileFrm();
          dlg.userName.Text = userProfileContainer.UserName;
          dlg.dateJoined.Text = userProfileContainer.DateJoined.ToString();
          dlg.lastConnection.Text = userProfileContainer.LastConnected.ToString();
          dlg.ShowDialog();
          break;
      }
    }    

    private void mniSignup_Click(object sender, EventArgs e)
    {
      LoginFrm dlg = new LoginFrm(_serverIpv4, _serverPort, false);
      dlg.ShowDialog();
      if (_client != null)
      {
        if (_client.Connected)
        {
          frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
          popup.ShowPopup("Warning", string.Format("Disconnected user {0} !", _client.UserName), 300, 2000, 2000);
          _client.SendCommand(new CommandContainer(CommandType.ClientLogOff, new ProfileContainer(_client.UserName, _client.Password)));
        }
        Text = "Offline";
        _client.Disconnect();
        lstViwUsers.Items.Clear();
        ClearRoomItems();
        CloseRooms();
      }
      _client = dlg.Client;

      if (_client.Connected)
      {
        _client.CommandReceived += new CommandReceivedEventHandler(client_CommandReceived);
        _client.SendCommand(new CommandContainer(CommandType.RequestClientList, null));
        _client.SendCommand(new CommandContainer(CommandType.RequestRoomList, null));
        Text = "Online : " + _client.UserName;
        mniEnter.Text = "Log Off";
        mniCreateRoom.Enabled = true;
        mniConnectMyProfile.Enabled = true;
      }
      else
      {
        _client = null;
      }
    }

    private void mniEnter_Click(object sender, EventArgs e)
    {
      if (mniEnter.Text == "Login")
      {
        LoginFrm dlg = new LoginFrm(_serverIpv4, _serverPort, true);
        dlg.ShowDialog();
        _client = dlg.Client;
                
        if (_client.Connected)
        {
          _client.CommandReceived += new CommandReceivedEventHandler(client_CommandReceived);
          _client.SendCommand(new CommandContainer(CommandType.RequestClientList, null));
          _client.SendCommand(new CommandContainer(CommandType.RequestRoomList, null));
          Text = "Online : " + _client.UserName;
          mniEnter.Text = "Log Off";
          mniCreateRoom.Enabled = true;
          mniConnectMyProfile.Enabled = true;
        }
      }
      else
      {
        Text = "Offline";
        mniEnter.Text = "Login";
        mniCreateRoom.Enabled = false;
        mniConnectMyProfile.Enabled = false;
        _client.SendCommand(new CommandContainer(CommandType.ClientLogOff, new ProfileContainer(_client.UserName, _client.Password)));
        _client.Disconnect();
        _client = null;
        lstViwUsers.Items.Clear();
        ClearRoomItems();
        CloseRooms();
      }
    }
    
    private void mniExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void AddToUsersList(string name, bool connected)
    {
      ListViewItem newItem = lstViwUsers.Items.Add(_client.IP.ToString());
      if (connected)
      {
        newItem.ImageKey = "InLine.png";
      }
      else
      {
        newItem.ImageKey = "OffLine.png";
      }
      newItem.SubItems.Add(name);
    }

    private void AddToRoomsList(string name, string description, int users)
    {
      lstViwRooms.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      ListViewItem newRoom = lstViwRooms.Items.Add("");
      newRoom.ImageKey = "Chat.png";
      newRoom.SubItems.Add(name);
      newRoom.SubItems.Add(description);
      newRoom.SubItems.Add(users.ToString());
    }

    private void OpenRoomWindow(string roomName)
    {
      if (_client.Connected)
      {
        if (!IsRoomWindowOpened(roomName))
        {
          RoomFrm roomWindow = new RoomFrm(_client, roomName);
          _roomWindowsList.Add(roomWindow);
          roomWindow.FormClosed += new FormClosedEventHandler(roomWindow_FormClosed);
          roomWindow.StartPosition = FormStartPosition.CenterParent;
          roomWindow.Show(this);

          RoomUsersContainer roomUser = new RoomUsersContainer(new RoomContainer(roomName, ""));
          roomUser.AddUser(_client.UserName);
          _client.SendCommand(new CommandContainer(CommandType.ConnectToRoom, roomUser));
          _client.SendCommand(new CommandContainer(CommandType.RequestRoomArchive, new RoomContainer(roomUser.GetRoom().Name)));
        }
      }
    }

    void roomWindow_FormClosed(object sender, FormClosedEventArgs e)
    {
      _roomWindowsList.Remove((RoomFrm)sender);
    }

    private void btnConnectToRoom_Click(object sender, EventArgs e)
    {
      StartRoomChat();
    }

    private void StartRoomChat()
    {
      if (lstViwRooms.SelectedItems.Count != 0)
      {
        OpenRoomWindow(lstViwRooms.SelectedItems[0].SubItems[1].Text);
      }
    }

    private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Proshot.LanguageManager.LanguageActions.ChangeLanguageToEnglish();
      if (_client != null)
      {
        _client.SendCommand(new CommandContainer(CommandType.ClientLogOff, new ProfileContainer(_client.UserName, _client.Password)));
        _client.Disconnect();
        _client = null;
      }
    }

    private void mniCreateRoom_Click(object sender, EventArgs e)
    {
      // Enter the room name and description
      RoomInfoFrm dlg = new RoomInfoFrm(_client);
      dlg.ShowDialog();

      if (dlg.RoomCreated)
      {
        OpenRoomWindow(dlg.RoomName);
      }      
    }

    private void mniConnectToRoom_Click(object sender, EventArgs e)
    {
      StartRoomChat();
    }

    private void ClearRoomItems()
    {
      lstViwRooms.HeaderStyle = ColumnHeaderStyle.None;
      lstViwRooms.Items.Clear();
    }

    private void CloseRooms()
    {
      RoomFrm[] rooms = new RoomFrm[_roomWindowsList.Count];
      _roomWindowsList.CopyTo(rooms);
      foreach (RoomFrm roomWindow in rooms)
      {
        roomWindow.Close();
      }
    }

    private void mniConnectMyProfile_Click(object sender, EventArgs e)
    {
      if (_client != null)
      {
        _client.SendCommand(new CommandContainer(CommandType.RequestUserProfile, new ProfileContainer(_client.UserName, _client.Password)));
      }
    }

    #endregion
  }
}