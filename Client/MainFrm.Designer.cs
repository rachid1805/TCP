using System.Drawing;

namespace Client
{
  partial class MainFrm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.btnConnectToRoom = new Proshot.UtilityLib.Button();
      this.txtHowToConnectToRoom = new Proshot.UtilityLib.TextBox();
      this.mnuMain = new Proshot.UtilityLib.MenuStrip();
      this.mniChat = new System.Windows.Forms.ToolStripMenuItem();
      this.mniSignup = new System.Windows.Forms.ToolStripMenuItem();
      this.mniEnter = new System.Windows.Forms.ToolStripMenuItem();
      this.mniCreateRoom = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
      this.mniConnectMyProfile = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.lstViwUsers = new Proshot.UtilityLib.ListView();
      this.colUserIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lstViwRooms = new Proshot.UtilityLib.ListView();
      this.colRoomIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colRoomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colRoomDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.mnuMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Transparent;
      this.imgList.Images.SetKeyName(0, "Smiely.png");
      this.imgList.Images.SetKeyName(1, "Private.ico");
      this.imgList.Images.SetKeyName(2, "SendMessage.ico");
      this.imgList.Images.SetKeyName(3, "Enter.ico");
      this.imgList.Images.SetKeyName(4, "Exit.ico");
      // 
      // btnConnectToRoom
      // 
      this.btnConnectToRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnConnectToRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnConnectToRoom.ImageKey = "Chat.png";
      this.btnConnectToRoom.ImageList = this.imgList;
      this.btnConnectToRoom.Location = new System.Drawing.Point(6, 424);
      this.btnConnectToRoom.Name = "btnConnectToRoom";
      this.btnConnectToRoom.Size = new System.Drawing.Size(123, 23);
      this.btnConnectToRoom.TabIndex = 6;
      this.btnConnectToRoom.Text = "Connect to Room";
      this.btnConnectToRoom.UseVisualStyleBackColor = true;
      this.btnConnectToRoom.Click += new System.EventHandler(this.btnConnectToRoom_Click);
      // 
      // txtHowToConnectToRoom
      // 
      this.txtHowToConnectToRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtHowToConnectToRoom.BorderWidth = 1F;
      this.txtHowToConnectToRoom.Enabled = false;
      this.txtHowToConnectToRoom.FloatValue = 0D;
      this.txtHowToConnectToRoom.Location = new System.Drawing.Point(275, 427);
      this.txtHowToConnectToRoom.Name = "txtHowToConnectToRoom";
      this.txtHowToConnectToRoom.Size = new System.Drawing.Size(300, 21);
      this.txtHowToConnectToRoom.TabIndex = 1;
      this.txtHowToConnectToRoom.Text = "  To connect to a chat room, double-click on the room name";
      // 
      // mnuMain
      // 
      this.mnuMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mnuMain.BackgroundImage")));
      this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChat});
      this.mnuMain.Location = new System.Drawing.Point(0, 0);
      this.mnuMain.Name = "mnuMain";
      this.mnuMain.Size = new System.Drawing.Size(635, 24);
      this.mnuMain.TabIndex = 7;
      // 
      // mniChat
      // 
      this.mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniSignup,
            this.mniEnter,
            this.mniCreateRoom,
            this.toolStripMenuItem2,
            this.mniConnectMyProfile,
            this.toolStripMenuItem1,
            this.mniExit});
      this.mniChat.Name = "mniChat";
      this.mniChat.Size = new System.Drawing.Size(44, 20);
      this.mniChat.Text = "Chat";
      // 
      // mniSignup
      // 
      this.mniSignup.Image = ((System.Drawing.Image)(resources.GetObject("mniSignup.Image")));
      this.mniSignup.Name = "mniSignup";
      this.mniSignup.Size = new System.Drawing.Size(168, 22);
      this.mniSignup.Text = "Sign up";
      this.mniSignup.Click += new System.EventHandler(this.mniSignup_Click);
      // 
      // mniEnter
      // 
      this.mniEnter.Image = ((System.Drawing.Image)(resources.GetObject("mniEnter.Image")));
      this.mniEnter.Name = "mniEnter";
      this.mniEnter.Size = new System.Drawing.Size(168, 22);
      this.mniEnter.Text = "Login";
      this.mniEnter.Click += new System.EventHandler(this.mniEnter_Click);
      // 
      // mniCreateRoom
      // 
      this.mniCreateRoom.Enabled = false;
      this.mniCreateRoom.Image = ((System.Drawing.Image)(resources.GetObject("mniCreateRoom.Image")));
      this.mniCreateRoom.Name = "mniCreateRoom";
      this.mniCreateRoom.Size = new System.Drawing.Size(168, 22);
      this.mniCreateRoom.Text = "Create Room";
      this.mniCreateRoom.Click += new System.EventHandler(this.mniCreateRoom_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 22);
      this.toolStripMenuItem2.Text = "Connect to Room";
      this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
      // 
      // mniConnectMyProfile
      // 
      this.mniConnectMyProfile.Enabled = false;
      this.mniConnectMyProfile.Image = ((System.Drawing.Image)(resources.GetObject("mniConnectMyProfile.Image")));
      this.mniConnectMyProfile.Name = "mniConnectMyProfile";
      this.mniConnectMyProfile.Size = new System.Drawing.Size(168, 22);
      this.mniConnectMyProfile.Text = "My Profile";
      this.mniConnectMyProfile.Click += new System.EventHandler(this.mniConnectMyProfile_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
      // 
      // mniExit
      // 
      this.mniExit.Image = ((System.Drawing.Image)(resources.GetObject("mniExit.Image")));
      this.mniExit.Name = "mniExit";
      this.mniExit.Size = new System.Drawing.Size(168, 22);
      this.mniExit.Text = "Exit";
      this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
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
      this.splitContainer.Panel1.Controls.Add(this.lstViwUsers);
      this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer.Panel1MinSize = 130;
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.lstViwRooms);
      this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.splitContainer.Size = new System.Drawing.Size(627, 394);
      this.splitContainer.SplitterDistance = 130;
      this.splitContainer.TabIndex = 8;
      // 
      // lstViwUsers
      // 
      this.lstViwUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.lstViwUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      this.lstViwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUserIcon,
            this.colUserName});
      this.lstViwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstViwUsers.FullRowSelect = true;
      this.lstViwUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lstViwUsers.HideSelection = false;
      this.lstViwUsers.LabelWrap = false;
      this.lstViwUsers.Location = new System.Drawing.Point(0, 0);
      this.lstViwUsers.MultiSelect = false;
      this.lstViwUsers.Name = "lstViwUsers";
      this.lstViwUsers.RightToLeftLayout = true;
      this.lstViwUsers.Size = new System.Drawing.Size(130, 394);
      this.lstViwUsers.SmallImageList = this.imgList;
      this.lstViwUsers.TabIndex = 8;
      this.lstViwUsers.UseCompatibleStateImageBehavior = false;
      this.lstViwUsers.View = System.Windows.Forms.View.Details;
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
      // lstViwRooms
      // 
      this.lstViwRooms.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.lstViwRooms.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      this.lstViwRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRoomIcon,
            this.colRoomName,
            this.colRoomDescription});
      this.lstViwRooms.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstViwRooms.FullRowSelect = true;
      this.lstViwRooms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.lstViwRooms.HideSelection = false;
      this.lstViwRooms.LabelWrap = false;
      this.lstViwRooms.Location = new System.Drawing.Point(0, 0);
      this.lstViwRooms.MultiSelect = false;
      this.lstViwRooms.Name = "lstViwRooms";
      this.lstViwRooms.RightToLeftLayout = true;
      this.lstViwRooms.Size = new System.Drawing.Size(493, 394);
      this.lstViwRooms.SmallImageList = this.imgList;
      this.lstViwRooms.TabIndex = 8;
      this.lstViwRooms.UseCompatibleStateImageBehavior = false;
      this.lstViwRooms.View = System.Windows.Forms.View.Details;
      this.lstViwRooms.DoubleClick += new System.EventHandler(this.btnConnectToRoom_Click);
      // 
      // colRoomIcon
      // 
      this.colRoomIcon.Text = "";
      this.colRoomIcon.Width = 23;
      // 
      // colRoomName
      // 
      this.colRoomName.Text = "Room Name";
      this.colRoomName.Width = 100;
      // 
      // colRoomDescription
      // 
      this.colRoomDescription.Text = "Room Description";
      this.colRoomDescription.Width = 500;
      // 
      // MainFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(635, 459);
      this.Controls.Add(this.splitContainer);
      this.Controls.Add(this.btnConnectToRoom);
      this.Controls.Add(this.txtHowToConnectToRoom);
      this.Controls.Add(this.mnuMain);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      this.MinimumSize = new System.Drawing.Size(643, 493);
      this.Name = "MainFrm";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.RightToLeftLayout = true;
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Offline";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
      this.mnuMain.ResumeLayout(false);
      this.mnuMain.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Proshot.UtilityLib.Button btnConnectToRoom;
    private Proshot.UtilityLib.TextBox txtHowToConnectToRoom;
    private System.Windows.Forms.ImageList imgList;
    private Proshot.UtilityLib.MenuStrip mnuMain;
    private System.Windows.Forms.ToolStripMenuItem mniChat;
    private System.Windows.Forms.ToolStripMenuItem mniSignup;
    private System.Windows.Forms.ToolStripMenuItem mniEnter;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem mniExit;
    private System.Windows.Forms.ToolStripMenuItem mniCreateRoom;
    private System.Windows.Forms.ToolStripMenuItem mniConnectMyProfile;
    private System.Windows.Forms.SplitContainer splitContainer;
    private Proshot.UtilityLib.ListView lstViwUsers;
    private Proshot.UtilityLib.ListView lstViwRooms;
    private System.Windows.Forms.ColumnHeader colUserIcon;
    private System.Windows.Forms.ColumnHeader colUserName;
    private System.Windows.Forms.ColumnHeader colRoomIcon;
    private System.Windows.Forms.ColumnHeader colRoomName;
    private System.Windows.Forms.ColumnHeader colRoomDescription;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

