using System.Drawing;

namespace Client
{
  partial class RoomFrm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomFrm));
      listViewMessage = new System.Windows.Forms.ListView();
      msg = new System.Windows.Forms.ColumnHeader();
      likes = new System.Windows.Forms.ColumnHeader();
      txtNewMessage = new Proshot.UtilityLib.TextBox();
      lblNewMessage = new Proshot.UtilityLib.Label();
      splitContainer = new System.Windows.Forms.SplitContainer();
      listViewRoomUsers = new Proshot.UtilityLib.ListView();
      colUserIcon = new System.Windows.Forms.ColumnHeader();
      colUserName = new System.Windows.Forms.ColumnHeader();
      imgList = new System.Windows.Forms.ImageList(components);
      btnSend = new Proshot.UtilityLib.Button();
      mnuMain = new Proshot.UtilityLib.MenuStrip();
      mniChat = new System.Windows.Forms.ToolStripMenuItem();
      mniSave = new System.Windows.Forms.ToolStripMenuItem();
      mniExit = new System.Windows.Forms.ToolStripMenuItem();
      contextMenuStripListViewMessage = new System.Windows.Forms.ContextMenuStrip(components);
      deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      likeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
      splitContainer.Panel1.SuspendLayout();
      splitContainer.Panel2.SuspendLayout();
      splitContainer.SuspendLayout();
      mnuMain.SuspendLayout();
      contextMenuStripListViewMessage.SuspendLayout();
      SuspendLayout();
      // 
      // listViewMessage
      // 
      listViewMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            msg,
            likes});
      listViewMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      listViewMessage.Location = new System.Drawing.Point(0, 0);
      listViewMessage.Name = "listViewMessage";
      listViewMessage.Size = new System.Drawing.Size(331, 195);
      listViewMessage.TabIndex = 10;
      listViewMessage.UseCompatibleStateImageBehavior = false;
      listViewMessage.View = System.Windows.Forms.View.Details;
      listViewMessage.SelectedIndexChanged += new System.EventHandler(listViewMessage_SelectedIndexChanged);
      listViewMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(listViewMessage_MouseClick);
      // 
      // msg
      // 
      msg.Text = "Message";
      msg.Width = 290;
      // 
      // likes
      // 
      likes.Text = "Likes";
      likes.Width = 38;
      // 
      // txtNewMessage
      // 
      txtNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      txtNewMessage.BorderWidth = 1F;
      txtNewMessage.FloatValue = 0D;
      txtNewMessage.Location = new System.Drawing.Point(145, 223);
      txtNewMessage.Name = "txtNewMessage";
      txtNewMessage.Size = new System.Drawing.Size(267, 21);
      txtNewMessage.TabIndex = 1;
      // 
      // lblNewMessage
      // 
      lblNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblNewMessage.AutoSize = true;
      lblNewMessage.BorderWidth = 1F;
      lblNewMessage.Location = new System.Drawing.Point(85, 226);
      lblNewMessage.Name = "lblNewMessage";
      lblNewMessage.Size = new System.Drawing.Size(56, 13);
      lblNewMessage.TabIndex = 2;
      lblNewMessage.Text = "Message :";
      // 
      // splitContainer
      // 
      splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      splitContainer.Location = new System.Drawing.Point(3, 24);
      splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      splitContainer.Panel1.Controls.Add(listViewRoomUsers);
      splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      splitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(splitContainer_Panel1_Paint);
      splitContainer.Panel1MinSize = 130;
      // 
      // splitContainer.Panel2
      // 
      splitContainer.Panel2.Controls.Add(listViewMessage);
      splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      splitContainer.Size = new System.Drawing.Size(477, 195);
      splitContainer.SplitterDistance = 137;
      splitContainer.TabIndex = 8;
      // 
      // listViewRoomUsers
      // 
      listViewRoomUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      listViewRoomUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colUserIcon,
            colUserName});
      listViewRoomUsers.Dock = System.Windows.Forms.DockStyle.Fill;
      listViewRoomUsers.FullRowSelect = true;
      listViewRoomUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      listViewRoomUsers.HideSelection = false;
      listViewRoomUsers.LabelWrap = false;
      listViewRoomUsers.Location = new System.Drawing.Point(0, 0);
      listViewRoomUsers.MultiSelect = false;
      listViewRoomUsers.Name = "listViewRoomUsers";
      listViewRoomUsers.RightToLeftLayout = true;
      listViewRoomUsers.Size = new System.Drawing.Size(137, 195);
      listViewRoomUsers.SmallImageList = imgList;
      listViewRoomUsers.TabIndex = 8;
      listViewRoomUsers.UseCompatibleStateImageBehavior = false;
      listViewRoomUsers.View = System.Windows.Forms.View.Details;
      listViewRoomUsers.SelectedIndexChanged += new System.EventHandler(listViewRoomUsers_SelectedIndexChanged);
      // 
      // colUserIcon
      // 
      colUserIcon.Text = "";
      colUserIcon.Width = 23;
      // 
      // colUserName
      // 
      colUserName.Text = "";
      colUserName.Width = 85;
      // 
      // imgList
      // 
      imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      imgList.TransparentColor = System.Drawing.Color.Transparent;
      imgList.Images.Add((Image)resources.GetObject("InLine.Image"));
      imgList.Images.SetKeyName(0, "Smiely.ico");
      imgList.Images.SetKeyName(1, "Private.ico");
      imgList.Images.SetKeyName(2, "SendMessage.ico");
      imgList.Images.SetKeyName(3, "Enter.ico");
      imgList.Images.SetKeyName(4, "Exit.ico");
      imgList.Images.SetKeyName(5, "InLine.png");
      // 
      // btnSend
      // 
      btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnSend.ImageKey = "SendMessage.ico";
      btnSend.ImageList = imgList;
      btnSend.Location = new System.Drawing.Point(417, 222);
      btnSend.Name = "btnSend";
      btnSend.Size = new System.Drawing.Size(67, 23);
      btnSend.TabIndex = 3;
      btnSend.Text = "Send";
      btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnSend.UseVisualStyleBackColor = true;
      btnSend.Click += new System.EventHandler(btnSend_Click);
      // 
      // mnuMain
      // 
      mnuMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mnuMain.BackgroundImage")));
      mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mniChat});
      mnuMain.Location = new System.Drawing.Point(0, 0);
      mnuMain.Name = "mnuMain";
      mnuMain.Size = new System.Drawing.Size(487, 24);
      mnuMain.TabIndex = 7;
      // 
      // mniChat
      // 
      mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mniSave,
            mniExit});
      mniChat.Name = "mniChat";
      mniChat.Size = new System.Drawing.Size(44, 20);
      mniChat.Text = "Chat";
      // 
      // mniSave
      // 
      mniSave.Image = ((System.Drawing.Image)(resources.GetObject("mniSave.Image")));
      mniSave.Name = "mniSave";
      mniSave.Size = new System.Drawing.Size(98, 22);
      mniSave.Text = "Save";
      mniSave.Click += new System.EventHandler(mniSave_Click);
      // 
      // mniExit
      // 
      mniExit.Image = ((System.Drawing.Image)(resources.GetObject("mniExit.Image")));
      mniExit.Name = "mniExit";
      mniExit.Size = new System.Drawing.Size(98, 22);
      mniExit.Text = "Exit";
      mniExit.Click += new System.EventHandler(mniExit_Click);
      // 
      // contextMenuStripListViewMessage
      // 
      contextMenuStripListViewMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            deleteToolStripMenuItem,
            likeToolStripMenuItem});
      contextMenuStripListViewMessage.Name = "contextMenuStripListViewMessage";
      contextMenuStripListViewMessage.Size = new System.Drawing.Size(108, 48);
      // 
      // deleteToolStripMenuItem
      // 
      deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      deleteToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
      deleteToolStripMenuItem.Text = "Delete";
      deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Garbage.Image")));
      deleteToolStripMenuItem.Click += new System.EventHandler(deleteToolStripMenuItem_Click);
      // 
      // likeToolStripMenuItem
      // 
      likeToolStripMenuItem.Name = "likeToolStripMenuItem";
      likeToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
      likeToolStripMenuItem.Text = "Like";
      likeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Like.Image")));
      likeToolStripMenuItem.Click += new System.EventHandler(likeToolStripMenuItem_Click);
      // 
      // RoomFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(487, 258);
      Controls.Add(btnSend);
      Controls.Add(lblNewMessage);
      Controls.Add(txtNewMessage);
      Controls.Add(mnuMain);
      Controls.Add(splitContainer);
      Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      MinimumSize = new System.Drawing.Size(354, 292);
      Name = "RoomFrm";
      ShowIcon = false;
      StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      Activated += new System.EventHandler(RoomFrm_Activated);
      Deactivate += new System.EventHandler(RoomFrm_Deactivate);
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(RoomFrm_FormClosing);
      Load += new System.EventHandler(RoomFrm_Load);
      splitContainer.Panel1.ResumeLayout(false);
      splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
      splitContainer.ResumeLayout(false);
      mnuMain.ResumeLayout(false);
      mnuMain.PerformLayout();
      contextMenuStripListViewMessage.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();

    }

    #endregion

    private Proshot.UtilityLib.TextBox txtNewMessage;
    private Proshot.UtilityLib.Label lblNewMessage;
    private Proshot.UtilityLib.Button btnSend;
    private System.Windows.Forms.ImageList imgList;
    private Proshot.UtilityLib.MenuStrip mnuMain;
    private System.Windows.Forms.ToolStripMenuItem mniChat;
    private System.Windows.Forms.ToolStripMenuItem mniSave;
    private System.Windows.Forms.ToolStripMenuItem mniExit;
    private Proshot.UtilityLib.ListView listViewRoomUsers;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ColumnHeader colUserIcon;
    private System.Windows.Forms.ColumnHeader colUserName;
    private System.Windows.Forms.ColumnHeader msg;
    private System.Windows.Forms.ColumnHeader likes;
    private System.Windows.Forms.ListView listViewMessage;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewMessage;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem likeToolStripMenuItem;
  }
}

