using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Proshot.UtilityLib.CommonDialogs;
using System.Net.Sockets;
using System.Threading;
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
      if (keyData == Keys.Enter)
      {
        SendMessage();
      }
      if (txtMessages.Focused && !ShareUtils.IsValidKeyForReadOnlyFields(keyData))
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
        case CommandType.Message:
          //if ( e.Command.Target.Equals(IPAddress.Broadcast) )
          //  txtMessages.Text += e.Command.SenderName + ": " + e.Command.MetaData + Environment.NewLine;
          //else if ( !IsPrivateWindowOpened(e.Command.SenderName) )
          //{
          //  OpenPrivateWindow(e.Command.SenderIP , e.Command.SenderName , e.Command.MetaData);
          //  ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageWithPow);
          //}
          break;
        case CommandType.UsersConnectionStatus:
          lstViwUsers.Items.Clear();
          var clientsStatus = ((UsersStatusContainer)e.Command.Data).ClientsStatus;
          foreach (KeyValuePair<string, bool> user in clientsStatus)
          {
            AddToList("", user.Key, user.Value);
          }
          break;
      }
    }    

    private void mniSignup_Click(object sender, EventArgs e)
    {
      LoginFrm dlg = new LoginFrm(_serverIpv4, _serverPort, false);
      dlg.ShowDialog();
      if (_client != null)
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Warning", string.Format("Disconnected user {0} !", _client.UserName), 300, 2000, 2000);
        Text = "Offline";
        _client.Disconnect();
        lstViwUsers.Items.Clear();
      }
      _client = dlg.Client;

      if (_client.Connected)
      {
        _client.CommandReceived += new CommandReceivedEventHandler(client_CommandReceived);
        _client.SendCommand(new CommandContainer(CommandType.RequestClientList, null));
        Text = "Online : " + _client.UserName;
        mniEnter.Text = "Log Off";
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
          Text = "Online : " + _client.UserName;
          mniEnter.Text = "Log Off";
        }
      }
      else
      {
        Text = "Offline";
        mniEnter.Text = "Login";
        _roomWindowsList.Clear();
        _client.Disconnect();
        _client = null;
        lstViwUsers.Items.Clear();
        txtNewMessage.Clear();
        txtNewMessage.Focus();
      }
    }
    
    private void mniExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      SendMessage();
    }

    private void SendMessage()
    {
      if (_client.Connected && txtNewMessage.Text.Trim() != "")
      {
        _client.SendCommand(new CommandContainer(CommandType.Message, new MessageContainer(_client.UserName, new RoomContainer("TODO"), txtNewMessage.Text, 999)));
        txtMessages.Text += _client.UserName + ": " + txtNewMessage.Text.Trim() + Environment.NewLine;
        txtNewMessage.Text = "";
        txtNewMessage.Focus();
      }
    }

    private void AddToList(string ip, string name, bool connected)
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

    private void RemoveFromList(string name)
    {
      ListViewItem item = lstViwUsers.FindItemWithText(name);
      if (item.Text != _client.IP.ToString())
      {
        lstViwUsers.Items.Remove(item);
        ShareUtils.PlaySound(ShareUtils.SoundType.ClientExit);
      }

      RoomFrm target = FindRoomWindow(name);
      if (target != null)
      {
        target.Close();
      }
    }

    private void OpenRoomWindow(IPAddress remoteClientIP, string clientName)
    {
      if (_client.Connected)
      {
        if (!IsRoomWindowOpened(clientName))
        {
          RoomFrm roomWindow = new RoomFrm(_client, remoteClientIP, clientName);
          _roomWindowsList.Add(roomWindow);
          roomWindow.FormClosed += new FormClosedEventHandler(roomWindow_FormClosed);
          roomWindow.StartPosition = FormStartPosition.CenterParent;
          roomWindow.Show(this);
        }
      }
    }

    private void OpenRoomWindow(IPAddress remoteClientIP, string clientName, string initialMessage)
    {
      if (_client.Connected)
      {
        RoomFrm roomWindow = new RoomFrm(_client, remoteClientIP, clientName, initialMessage);
        _roomWindowsList.Add(roomWindow);
        roomWindow.FormClosed += new FormClosedEventHandler(roomWindow_FormClosed);
        roomWindow.Show(this);
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
      if (lstViwUsers.SelectedItems.Count != 0)
      {
        OpenRoomWindow(IPAddress.Parse(lstViwUsers.SelectedItems[0].Text), lstViwUsers.SelectedItems[0].SubItems[1].Text);
      }
    }

    private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
    {
      Proshot.LanguageManager.LanguageActions.ChangeLanguageToEnglish();
      if (_client != null)
      {
        _client.Disconnect();
        _client = null;
      }
    }

    private void mniSave_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveDlg = new SaveFileDialog();
      saveDlg.Filter = "HTML Files(*.HTML;*.HTM)|*.html;*.htm";
      saveDlg.FilterIndex = 0;
      saveDlg.RestoreDirectory = true;
      saveDlg.CheckPathExists = true;
      saveDlg.OverwritePrompt = true;
      saveDlg.FileName = Text;
      if (saveDlg.ShowDialog() == DialogResult.OK)
      {
        ShareUtils.SaveAsHTML(saveDlg.FileName, txtMessages.Lines, Text);
      }
    }

    private void mniRoomConnect_Click(object sender, EventArgs e)
    {
      StartRoomChat();
    }

    #endregion
  }
}