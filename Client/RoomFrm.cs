using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using Common;


namespace Client
{
  internal enum FlashMode
  {
    FLASHW_CAPTION = 0x1 ,
    FLASHW_TRAY = 0x2 ,
    FLASHW_ALL = FLASHW_CAPTION | FLASHW_TRAY
  }

  internal struct FlashInfo
  {
    public int cdSize;
    public System.IntPtr hwnd;
    public int dwFlags;
    public int uCount;
    public int dwTimeout;
  }

  public partial class RoomFrm : Form
  {
    private ClientManagement.ClientManager _remoteClient;
    private IPAddress _targetIP;
    private string _remoteName;
    private bool _activated;

    public string RemoteName
    {
      get { return _remoteName; }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
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

    public RoomFrm(ClientManagement.ClientManager cmdClient, IPAddress friendIP, string name, string initialMessage)
    {
      InitializeComponent();
      _remoteClient = cmdClient;
      _targetIP = friendIP;
      _remoteName = name;
      Text += " : " + name;
      txtMessages.Text = _remoteName + ": " + initialMessage +Environment.NewLine;
      _remoteClient.CommandReceived += new CommandReceivedEventHandler(room_CommandReceived);
    }

    public RoomFrm(ClientManagement.ClientManager cmdClient, IPAddress friendIP, string name)
    {
      InitializeComponent();
      _remoteClient = cmdClient;
      _targetIP = friendIP;
      _remoteName = name;
      Text += " : " + name;
      _remoteClient.CommandReceived += new CommandReceivedEventHandler(room_CommandReceived);
    }

    private void room_CommandReceived(object sender , CommandEventArgs e)
    {
      switch (e.Command.CommandType)
      {
        case CommandType.Message:
          //if ( !e.Command.Target.Equals(IPAddress.Broadcast) && e.Command.SenderIP.Equals(_targetIP))
          //{
          //  txtMessages.Text += e.Command.SenderName + ": " + e.Command.MetaData + Environment.NewLine;
          //  if ( !_activated)
          //  {
          //    if(WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
          //      ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageReceived);
          //    else
          //      ShareUtils.PlaySound(ShareUtils.SoundType.NewMessageWithPow);
          //    Flash(Handle , FlashMode.FLASHW_ALL , 3);
          //  }
          //}
          break;
      }    
    }

    [DllImport("user32.dll")]
    private static extern int FlashWindowEx(ref FlashInfo pfwi);
    private void Flash(System.IntPtr hwnd , FlashMode flashMode , int times)
    {
      unsafe
      {
        FlashInfo FlashInf = new FlashInfo();
        FlashInf.cdSize = sizeof(FlashInfo);
        FlashInf.dwFlags = (int)flashMode;
        FlashInf.dwTimeout = 0;
        FlashInf.hwnd = hwnd;
        FlashInf.uCount = times;
        FlashWindowEx(ref FlashInf);
      }
    }

    private void btnSend_Click(object sender , EventArgs e)
    {
      SendMessage();
    }

    private void SendMessage()
    {
      if (_remoteClient.Connected && txtNewMessage.Text.Trim() != "")
      {
        _remoteClient.SendCommand(new CommandContainer(CommandType.Message, new MessageContainer(_remoteClient.UserName, new RoomContainer("TODO"), txtNewMessage.Text, 999)));
        txtMessages.Text += _remoteClient.UserName + ": " + txtNewMessage.Text.Trim() + Environment.NewLine;
        txtNewMessage.Text = "";
        txtNewMessage.Focus();
      }
    }

    private void RoomFrm_FormClosing(object sender , FormClosingEventArgs e)
    {
      _remoteClient.CommandReceived -= new CommandReceivedEventHandler(room_CommandReceived);
    }

    private void mniExit_Click(object sender , EventArgs e)
    {
      Close();
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
      if (saveDlg.ShowDialog() == DialogResult.OK)
      {
        ShareUtils.SaveAsHTML(saveDlg.FileName, txtMessages.Lines, Text);
      }
    }

    private void RoomFrm_Load(object sender , EventArgs e)
    {
      Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width , Screen.PrimaryScreen.WorkingArea.Height - DesktopBounds.Height);
    }

    private void RoomFrm_Activated(object sender , EventArgs e)
    {
      _activated = true;
    }

    private void RoomFrm_Deactivate(object sender , EventArgs e)
    {
      _activated = false;
    }
  }
}