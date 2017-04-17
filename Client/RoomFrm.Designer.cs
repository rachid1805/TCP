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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomFrm));
      this.listViewMessage = new System.Windows.Forms.ListView();
      this.msg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.like = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.msgId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.txtNewMessage = new Proshot.UtilityLib.TextBox();
      this.lblNewMessage = new Proshot.UtilityLib.Label();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.listViewRoomUsers = new Proshot.UtilityLib.ListView();
      this.colUserIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.btnSend = new Proshot.UtilityLib.Button();
      this.mnuMain = new Proshot.UtilityLib.MenuStrip();
      this.mniChat = new System.Windows.Forms.ToolStripMenuItem();
      this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
      this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStripListViewMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.likeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.userName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.room = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.mnuMain.SuspendLayout();
      this.contextMenuStripListViewMessage.SuspendLayout();
      this.SuspendLayout();
      // 
      // listViewMessage
      // 
      this.listViewMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.msg,
            this.like,
            this.msgId,
            this.userName,
            this.room});
      this.listViewMessage.Location = new System.Drawing.Point(2, 0);
      this.listViewMessage.Name = "listViewMessage";
      this.listViewMessage.Size = new System.Drawing.Size(331, 195);
      this.listViewMessage.TabIndex = 10;
      this.listViewMessage.UseCompatibleStateImageBehavior = false;
      this.listViewMessage.View = System.Windows.Forms.View.Details;
      this.listViewMessage.SelectedIndexChanged += new System.EventHandler(this.listViewMessage_SelectedIndexChanged);
      this.listViewMessage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewMessage_MouseClick);
      // 
      // msg
      // 
      this.msg.Text = "Message";
      this.msg.Width = 250;
      // 
      // like
      // 
      this.like.Text = "Like";
      this.like.Width = 25;
      // 
      // msgId
      // 
      this.msgId.Text = "msgID";
      this.msgId.Width = 50;
      // 
      // txtNewMessage
      // 
      this.txtNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNewMessage.BorderWidth = 1F;
      this.txtNewMessage.FloatValue = 0D;
      this.txtNewMessage.Location = new System.Drawing.Point(145, 223);
      this.txtNewMessage.Name = "txtNewMessage";
      this.txtNewMessage.Size = new System.Drawing.Size(267, 21);
      this.txtNewMessage.TabIndex = 1;
      // 
      // lblNewMessage
      // 
      this.lblNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblNewMessage.AutoSize = true;
      this.lblNewMessage.BorderWidth = 1F;
      this.lblNewMessage.Location = new System.Drawing.Point(85, 226);
      this.lblNewMessage.Name = "lblNewMessage";
      this.lblNewMessage.Size = new System.Drawing.Size(56, 13);
      this.lblNewMessage.TabIndex = 2;
      this.lblNewMessage.Text = "Message :";
      // 
      // splitContainer
      // 
      this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer.Location = new System.Drawing.Point(3, 24);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.listViewRoomUsers);
      this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel1_Paint);
      this.splitContainer.Panel1MinSize = 130;
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.listViewMessage);
      this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer.Size = new System.Drawing.Size(477, 195);
      this.splitContainer.SplitterDistance = 137;
      this.splitContainer.TabIndex = 8;
      // 
      // listViewRoomUsers
      // 
      this.listViewRoomUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      this.listViewRoomUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUserIcon,
            this.colUserName});
      this.listViewRoomUsers.FullRowSelect = true;
      this.listViewRoomUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.listViewRoomUsers.HideSelection = false;
      this.listViewRoomUsers.LabelWrap = false;
      this.listViewRoomUsers.Location = new System.Drawing.Point(0, 0);
      this.listViewRoomUsers.MultiSelect = false;
      this.listViewRoomUsers.Name = "listViewRoomUsers";
      this.listViewRoomUsers.RightToLeftLayout = true;
      this.listViewRoomUsers.Size = new System.Drawing.Size(137, 195);
      this.listViewRoomUsers.SmallImageList = this.imgList;
      this.listViewRoomUsers.TabIndex = 8;
      this.listViewRoomUsers.UseCompatibleStateImageBehavior = false;
      this.listViewRoomUsers.View = System.Windows.Forms.View.Details;
      this.listViewRoomUsers.SelectedIndexChanged += new System.EventHandler(this.listViewRoomUsers_SelectedIndexChanged);
      // 
      // colUserIcon
      // 
      this.colUserIcon.Text = "";
      this.colUserIcon.Width = 23;
      // 
      // colUserName
      // 
      this.colUserName.Text = "";
      this.colUserName.Width = 85;
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Transparent;
      this.imgList.Images.SetKeyName(0, "Smiely.ico");
      this.imgList.Images.SetKeyName(1, "Private.ico");
      this.imgList.Images.SetKeyName(2, "SendMessage.ico");
      this.imgList.Images.SetKeyName(3, "Enter.ico");
      this.imgList.Images.SetKeyName(4, "Exit.ico");
      // 
      // btnSend
      // 
      this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnSend.ImageKey = "SendMessage.ico";
      this.btnSend.ImageList = this.imgList;
      this.btnSend.Location = new System.Drawing.Point(417, 222);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(67, 23);
      this.btnSend.TabIndex = 3;
      this.btnSend.Text = "Send";
      this.btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // mnuMain
      // 
      this.mnuMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mnuMain.BackgroundImage")));
      this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChat});
      this.mnuMain.Location = new System.Drawing.Point(0, 0);
      this.mnuMain.Name = "mnuMain";
      this.mnuMain.Size = new System.Drawing.Size(487, 24);
      this.mnuMain.TabIndex = 7;
      // 
      // mniChat
      // 
      this.mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSave,
            this.mniExit});
      this.mniChat.Name = "mniChat";
      this.mniChat.Size = new System.Drawing.Size(44, 20);
      this.mniChat.Text = "Chat";
      // 
      // mniSave
      // 
      this.mniSave.Image = ((System.Drawing.Image)(resources.GetObject("mniSave.Image")));
      this.mniSave.Name = "mniSave";
      this.mniSave.Size = new System.Drawing.Size(98, 22);
      this.mniSave.Text = "Save";
      this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
      // 
      // mniExit
      // 
      this.mniExit.Image = ((System.Drawing.Image)(resources.GetObject("mniExit.Image")));
      this.mniExit.Name = "mniExit";
      this.mniExit.Size = new System.Drawing.Size(98, 22);
      this.mniExit.Text = "Exit";
      this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
      // 
      // contextMenuStripListViewMessage
      // 
      this.contextMenuStripListViewMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.likeToolStripMenuItem});
      this.contextMenuStripListViewMessage.Name = "contextMenuStripListViewMessage";
      this.contextMenuStripListViewMessage.Size = new System.Drawing.Size(108, 48);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // likeToolStripMenuItem
      // 
      this.likeToolStripMenuItem.Name = "likeToolStripMenuItem";
      this.likeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.likeToolStripMenuItem.Text = "Like";
      this.likeToolStripMenuItem.Click += new System.EventHandler(this.likeToolStripMenuItem_Click);
      // 
      // userName
      // 
      this.userName.Text = "user";
      this.userName.Width = 0;
      // 
      // room
      // 
      this.room.Text = "room";
      this.room.Width = 0;
      // 
      // RoomFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(487, 258);
      this.Controls.Add(this.btnSend);
      this.Controls.Add(this.lblNewMessage);
      this.Controls.Add(this.txtNewMessage);
      this.Controls.Add(this.mnuMain);
      this.Controls.Add(this.splitContainer);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      this.MinimumSize = new System.Drawing.Size(354, 292);
      this.Name = "RoomFrm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Activated += new System.EventHandler(this.RoomFrm_Activated);
      this.Deactivate += new System.EventHandler(this.RoomFrm_Deactivate);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomFrm_FormClosing);
      this.Load += new System.EventHandler(this.RoomFrm_Load);
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.mnuMain.ResumeLayout(false);
      this.mnuMain.PerformLayout();
      this.contextMenuStripListViewMessage.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

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
    private System.Windows.Forms.ColumnHeader like;
    private System.Windows.Forms.ColumnHeader msgId;
    private System.Windows.Forms.ListView listViewMessage;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripListViewMessage;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem likeToolStripMenuItem;
    private System.Windows.Forms.ColumnHeader userName;
    private System.Windows.Forms.ColumnHeader room;
  }
}

