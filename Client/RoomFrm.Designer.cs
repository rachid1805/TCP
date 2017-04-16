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
      txtNewMessage = new Proshot.UtilityLib.TextBox();
      lblNewMessage = new Proshot.UtilityLib.Label();
      splitContainer = new System.Windows.Forms.SplitContainer();
      colUserIcon = new System.Windows.Forms.ColumnHeader();
      colUserName = new System.Windows.Forms.ColumnHeader();
      btnSend = new Proshot.UtilityLib.Button();
      imgList = new System.Windows.Forms.ImageList(components);
      mnuMain = new Proshot.UtilityLib.MenuStrip();
      mniChat = new System.Windows.Forms.ToolStripMenuItem();
      mniSave = new System.Windows.Forms.ToolStripMenuItem();
      mniExit = new System.Windows.Forms.ToolStripMenuItem();
      txtMessages = new System.Windows.Forms.RichTextBox();
      listViewRoomUsers = new Proshot.UtilityLib.ListView();
      mnuMain.SuspendLayout();
      splitContainer.Panel1.SuspendLayout();
      splitContainer.Panel2.SuspendLayout();
      splitContainer.SuspendLayout();
      SuspendLayout();
      // 
      // txtNewMessage
      // 
      txtNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      txtNewMessage.BorderWidth = 1F;
      txtNewMessage.FloatValue = 0D;
      txtNewMessage.Location = new System.Drawing.Point(142, 223);
      txtNewMessage.Name = "txtNewMessage";
      txtNewMessage.Size = new System.Drawing.Size(240, 21);
      txtNewMessage.TabIndex = 1;
      // 
      // lblNewMessage
      // 
      lblNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      lblNewMessage.AutoSize = true;
      lblNewMessage.BorderWidth = 1F;
      lblNewMessage.Location = new System.Drawing.Point(84, 226);
      lblNewMessage.Name = "lblNewMessage";
      lblNewMessage.Size = new System.Drawing.Size(56, 13);
      lblNewMessage.TabIndex = 2;
      lblNewMessage.Text = "Message :";
      // 
      // btnSend
      // 
      btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      btnSend.ImageKey = "SendMessage.ico";
      btnSend.ImageList = imgList;
      btnSend.Location = new System.Drawing.Point(390, 222);
      btnSend.Name = "btnSend";
      btnSend.Size = new System.Drawing.Size(67, 23);
      btnSend.TabIndex = 3;
      btnSend.Text = "Send";
      btnSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      btnSend.UseVisualStyleBackColor = true;
      btnSend.Click += new System.EventHandler(btnSend_Click);
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
      splitContainer.Panel1MinSize = 130;
      // 
      // splitContainer.Panel2
      // 
      splitContainer.Panel2.Controls.Add(txtMessages);
      splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
      splitContainer.Size = new System.Drawing.Size(450, 195);
      splitContainer.SplitterDistance = 130;
      splitContainer.TabIndex = 8;
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
      // mnuMain
      // 
      mnuMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mnuMain.BackgroundImage")));
      mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            mniChat});
      mnuMain.Location = new System.Drawing.Point(0, 0);
      mnuMain.Name = "mnuMain";
      mnuMain.Size = new System.Drawing.Size(460, 24);
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
      // txtMessages
      // 
      txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      txtMessages.Dock = System.Windows.Forms.DockStyle.Fill;
      txtMessages.Location = new System.Drawing.Point(0, 0);
      txtMessages.Name = "txtMessages";
      txtMessages.Size = new System.Drawing.Size(100, 20);
      txtMessages.TabIndex = 9;
      txtMessages.Text = "";
      // 
      // listViewRoomUsers
      // 
      listViewRoomUsers.FullRowSelect = true;
      listViewRoomUsers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
      listViewRoomUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
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
      listViewRoomUsers.Size = new System.Drawing.Size(130, 20);
      listViewRoomUsers.SmallImageList = imgList;
      listViewRoomUsers.TabIndex = 8;
      listViewRoomUsers.UseCompatibleStateImageBehavior = false;
      listViewRoomUsers.View = System.Windows.Forms.View.Details;
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
      // RoomFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(460, 258);
      Controls.Add(splitContainer);
      Controls.Add(btnSend);
      Controls.Add(lblNewMessage);
      Controls.Add(txtNewMessage);
      Controls.Add(mnuMain);
      Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
      MinimumSize = new System.Drawing.Size(354, 292);
      Name = "RoomFrm";
      ShowIcon = false;
      StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      Text = "";
      Activated += new System.EventHandler(RoomFrm_Activated);
      Deactivate += new System.EventHandler(RoomFrm_Deactivate);
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(RoomFrm_FormClosing);
      Load += new System.EventHandler(RoomFrm_Load);
      mnuMain.ResumeLayout(false);
      mnuMain.PerformLayout();
      splitContainer.Panel1.ResumeLayout(false);
      splitContainer.Panel2.ResumeLayout(false);
      splitContainer.ResumeLayout(false);
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
    private System.Windows.Forms.RichTextBox txtMessages;
    private Proshot.UtilityLib.ListView listViewRoomUsers;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ColumnHeader colUserIcon;
    private System.Windows.Forms.ColumnHeader colUserName;
  }
}

