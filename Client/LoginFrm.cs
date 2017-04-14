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
  public partial class LoginFrm : Form
  {
    private bool _canClose;
    private ClientManager _client;
    private readonly bool _login;

    #region Contsructor

    public LoginFrm(IPAddress serverIP, int serverPort, bool login)
    {
      InitializeComponent();
      _login = login;
      _canClose = false;
      Control.CheckForIllegalCrossThreadCalls = false;
      _client = new ClientManager(serverIP , serverPort , "None", _login);
      _client.CommandReceived += new CommandReceivedEventHandler(CommandReceived);
      _client.ConnectingSuccessed += new ConnectingSuccessedEventHandler(client_ConnectingSuccessed);
      _client.ConnectingFailed += new ConnectingFailedEventHandler(client_ConnectingFailed);
    }

    #endregion

    #region Public

    public ClientManager Client
    {
      get { return _client; }
    }

    #endregion

    #region Private

    private void client_ConnectingFailed(object sender , EventArgs e)
    {
      frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
      popup.ShowPopup("Error" , "Server Is Not Accessible !" , 200 , 2000 , 2000);
      SetEnablity(true);
    }

    private void client_ConnectingSuccessed(object sender , EventArgs e)
    {
      //_client.SendCommand(new Command(CommandType.IsNameExists,_client.IP,_client.NetworkName));
      //_client.SendCommand(new CommandContainer(CommandType.IsNameExists, new ProfileContainer(_client.UserName, _client.Password, false)));
    }

    private void CommandReceived(object sender , CommandEventArgs e)
    {
      if (e.Command.CommandType == CommandType.UserAlreadyExists)
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error", "The User name is already exists !", 300, 2000, 2000);
        _client.Disconnect();
        SetEnablity(true);
      }
      else if (e.Command.CommandType == CommandType.InvalidCredentials)
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error", "Inavlid User name and/or Password !", 300, 2000, 2000);
        _client.Disconnect();
        SetEnablity(true);
      }
      else if (e.Command.CommandType == CommandType.ValidCredentials)
      {
        _canClose = true;
        Close();
      }
    }

    private void LoginToServer()
    {
      if ( txtUserName.Text.Trim() == "" )
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error" , "Username is empty !" , 1000 , 2000 , 2000);
        SetEnablity(true);
      }
      else if (txtPassword.Text.Trim() == "")
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error", "Password is empty !", 1000, 2000, 2000);
        SetEnablity(true);
      }
      else
      {
        _client.UserName = txtUserName.Text.Trim();
        _client.Password = txtPassword.Text.Trim();
        _client.ConnectToServer();
      }
    }

    private void btnEnter_Click(object sender , EventArgs e)
    {
      SetEnablity(false);
      LoginToServer();
    }
    private void SetEnablity(bool enable)
    {
      btnEnter.Enabled = enable;
      txtUserName.Enabled = enable;
      txtPassword.Enabled = enable;
      btnExit.Enabled = enable;
    }

    private void btnExit_Click(object sender , EventArgs e)
    {
      _canClose = true;
    }

    private void LoginFrm_FormClosing(object sender , FormClosingEventArgs e)
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