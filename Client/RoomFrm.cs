using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ClientManagement;
using Common;
using Proshot.UtilityLib.CommonDialogs;


namespace Client
{
  public partial class RoomFrm : Form
  {
    private readonly ClientManager _client;
    private readonly string _roomName;
    private readonly IList<MessageContainer> _messages;
    private int _msgId;
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
      _messages = new List<MessageContainer>();
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
          var archive = (RoomArchiveContainer)e.Command.Data;
          if (archive.GetRoom().Name.Equals(_roomName))
          {
            foreach (MessageContainer message in archive.GetMessagesList())
            {
              AddMessage(message);
            }
          }
          break;

        case CommandType.RemoveMessage:
          RemoveMessage((MessageContainer)e.Command.Data);
          break;

        case CommandType.LikeMessage:
          LikeMessage((MessageContainer)e.Command.Data);
          break;
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
        var newMsg = new MessageContainer(_client.UserName, new RoomContainer(_roomName), txtNewMessage.Text, _msgId++);
        _client.SendCommand(new CommandContainer(CommandType.Message, newMsg));
        AddMessage(newMsg);
        txtNewMessage.Text = "";
        txtNewMessage.Focus();
      }
    }

    private void AddMessage(MessageContainer newMsg)
    {
      ListViewItem item = new ListViewItem(new[] { string.Format("{0}: {1}", newMsg.User, newMsg.Msg), newMsg.Likes.ToString() });
      listViewMessage.Items.Add(item);
      _messages.Add(newMsg);
    }

    private void RemoveMessage(MessageContainer msgToRemove)
    {
      int index;
      var found = false;

      for (index = 0; index < _messages.Count; index++)
      {
        var currentMessage = _messages[index];
        if (msgToRemove.User.Equals(currentMessage.User) &&
            msgToRemove.Room.Name.Equals(currentMessage.Room.Name) &&
            msgToRemove.Msg.Equals(currentMessage.Msg) &&
            msgToRemove.MsgId.Equals(currentMessage.MsgId))
        {
          found = true;
          break;
        }
      }

      if (found)
      {
        listViewMessage.Items.RemoveAt(index);
        _messages.RemoveAt(index);
      }
    }

    private void LikeMessage(MessageContainer msgToLike)
    {
      int index;
      var found = false;

      for (index = 0; index < _messages.Count; index++)
      {
        var currentMessage = _messages[index];
        if (msgToLike.User.Equals(currentMessage.User) &&
            msgToLike.Room.Name.Equals(currentMessage.Room.Name) &&
            msgToLike.Msg.Equals(currentMessage.Msg) &&
            msgToLike.MsgId.Equals(currentMessage.MsgId))
        {
          found = true;
          break;
        }
      }

      if (found)
      {
        int likes = Convert.ToInt32(listViewMessage.Items[index].SubItems[1].Text) + 1;
        listViewMessage.Items[index].SubItems[1].Text = likes.ToString();
        _messages[index].AddLike();
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
        string[] lines = new string[listViewMessage.Items.Count];
        for (var index = 0; index < listViewMessage.Items.Count; index++)
        {
          lines[index] = listViewMessage.Items[index].SubItems[0].Text;
        }
        ShareUtils.SaveAsHTML(saveDlg.FileName, lines, string.Format("Chat room : {0}", _roomName));
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
      if (listViewMessage.SelectedItems.Count > 0)
      {
        var index = listViewMessage.Items.IndexOf(listViewMessage.SelectedItems[0]);
        if (_client.UserName.Equals(_messages[index].User))
        {
          // Delete only your own messages !
          _client.SendCommand(new CommandContainer(CommandType.RemoveMessage, new MessageContainer(_messages[index])));
        }
        else
        {
          frmPopup popup = new frmPopup(PopupSkins.SmallInfoSkin);
          popup.ShowPopup("Info", "You can only remove your own messages !", 200, 2000, 2000);
        }
      }
    }

    private void likeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (listViewMessage.SelectedItems.Count > 0)
      {
        // Like all messages including yours
        var index = listViewMessage.Items.IndexOf(listViewMessage.SelectedItems[0]);
        _client.SendCommand(new CommandContainer(CommandType.LikeMessage, new MessageContainer(_messages[index])));
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