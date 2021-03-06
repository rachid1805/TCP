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
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
      imgList = new System.Windows.Forms.ImageList(components);
      btnConnectToRoom = new Proshot.UtilityLib.Button();
      txtHowToConnectToRoom = new Proshot.UtilityLib.TextBox();
      mnuMain = new Proshot.UtilityLib.MenuStrip();
      mniChat = new System.Windows.Forms.ToolStripMenuItem();
      mniSignup = new System.Windows.Forms.ToolStripMenuItem();
      mniEnter = new System.Windows.Forms.ToolStripMenuItem();
      mniCreateRoom = new System.Windows.Forms.ToolStripMenuItem();
      mniConnectToRoom = new System.Windows.Forms.ToolStripMenuItem();
      mniConnectMyProfile = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      mniExit = new System.Windows.Forms.ToolStripMenuItem();
      splitContainer = new System.Windows.Forms.SplitContainer();
      lstViwUsers = new Proshot.UtilityLib.ListView();
      colUserIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      lstViwRooms = new Proshot.UtilityLib.ListView();
      colRoomIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      colRoomUsers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      colRoomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      colRoomDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      mnuMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
      splitContainer.Panel1.SuspendLayout();
      splitContainer.Panel2.SuspendLayout();
      splitContainer.SuspendLayout();
      SuspendLayout();
      // 
      // imgList
      // 
      imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      imgList.TransparentColor = System.Drawing.Color.Transparent;
      imgList.Images.Add((Image)resources.GetObject("InLine.Image"));
      imgList.Images.Add((Image)resources.GetObject("OffLine.Image"));
      imgList.Images.Add((Image)resources.GetObject("mniConnectToRoom.Image"));
      imgList.Images.SetKeyName(0, "Smiely.png");
      imgList.Images.SetKeyName(1, "Private.ico");
      imgList.Images.SetKeyName(2, "SendMessage.ico");
      imgList.Images.SetKeyName(3, "Enter.ico");
      imgList.Images.SetKeyName(4, "Exit.ico");
      imgList.Images.SetKeyName(5, "InLine.png");
      imgList.Images.SetKeyName(6, "OffLine.png");
      imgList.Images.SetKeyName(7, "Chat.png");
      // 
      // btnConnectToRoom
      // 
      btnConnectToRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      btnConnectToRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnConnectToRoom.ImageKey = "Chat.png";
      btnConnectToRoom.ImageList = imgList;
      btnConnectToRoom.Location = new System.Drawing.Point(6, 424);
      btnConnectToRoom.Name = "btnConnectToRoom";
      btnConnectToRoom.Size = new System.Drawing.Size(123, 23);
      btnConnectToRoom.TabIndex = 6;
      btnConnectToRoom.Text = "Connect to Room";
      btnConnectToRoom.UseVisualStyleBackColor = true;
      btnConnectToRoom.Click += new System.EventHandler(btnConnectToRoom_Click);
      // 
      // txtHowToConnectToRoom
      // 
      txtHowToConnectToRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      txtHowToConnectToRoom.BorderWidth = 1F;
      txtHowToConnectToRoom.Enabled = false;
      txtHowToConnectToRoom.FloatValue = 0D;
      txtHowToConnectToRoom.Location = new System.Drawing.Point(275, 427);
      txtHowToConnectToRoom.Name = "txtHowToConnectToRoom";
      txtHowToConnectToRoom.Size = new System.Drawing.Size(300, 21);
      txtHowToConnectToRoom.TabIndex = 1;
      txtHowToConnectToRoom.Text = "  To connect to a chat room, double-click on the room name";
      // 
      // mnuMain
      // 
      mnuMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mnuMain.BackgroundImage")));
      mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mniChat});
      mnuMain.Location = new System.Drawing.Point(0, 0);
      mnuMain.Name = "mnuMain";
      mnuMain.Size = new System.Drawing.Size(635, 24);
      mnuMain.TabIndex = 7;
      // 
      // mniChat
      // 
      mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mniSignup,
            mniEnter,
            mniCreateRoom,
            mniConnectToRoom,
            mniConnectMyProfile,
            toolStripMenuItem1,
            mniExit});
      mniChat.Name = "mniChat";
      mniChat.Size = new System.Drawing.Size(44, 20);
      mniChat.Text = "Chat";
      // 
      // mniSignup
      // 
      mniSignup.Image = ((System.Drawing.Image)(resources.GetObject("mniSignup.Image")));
      mniSignup.Name = "mniSignup";
      mniSignup.Size = new System.Drawing.Size(168, 22);
      mniSignup.Text = "Sign up";
      mniSignup.Click += new System.EventHandler(mniSignup_Click);
      // 
      // mniEnter
      // 
      mniEnter.Image = ((System.Drawing.Image)(resources.GetObject("mniEnter.Image")));
      mniEnter.Name = "mniEnter";
      mniEnter.Size = new System.Drawing.Size(168, 22);
      mniEnter.Text = "Login";
      mniEnter.Click += new System.EventHandler(mniEnter_Click);
      // 
      // mniCreateRoom
      // 
      mniCreateRoom.Enabled = false;
      mniCreateRoom.Image = ((System.Drawing.Image)(resources.GetObject("mniCreateRoom.Image")));
      mniCreateRoom.Name = "mniCreateRoom";
      mniCreateRoom.Size = new System.Drawing.Size(168, 22);
      mniCreateRoom.Text = "Create Room";
      mniCreateRoom.Click += new System.EventHandler(mniCreateRoom_Click);
      // 
      // mniConnectToRoom
      // 
      mniConnectToRoom.Image = ((System.Drawing.Image)(resources.GetObject("mniConnectToRoom.Image")));
      mniConnectToRoom.Name = "mniConnectToRoom";
      mniConnectToRoom.Size = new System.Drawing.Size(168, 22);
      mniConnectToRoom.Text = "Connect to Room";
      mniConnectToRoom.Click += new System.EventHandler(mniConnectToRoom_Click);
      // 
      // mniConnectMyProfile
      // 
      mniConnectMyProfile.Enabled = false;
      mniConnectMyProfile.Image = ((System.Drawing.Image)(resources.GetObject("mniConnectMyProfile.Image")));
      mniConnectMyProfile.Name = "mniConnectMyProfile";
      mniConnectMyProfile.Size = new System.Drawing.Size(168, 22);
      mniConnectMyProfile.Text = "My Profile";
      mniConnectMyProfile.Click += new System.EventHandler(mniConnectMyProfile_Click);
      // 
      // toolStripMenuItem1
      // 
      toolStripMenuItem1.Name = "toolStripMenuItem1";
      toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
      // 
      // mniExit
      // 
      mniExit.Image = ((System.Drawing.Image)(resources.GetObject("mniExit.Image")));
      mniExit.Name = "mniExit";
      mniExit.Size = new System.Drawing.Size(168, 22);
      mniExit.Text = "Exit";
      mniExit.Click += new System.EventHandler(mniExit_Click);
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
      splitContainer.Panel1.Controls.Add(lstViwUsers);
      splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
      splitContainer.Panel1MinSize = 130;
      // 
      // splitContainer.Panel2
      // 
      splitContainer.Panel2.Controls.Add(lstViwRooms);
      splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      splitContainer.Size = new System.Drawing.Size(627, 394);
      splitContainer.SplitterDistance = 130;
      splitContainer.TabIndex = 8;
      // 
      // lstViwUsers
      // 
      lstViwUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
      lstViwUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      lstViwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colUserIcon,
            colUserName});
      lstViwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
      lstViwUsers.FullRowSelect = true;
      lstViwUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      lstViwUsers.HideSelection = false;
      lstViwUsers.LabelWrap = false;
      lstViwUsers.Location = new System.Drawing.Point(0, 0);
      lstViwUsers.MultiSelect = false;
      lstViwUsers.Name = "lstViwUsers";
      lstViwUsers.RightToLeftLayout = true;
      lstViwUsers.Size = new System.Drawing.Size(130, 394);
      lstViwUsers.SmallImageList = imgList;
      lstViwUsers.TabIndex = 8;
      lstViwUsers.UseCompatibleStateImageBehavior = false;
      lstViwUsers.View = System.Windows.Forms.View.Details;
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
      // lstViwRooms
      // 
      lstViwRooms.Activation = System.Windows.Forms.ItemActivation.OneClick;
      lstViwRooms.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      lstViwRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colRoomIcon,
            colRoomName,
            colRoomDescription,
            colRoomUsers});
      lstViwRooms.Dock = System.Windows.Forms.DockStyle.Fill;
      lstViwRooms.FullRowSelect = true;
      lstViwRooms.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      lstViwRooms.HideSelection = false;
      lstViwRooms.LabelWrap = false;
      lstViwRooms.Location = new System.Drawing.Point(0, 0);
      lstViwRooms.MultiSelect = false;
      lstViwRooms.Name = "lstViwRooms";
      lstViwRooms.RightToLeftLayout = true;
      lstViwRooms.Size = new System.Drawing.Size(493, 394);
      lstViwRooms.SmallImageList = imgList;
      lstViwRooms.TabIndex = 8;
      lstViwRooms.UseCompatibleStateImageBehavior = false;
      lstViwRooms.View = System.Windows.Forms.View.Details;
      lstViwRooms.DoubleClick += new System.EventHandler(btnConnectToRoom_Click);
      // 
      // colRoomIcon
      // 
      colRoomIcon.Text = "";
      colRoomIcon.Width = 23;
      // 
      // colRoomName
      // 
      colRoomName.Text = "Room Name";
      colRoomName.Width = 75;
      // 
      // colRoomDescription
      // 
      colRoomDescription.Text = "Room Description";
      colRoomDescription.Width = 350;
      // 
      // colRoomUsers
      // 
      colRoomUsers.Text = "Users";
      colRoomUsers.Width = 50;
      // 
      // MainFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(635, 459);
      Controls.Add(splitContainer);
      Controls.Add(btnConnectToRoom);
      Controls.Add(txtHowToConnectToRoom);
      Controls.Add(mnuMain);
      Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      MinimumSize = new System.Drawing.Size(643, 493);
      Name = "MainFrm";
      RightToLeft = System.Windows.Forms.RightToLeft.No;
      RightToLeftLayout = true;
      ShowIcon = false;
      StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      Text = "Offline";
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainFrm_FormClosing);
      mnuMain.ResumeLayout(false);
      mnuMain.PerformLayout();
      splitContainer.Panel1.ResumeLayout(false);
      splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
      splitContainer.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();

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
    private System.Windows.Forms.ColumnHeader colRoomUsers;
    private System.Windows.Forms.ColumnHeader colRoomName;
    private System.Windows.Forms.ColumnHeader colRoomDescription;
    private System.Windows.Forms.ToolStripMenuItem mniConnectToRoom;
  }
}

