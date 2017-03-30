using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Proshot.UtilityLib.CommonDialogs;
using System.Net.Sockets;
using Common;

namespace Client
{
  public partial class MainFrm : Form
  {
    private ClientManagement.Client _client;
    private List<PrivateFrm> _privateWindowsList;
    private readonly IPAddress _serverIpv4;
    private readonly int _serverPort;

    public MainFrm(string serverNameOrAddress, int serverPort)
    {
      InitializeComponent();
      _privateWindowsList = new List<PrivateFrm>();

      IPHostEntry ipHostInfo = Dns.GetHostEntry(serverNameOrAddress);
      _serverIpv4 = Array.FindAll(ipHostInfo.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork)[0];
      _serverPort = serverPort;

      _client = new ClientManagement.Client(_serverIpv4, _serverPort, "None");
    }
       
    protected override bool ProcessCmdKey(ref Message msg , Keys keyData)
    {
      if ( keyData == Keys.Enter )
        SendMessage();
      if ( txtMessages.Focused  && !ShareUtils.IsValidKeyForReadOnlyFields(keyData))
        return true;
      return base.ProcessCmdKey(ref msg , keyData);
    }
    private bool IsPrivateWindowOpened(string remoteName)
    {
      foreach ( PrivateFrm privateWindow in _privateWindowsList )
        if ( privateWindow.RemoteName == remoteName )
          return true;
      return false;
    }
    private PrivateFrm FindPrivateWindow(string remoteName)
    {
      foreach ( PrivateFrm privateWindow in _privateWindowsList )
        if ( privateWindow.RemoteName == remoteName )
          return privateWindow;
      return null;
    }
    void client_CommandReceived(object sender , CommandEventArgs e)
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
        case CommandType.FreeCommand:
          //string [] newInfo = e.Command.MetaData.Split(new char [] { ':' });
          //AddToList(newInfo [0] , newInfo [1]);
          //ShareUtils.PlaySound(ShareUtils.SoundType.NewClientEntered);
          break;
        case CommandType.SendClientList:
          //string [] clientInfo = e.Command.MetaData.Split(new char[]{':'});
          //AddToList(clientInfo [0] , clientInfo [1]);
          break;
        case CommandType.ClientLogOffInform:
          //RemoveFromList(e.Command.SenderName);
          break;
      }
    }

    private void RemoveFromList(string name)
    {
      ListViewItem item = lstViwUsers.FindItemWithText(name);
      if ( item.Text != _client.IP.ToString() )
      {
        lstViwUsers.Items.Remove(item);
        ShareUtils.PlaySound(ShareUtils.SoundType.ClientExit);
      }

      PrivateFrm target = FindPrivateWindow(name);
      if ( target != null )
        target.Close();
    }

    private void mniSignup_Click(object sender, EventArgs e)
    {
      LoginFrm dlg = new LoginFrm(_serverIpv4, _serverPort);
      dlg.ShowDialog();
      _client = dlg.Client;

      if (_client.Connected)
      {
        _client.CommandReceived += new CommandReceivedEventHandler(client_CommandReceived);
        //_client.SendCommand(new Command(CommandType.FreeCommand, IPAddress.Broadcast, _client.IP + ":" + _client.NetworkName));
        //_client.SendCommand(new Command(CommandType.SendClientList, _client.ServerIP));
        AddToList(_client.IP.ToString(), _client.UserName);
        mniEnter.Text = "Log Off";
      }
    }

    private void mniEnter_Click(object sender , EventArgs e)
    {
      if (mniEnter.Text == "Login")
      {
        LoginFrm dlg = new LoginFrm(_serverIpv4, _serverPort);
        dlg.ShowDialog();
        _client = dlg.Client;
                
        if (_client.Connected)
        {
          _client.CommandReceived += new CommandReceivedEventHandler(client_CommandReceived);
          //_client.SendCommand(new Command(CommandType.FreeCommand , IPAddress.Broadcast , _client.IP + ":" + _client.NetworkName));
          //_client.SendCommand(new Command(CommandType.SendClientList, _client.ServerIP));
          AddToList(_client.IP.ToString() , _client.UserName);
          mniEnter.Text = "Log Off";
        }
      }
      else
      {
        mniEnter.Text = "Login";
        _privateWindowsList.Clear();
        _client.Disconnect();
        lstViwUsers.Items.Clear();
        txtNewMessage.Clear();
        txtNewMessage.Focus();
      }
    }
    
    private void mniExit_Click(object sender , EventArgs e)
    {
      Close();
    }

    private void btnSend_Click(object sender , EventArgs e)
    {
      SendMessage();
    }

    private void SendMessage()
    {
      if ( _client.Connected && txtNewMessage.Text.Trim() != "" )
      {
        _client.SendCommand(new Command(CommandType.Message, new MessageContainer(_client.UserName, "TODO", txtNewMessage.Text)));
        txtMessages.Text += _client.UserName + ": " + txtNewMessage.Text.Trim() + Environment.NewLine;
        txtNewMessage.Text = "";
        txtNewMessage.Focus();
      }
    }

    private void AddToList(string ip,string name)
    {
      ListViewItem newItem = lstViwUsers.Items.Add(ip);
      newItem.ImageKey = "Smiely.png";
      newItem.SubItems.Add(name);
    }

    private void OpenPrivateWindow(IPAddress remoteClientIP,string clientName)
    {
      if ( _client.Connected )
      {
        if ( !IsPrivateWindowOpened(clientName) )
        {
          PrivateFrm privateWindow = new PrivateFrm(_client , remoteClientIP , clientName);
          _privateWindowsList.Add(privateWindow);
          privateWindow.FormClosed += new FormClosedEventHandler(privateWindow_FormClosed);
          privateWindow.StartPosition = FormStartPosition.CenterParent;
          privateWindow.Show(this);
        }
      }
    }

    private void OpenPrivateWindow(IPAddress remoteClientIP , string clientName , string initialMessage)
    {
      if (_client.Connected )
      {
        PrivateFrm privateWindow = new PrivateFrm(_client , remoteClientIP , clientName , initialMessage);
        _privateWindowsList.Add(privateWindow);
        privateWindow.FormClosed += new FormClosedEventHandler(privateWindow_FormClosed);
        privateWindow.Show(this);
      }
    }

    void privateWindow_FormClosed(object sender , FormClosedEventArgs e)
    {
      _privateWindowsList.Remove((PrivateFrm)sender);
    }

    private void btnPrivate_Click(object sender , EventArgs e)
    {
      StartPrivateChat();
    }

    private void StartPrivateChat()
    {
      if ( lstViwUsers.SelectedItems.Count != 0 )
        OpenPrivateWindow(IPAddress.Parse(lstViwUsers.SelectedItems [0].Text) , lstViwUsers.SelectedItems [0].SubItems [1].Text);
    }

    private void MainFrm_FormClosing(object sender , FormClosingEventArgs e)
    {
      Proshot.LanguageManager.LanguageActions.ChangeLanguageToEnglish();
      _client.Disconnect();
    }

    private void mniSave_Click(object sender , EventArgs e)
    {
      SaveFileDialog saveDlg = new SaveFileDialog();
      saveDlg.Filter = "HTML Files(*.HTML;*.HTM)|*.html;*.htm";
      saveDlg.FilterIndex = 0;
      saveDlg.RestoreDirectory = true;
      saveDlg.CheckPathExists = true;
      saveDlg.OverwritePrompt = true;
      saveDlg.FileName = Text;
      if ( saveDlg.ShowDialog() == DialogResult.OK )
        ShareUtils.SaveAsHTML(saveDlg.FileName , txtMessages.Lines , Text);
    }

    private void mniCopy_Click(object sender , EventArgs e)
    {
      txtNewMessage.Copy();
    }

    private void mniPaste_Click(object sender , EventArgs e)
    {
      txtNewMessage.Paste();
    }

    private void mniCopyText_Click(object sender , EventArgs e)
    {
      txtMessages.Copy();
    }

    private void mniPrivate_Click(object sender , EventArgs e)
    {
      StartPrivateChat();
    }
  }
}