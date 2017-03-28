using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Common;
using Proshot.UtilityLib.CommonDialogs;

namespace Client
{
  public partial class LoginFrm : Form
  {
    private bool _canClose;
    private Client _client;

    public Client Client
    {
      get { return _client; }
    }
    public LoginFrm(IPAddress serverIP,int serverPort)
    {
      InitializeComponent();
      _canClose = false;
      Control.CheckForIllegalCrossThreadCalls = false;
      _client = new Client(serverIP , serverPort , "None");
      _client.CommandReceived += new CommandReceivedEventHandler(CommandReceived);
      _client.ConnectingSuccessed += new ConnectingSuccessedEventHandler(client_ConnectingSuccessed);
      _client.ConnectingFailed += new ConnectingFailedEventHandler(client_ConnectingFailed);
    }

    private void client_ConnectingFailed(object sender , EventArgs e)
    {
      frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
      popup.ShowPopup("Error" , "Server Is Not Accessible !" , 200 , 2000 , 2000);
      SetEnablity(true);
    }

    private void client_ConnectingSuccessed(object sender , EventArgs e)
    {
      _client.SendCommand(new Command(CommandType.IsNameExists,_client.IP,_client.NetworkName));
    }

    void CommandReceived(object sender , CommandEventArgs e)
    {
      if ( e.Command.CommandType == CommandType.IsNameExists )
      {
        if ( e.Command.MetaData.ToLower() == "true" )
        {
          frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
          popup.ShowPopup("Error" , "The Username is already exists !" , 300 , 2000 , 2000);
          _client.Disconnect();
          SetEnablity(true);
        }
        else
        {
          _canClose = true;
          Close();
        }
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
        _client.NetworkName = txtUserName.Text.Trim();
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
      if ( !_canClose )
        e.Cancel = true;
      else
        _client.CommandReceived -= new CommandReceivedEventHandler(CommandReceived);
    }
  }
}