using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ClientManagement;
using Common;
using Proshot.UtilityLib.CommonDialogs;

namespace Client
{
  public partial class RoomInfoFrm : Form
  {
    private bool _canClose;
    private ClientManager _client;
    private bool _created;
    private string _roomName;
    private string _roomDescription;

    #region Contsructor

    public RoomInfoFrm(ClientManager client)
    {
      InitializeComponent();
      _canClose = false;
      _created = false;
      CheckForIllegalCrossThreadCalls = false;
      _client = client;
      _client.CommandReceived += new CommandReceivedEventHandler(CommandReceived);
    }

    #endregion

    #region Public

    public bool RoomCreated
    {
      get { return _created; }
    }

    public string RoomName
    {
      get { return _roomName; }
    }

    #endregion

    #region Private

    private void CommandReceived(object sender , CommandEventArgs e)
    {
      if (e.Command.CommandType == CommandType.RoomAlreadyExists)
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error", "The Room name is already exists !", 300, 2000, 2000);
        SetEnablity(true);
      }
      else if (e.Command.CommandType == CommandType.RoomCreated)
      {
        _created = true;
        _canClose = true;
        Close();
      }
    }

    private void SendRoomInfoToServer()
    {
      if (txtRoomName.Text.Trim() == "")
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error" , "Room name is empty !" , 1000 , 2000 , 2000);
        SetEnablity(true);
      }
      else if (txtRoomDescription.Text.Trim() == "")
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error", "Room description is empty !", 1000, 2000, 2000);
        SetEnablity(true);
      }
      else
      {
        _roomName = txtRoomName.Text.Trim();
        _roomDescription = txtRoomDescription.Text.Trim();
        var cmd = new CommandContainer(CommandType.CreateRoom, new RoomContainer(_roomName, _roomDescription));
        _client.SendCommand(cmd);
      }
    }

    private void btnEnter_Click(object sender , EventArgs e)
    {
      SetEnablity(false);
      SendRoomInfoToServer();
    }
    private void SetEnablity(bool enable)
    {
      btnEnter.Enabled = enable;
      txtRoomName.Enabled = enable;
      txtRoomDescription.Enabled = enable;
      btnExit.Enabled = enable;
    }

    private void btnExit_Click(object sender , EventArgs e)
    {
      _canClose = true;
    }

    private void RoomInfoFrm_FormClosing(object sender , FormClosingEventArgs e)
    {
      if (!_canClose)
      {
        e.Cancel = true;
      }
      else
      {
        _client.CommandReceived -= new CommandReceivedEventHandler(CommandReceived);
      }
    }

    #endregion
  }
}