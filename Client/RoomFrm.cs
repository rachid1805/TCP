using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ClientManagement;
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
    private ClientManagement.ClientManager _client;
    private string _roomName;
    private bool _activated;

    public string RemoteName
    {
      get { return _roomName; }
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

    public RoomFrm(ClientManager client, string roomName)
    {
      InitializeComponent();
      _client = client;
      _roomName = roomName;
      Text = string.Format("{0} - {1}", roomName, client.UserName);
      _client.CommandReceived += new CommandReceivedEventHandler(room_CommandReceived);
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
        case CommandType.RoomList:
          var rooms = ((RoomsContainer)e.Command.Data).GetAllRooms();
          foreach (RoomUsersContainer room in rooms)
          {
            if (room.GetRoom().Name.Equals(_roomName))
            {
              listViewRoomUsers.Items.Clear();
              foreach (string user in room.GetRoomUsersList())
              {
                AddUserToRoom(user);
              }
            }
          }
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
      if (_client.Connected && txtNewMessage.Text.Trim() != "")
      {
        _client.SendCommand(new CommandContainer(CommandType.Message, new MessageContainer(_client.UserName, new RoomContainer("TODO"), txtNewMessage.Text, 999)));
        txtMessages.Text += _client.UserName + ": " + txtNewMessage.Text.Trim() + Environment.NewLine;
        txtNewMessage.Text = "";
        txtNewMessage.Focus();
      }
    }

    private void RoomFrm_FormClosing(object sender , FormClosingEventArgs e)
    {
      _client.CommandReceived -= new CommandReceivedEventHandler(room_CommandReceived);
      RoomUsersContainer roomUser = new RoomUsersContainer(new RoomContainer(_roomName, ""));
      roomUser.AddUser(_client.UserName);
      _client.SendCommand(new CommandContainer(CommandType.UserDisconnectedFromRoom, roomUser));
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

    private void AddUserToRoom(string name)
    {
      ListViewItem newRoom = listViewRoomUsers.Items.Add("");
      newRoom.ImageKey = "InLine.png";
      newRoom.SubItems.Add(name);
    }
  }
}