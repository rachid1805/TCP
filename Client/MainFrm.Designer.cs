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
      txtNewMessage = new Proshot.UtilityLib.TextBox();
      cnxMnuEdit = new Proshot.UtilityLib.ContextMenuStrip();
      mniCopy = new System.Windows.Forms.ToolStripMenuItem();
      mniPaste = new System.Windows.Forms.ToolStripMenuItem();
      lblNewMessage = new Proshot.UtilityLib.Label();
      btnSend = new Proshot.UtilityLib.Button();
      imgList = new System.Windows.Forms.ImageList(components);
      btnConnectToRoom = new Proshot.UtilityLib.Button();
      mnuMain = new Proshot.UtilityLib.MenuStrip();
      mniChat = new System.Windows.Forms.ToolStripMenuItem();
      mniSignup = new System.Windows.Forms.ToolStripMenuItem();
      mniEnter = new System.Windows.Forms.ToolStripMenuItem();
      mniRoomConnect = new System.Windows.Forms.ToolStripMenuItem();
      mniSave = new System.Windows.Forms.ToolStripMenuItem();
      toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      mniExit = new System.Windows.Forms.ToolStripMenuItem();
      splitContainer = new System.Windows.Forms.SplitContainer();
      lstViwUsers = new Proshot.UtilityLib.ListView();
      colIcon = new System.Windows.Forms.ColumnHeader();
      colUserName = new System.Windows.Forms.ColumnHeader();
      txtMessages = new System.Windows.Forms.RichTextBox();
      cnxMniCopy = new Proshot.UtilityLib.ContextMenuStrip();
      mniCopyText = new System.Windows.Forms.ToolStripMenuItem();
      cnxMnuEdit.SuspendLayout();
      mnuMain.SuspendLayout();
      splitContainer.Panel1.SuspendLayout();
      splitContainer.Panel2.SuspendLayout();
      splitContainer.SuspendLayout();
      cnxMniCopy.SuspendLayout();
      SuspendLayout();
      // 
      // txtNewMessage
      // 
      txtNewMessage.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      txtNewMessage.BorderWidth = 1F;
      txtNewMessage.ContextMenuStrip = cnxMnuEdit;
      txtNewMessage.FloatValue = 0;
      txtNewMessage.Location = new System.Drawing.Point(204 , 427);
      txtNewMessage.Name = "txtNewMessage";
      txtNewMessage.Size = new System.Drawing.Size(353 , 21);
      txtNewMessage.TabIndex = 1;
      // 
      // cnxMnuEdit
      // 
      cnxMnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem [] {
      mniCopy,
      mniPaste});
      cnxMnuEdit.Name = "cnxMnuEdit";
      cnxMnuEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      cnxMnuEdit.Size = new System.Drawing.Size(130 , 48);
      // 
      // mniCopy
      // 
      mniCopy.Name = "mniCopy";
      mniCopy.Size = new System.Drawing.Size(129 , 22);
      mniCopy.Text = "کپی متن";
      mniCopy.Click += new System.EventHandler(mniCopy_Click);
      // 
      // mniPaste
      // 
      mniPaste.Name = "mniPaste";
      mniPaste.Size = new System.Drawing.Size(129 , 22);
      mniPaste.Text = "انداختن متن";
      mniPaste.Click += new System.EventHandler(mniPaste_Click);
      // 
      // lblNewMessage
      // 
      lblNewMessage.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      lblNewMessage.AutoSize = true;
      lblNewMessage.BorderWidth = 1F;
      lblNewMessage.Location = new System.Drawing.Point(137 , 430);
      lblNewMessage.Name = "lblNewMessage";
      lblNewMessage.Size = new System.Drawing.Size(56 , 13);
      lblNewMessage.TabIndex = 2;
      lblNewMessage.Text = "Message :";
      // 
      // btnSend
      // 
      btnSend.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnSend.ImageKey = "SendMessage.ico";
      btnSend.ImageList = imgList;
      btnSend.Location = new System.Drawing.Point(563 , 426);
      btnSend.Name = "btnSend";
      btnSend.Size = new System.Drawing.Size(67 , 23);
      btnSend.TabIndex = 3;
      btnSend.Text = "Send";
      btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnSend.UseVisualStyleBackColor = true;
      btnSend.Click += new System.EventHandler(btnSend_Click);
      // 
      // imgList
      // 
      imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      imgList.TransparentColor = System.Drawing.Color.Transparent;
      imgList.Images.Add((Image)resources.GetObject("InLine.Image"));
      imgList.Images.Add((Image)resources.GetObject("OffLine.Image"));
      imgList.Images.SetKeyName(0, "Smiely.png");
      imgList.Images.SetKeyName(1, "Private.ico");
      imgList.Images.SetKeyName(2, "SendMessage.ico");
      imgList.Images.SetKeyName(3, "Enter.ico");
      imgList.Images.SetKeyName(4, "Exit.ico");
      imgList.Images.SetKeyName(5, "InLine.png");
      imgList.Images.SetKeyName(6, "OffLine.png");
      // 
      // btnConnectToRoom
      // 
      btnConnectToRoom.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      btnConnectToRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnConnectToRoom.ImageKey = "Private.ico";
      btnConnectToRoom.ImageList = imgList;
      btnConnectToRoom.Location = new System.Drawing.Point(6 , 424);
      btnConnectToRoom.Name = "btnbtnConnectToRoom";
      btnConnectToRoom.Size = new System.Drawing.Size(123 , 23);
      btnConnectToRoom.TabIndex = 6;
      btnConnectToRoom.Text = "Room Connect";
      btnConnectToRoom.UseVisualStyleBackColor = true;
      btnConnectToRoom.Click += new System.EventHandler(btnConnectToRoom_Click);
      // 
      // mnuMain
      // 
      mnuMain.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject("mnuMain.BackgroundImage") ) );
      mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
      {
        mniChat
      });
      mnuMain.Location = new System.Drawing.Point(0 , 0);
      mnuMain.Name = "mnuMain";
      mnuMain.Size = new System.Drawing.Size(635 , 24);
      mnuMain.TabIndex = 7;
      // 
      // mniChat
      // 
      mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
      {
        mniSignup,
        mniEnter,
        mniRoomConnect,
        mniSave,
        toolStripMenuItem1,
        mniExit
      });
      mniChat.Name = "mniChat";
      mniChat.Size = new System.Drawing.Size(42 , 20);
      mniChat.Text = "Chat";
      // 
      // mniSignup
      // 
      mniSignup.Image = ((System.Drawing.Image)(resources.GetObject("mniSignup.Image")));
      mniSignup.Name = "mniSignup";
      mniSignup.Size = new System.Drawing.Size(152, 22);
      mniSignup.Text = "Sign up";
      mniSignup.Click += new System.EventHandler(mniSignup_Click);
      // 
      // mniEnter
      // 
      mniEnter.Image = ( (System.Drawing.Image)( resources.GetObject("mniEnter.Image") ) );
      mniEnter.Name = "mniEnter";
      mniEnter.Size = new System.Drawing.Size(152 , 22);
      mniEnter.Text = "Login";
      mniEnter.Click += new System.EventHandler(mniEnter_Click);
      // 
      // mniRoomConnect
      // 
      mniRoomConnect.Image = ( (System.Drawing.Image)( resources.GetObject("mniPrivate.Image") ) );
      mniRoomConnect.Name = "mniRoomConnect";
      mniRoomConnect.Size = new System.Drawing.Size(152 , 22);
      mniRoomConnect.Text = "Room Connect";
      mniRoomConnect.Click += new System.EventHandler(mniRoomConnect_Click);
      // 
      // mniSave
      // 
      mniSave.Image = ( (System.Drawing.Image)( resources.GetObject("mniSave.Image") ) );
      mniSave.Name = "mniSave";
      mniSave.Size = new System.Drawing.Size(152 , 22);
      mniSave.Text = "Save";
      mniSave.Click += new System.EventHandler(mniSave_Click);
      // 
      // toolStripMenuItem1
      // 
      toolStripMenuItem1.Name = "toolStripMenuItem1";
      toolStripMenuItem1.Size = new System.Drawing.Size(149 , 6);
      // 
      // mniExit
      // 
      mniExit.Image = ( (System.Drawing.Image)( resources.GetObject("mniExit.Image") ) );
      mniExit.Name = "mniExit";
      mniExit.Size = new System.Drawing.Size(152 , 22);
      mniExit.Text = "Exit";
      mniExit.Click += new System.EventHandler(mniExit_Click);
      // 
      // splitContainer
      // 
      splitContainer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      splitContainer.Location = new System.Drawing.Point(3 , 24);
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
      splitContainer.Panel2.Controls.Add(txtMessages);
      splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      splitContainer.Size = new System.Drawing.Size(627 , 394);
      splitContainer.SplitterDistance = 130;
      splitContainer.TabIndex = 8;
      // 
      // lstViwUsers
      // 
      lstViwUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
      lstViwUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      lstViwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader [] {
      colIcon,
      colUserName});
      lstViwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
      lstViwUsers.FullRowSelect = true;
      lstViwUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      lstViwUsers.HideSelection = false;
      lstViwUsers.LabelWrap = false;
      lstViwUsers.Location = new System.Drawing.Point(0 , 0);
      lstViwUsers.MultiSelect = false;
      lstViwUsers.Name = "lstViwUsers";
      lstViwUsers.RightToLeftLayout = true;
      lstViwUsers.Size = new System.Drawing.Size(130 , 394);
      lstViwUsers.SmallImageList = imgList;
      lstViwUsers.TabIndex = 8;
      lstViwUsers.UseCompatibleStateImageBehavior = false;
      lstViwUsers.View = System.Windows.Forms.View.Details;
      lstViwUsers.DoubleClick += new System.EventHandler(btnConnectToRoom_Click);
      // 
      // colIcon
      // 
      colIcon.Text = "";
      colIcon.Width = 23;
      // 
      // colUserName
      // 
      colUserName.Text = "";
      colUserName.Width = 85;
      // 
      // txtMessages
      // 
      txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      txtMessages.ContextMenuStrip = cnxMniCopy;
      txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      txtMessages.Location = new System.Drawing.Point(0 , 0);
      txtMessages.Name = "txtMessages";
      txtMessages.Size = new System.Drawing.Size(493 , 394);
      txtMessages.TabIndex = 9;
      txtMessages.Text = "";
      // 
      // cnxMniCopy
      // 
      cnxMniCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem [] {
      mniCopyText});
      cnxMniCopy.Name = "cnxMniCopy";
      cnxMniCopy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      cnxMniCopy.Size = new System.Drawing.Size(116 , 26);
      // 
      // mniCopyText
      // 
      mniCopyText.Name = "mniCopyText";
      mniCopyText.Size = new System.Drawing.Size(115 , 22);
      mniCopyText.Text = "کپی متن";
      mniCopyText.Click += new System.EventHandler(mniCopyText_Click);
      // 
      // MainFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(6F , 13F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(635 , 459);
      Controls.Add(splitContainer);
      Controls.Add(btnConnectToRoom);
      Controls.Add(txtNewMessage);
      Controls.Add(btnSend);
      Controls.Add(lblNewMessage);
      Controls.Add(mnuMain);
      Font = new System.Drawing.Font("Tahoma" , 8.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 177 ) ));
      MinimumSize = new System.Drawing.Size(643 , 493);
      Name = "MainFrm";
      RightToLeft = System.Windows.Forms.RightToLeft.No;
      RightToLeftLayout = true;
      ShowIcon = false;
      StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      Text = "Chat System";
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(MainFrm_FormClosing);
      cnxMnuEdit.ResumeLayout(false);
      mnuMain.ResumeLayout(false);
      mnuMain.PerformLayout();
      splitContainer.Panel1.ResumeLayout(false);
      splitContainer.Panel2.ResumeLayout(false);
      splitContainer.ResumeLayout(false);
      cnxMniCopy.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Proshot.UtilityLib.TextBox txtNewMessage;
    private Proshot.UtilityLib.Label lblNewMessage;
    private Proshot.UtilityLib.Button btnSend;
    private Proshot.UtilityLib.Button btnConnectToRoom;
    private System.Windows.Forms.ImageList imgList;
    private Proshot.UtilityLib.MenuStrip mnuMain;
    private System.Windows.Forms.ToolStripMenuItem mniChat;
    private System.Windows.Forms.ToolStripMenuItem mniSignup;
    private System.Windows.Forms.ToolStripMenuItem mniEnter;
    private System.Windows.Forms.ToolStripMenuItem mniSave;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem mniExit;
    private System.Windows.Forms.ToolStripMenuItem mniRoomConnect;
    private System.Windows.Forms.SplitContainer splitContainer;
    private Proshot.UtilityLib.ListView lstViwUsers;
    private System.Windows.Forms.ColumnHeader colIcon;
    private System.Windows.Forms.ColumnHeader colUserName;
    private System.Windows.Forms.RichTextBox txtMessages;
    private Proshot.UtilityLib.ContextMenuStrip cnxMnuEdit;
    private System.Windows.Forms.ToolStripMenuItem mniCopy;
    private System.Windows.Forms.ToolStripMenuItem mniPaste;
    private Proshot.UtilityLib.ContextMenuStrip cnxMniCopy;
    private System.Windows.Forms.ToolStripMenuItem mniCopyText;
  }
}

