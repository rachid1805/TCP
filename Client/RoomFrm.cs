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
      if (listViewMessage.Focused && !ShareUtils.IsValidKeyForReadOnlyFields(keyData))
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

    private void room_CommandReceived(object sender, CommandEventArgs e)
    {
      switch (e.Command.CommandType)
      {
        case CommandType.Message:
          var newMsgContainer = (MessageContainer)e.Command.Data;
          if (newMsgContainer.Room.Name.Equals(_roomName))
          {
            //AddMessage(newMsgContainer.User, newMsgContainer.Msg);
            AddMessage(newMsgContainer);
          }
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
        case CommandType.RoomArchive:
          var archive = ((RoomArchiveContainer)e.Command.Data);
          if (archive.GetRoom().Name.Equals(_roomName))
          {
            //txtMessages.Clear();
            foreach (MessageContainer message in archive.GetMessagesList())
            {
              AddMessage(message);
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
        _client.SendCommand(new CommandContainer(CommandType.Message, new MessageContainer(_client.UserName, new RoomContainer(_roomName), txtNewMessage.Text, 999)));
        //AddMessage(_client.UserName, txtNewMessage.Text.Trim());
        AddMessage(new MessageContainer(_client.UserName, new RoomContainer(_roomName), txtNewMessage.Text, 999));
        txtNewMessage.Text = "";
        txtNewMessage.Focus();
      }
    }

    private void AddMessage(MessageContainer newMsg)
    {
      //txtMessages.Text += clientName  + ": " + newMsg + Environment.NewLine;
      string message = newMsg.User + ": " + newMsg.Msg;
      ListViewItem item = new ListViewItem(new[] { message.PadRight(70), "0",newMsg.MsgId.ToString(), newMsg.User, newMsg.Room.Name }); 
      listViewMessage.Items.Add(item);
      
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
      {//TO BE IMPLEMENTED
        //ShareUtils.SaveAsHTML(saveDlg.FileName, txtMessages.Lines, Text);
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

    private void listViewMessage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    private void listViewMessage_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        if (listViewMessage.FocusedItem.Bounds.Contains(e.Location) == true)
        {
          contextMenuStripListViewMessage.Show(Cursor.Position);
        }
      }
    }

    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
     // int index;
      if (listViewMessage.SelectedItems.Count > 0)
      {
       // index = listViewMessage.Items.IndexOf(listViewMessage.SelectedItems[0]);
        ListViewItem listItem = listViewMessage.SelectedItems[0];
        MessageBox.Show("user+message: " + listItem.SubItems[0].Text + "\n" +
                        "number of like: " + listItem.SubItems[1].Text + "\n" +
                        "message id: " + listItem.SubItems[2].Text + "\n" +
                        "username: " + listItem.SubItems[3].Text + "\n" +
                        "room: " + listItem.SubItems[4].Text + "\n");
      }
      
    }

    private void likeToolStripMenuItem_Click(object sender, EventArgs e)
    {
    //  int index;
      if (listViewMessage.SelectedItems.Count > 0)
      {
       // index = listViewMessage.Items.IndexOf(listViewMessage.SelectedItems[0]);
        ListViewItem listItem = listViewMessage.SelectedItems[0];
        MessageBox.Show("user+message: " + listItem.SubItems[0].Text + "\n" +
                        "number of like: " + listItem.SubItems[1].Text + "\n" +
                        "message id: " + listItem.SubItems[2].Text + "\n" +
                        "username: " + listItem.SubItems[3].Text + "\n" +
                        "room: " + listItem.SubItems[4].Text + "\n");
      }
    }

    private void listViewRoomUsers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void splitContainer_Panel1_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}