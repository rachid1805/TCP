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
      CheckForIllegalCrossThreadCalls = false;
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
    }

    private void CommandReceived(object sender , CommandEventArgs e)
    {
      var msg = string.Empty;

      switch (e.Command.CommandType)
      {
        case CommandType.UserAlreadyExists:
          msg = "The User name is already exists !";
          break;
        case CommandType.InvalidCredentials:
          msg = "Inavlid User name and/or Password !";
          break;
        case CommandType.UserAlreadyConnected:
          msg = "The User name is already connected !";
          break;
        case CommandType.ValidCredentials:
          _canClose = true;
          Close();
          break;
      }

      if (e.Command.CommandType != CommandType.ValidCredentials)
      {
        frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
        popup.ShowPopup("Error", msg, 300, 2000, 2000);
        _client.Disconnect();
        SetEnablity(true);
      }
    }

    private void LoginToServer()
    {
      if (txtUserName.Text.Trim() == "")
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