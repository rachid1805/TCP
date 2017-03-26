namespace Client
{
  partial class PrivateFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateFrm));
            txtNewMessage = new Proshot.UtilityLib.TextBox();
            lblNewMessage = new Proshot.UtilityLib.Label();
            btnSend = new Proshot.UtilityLib.Button();
            imgList = new System.Windows.Forms.ImageList(components);
            mnuMain = new Proshot.UtilityLib.MenuStrip();
            mniChat = new System.Windows.Forms.ToolStripMenuItem();
            mniSave = new System.Windows.Forms.ToolStripMenuItem();
            mniExit = new System.Windows.Forms.ToolStripMenuItem();
            txtMessages = new System.Windows.Forms.RichTextBox();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // txtNewMessage
            // 
            txtNewMessage.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            txtNewMessage.BorderWidth = 1F;
            txtNewMessage.FloatValue = 0;
            txtNewMessage.Location = new System.Drawing.Point(65 , 223);
            txtNewMessage.Name = "txtNewMessage";
            txtNewMessage.Size = new System.Drawing.Size(203 , 21);
            txtNewMessage.TabIndex = 1;
            // 
            // lblNewMessage
            // 
            lblNewMessage.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            lblNewMessage.AutoSize = true;
            lblNewMessage.BorderWidth = 1F;
            lblNewMessage.Location = new System.Drawing.Point(3 , 226);
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
            btnSend.Location = new System.Drawing.Point(276 , 222);
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
            imgList.ImageStream = ( (System.Windows.Forms.ImageListStreamer)( resources.GetObject("imgList.ImageStream") ) );
            imgList.TransparentColor = System.Drawing.Color.Transparent;
            imgList.Images.SetKeyName(0 , "Smiely.ico");
            imgList.Images.SetKeyName(1 , "Private.ico");
            imgList.Images.SetKeyName(2 , "SendMessage.ico");
            imgList.Images.SetKeyName(3 , "Enter.ico");
            imgList.Images.SetKeyName(4 , "Exit.ico");
            // 
            // mnuMain
            // 
            mnuMain.BackgroundImage = ( (System.Drawing.Image)( resources.GetObject("mnuMain.BackgroundImage") ) );
            mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem [] {
            mniChat});
            mnuMain.Location = new System.Drawing.Point(0 , 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Size = new System.Drawing.Size(346 , 24);
            mnuMain.TabIndex = 7;
            // 
            // mniChat
            // 
            mniChat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem [] {
            mniSave,
            mniExit});
            mniChat.Name = "mniChat";
            mniChat.Size = new System.Drawing.Size(42 , 20);
            mniChat.Text = "Chat";
            // 
            // mniSave
            // 
            mniSave.Image = ( (System.Drawing.Image)( resources.GetObject("mniSave.Image") ) );
            mniSave.Name = "mniSave";
            mniSave.Size = new System.Drawing.Size(152 , 22);
            mniSave.Text = "Save";
            mniSave.Click += new System.EventHandler(mniSave_Click);
            // 
            // mniExit
            // 
            mniExit.Image = ( (System.Drawing.Image)( resources.GetObject("mniExit.Image") ) );
            mniExit.Name = "mniExit";
            mniExit.Size = new System.Drawing.Size(152 , 22);
            mniExit.Text = "Exit";
            mniExit.Click += new System.EventHandler(mniExit_Click);
            // 
            // txtMessages
            // 
            txtMessages.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            txtMessages.Location = new System.Drawing.Point(2 , 27);
            txtMessages.Name = "txtMessages";
            txtMessages.Size = new System.Drawing.Size(343 , 185);
            txtMessages.TabIndex = 8;
            txtMessages.Text = "";
            // 
            // PrivateFrm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F , 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(346 , 258);
            Controls.Add(txtMessages);
            Controls.Add(btnSend);
            Controls.Add(lblNewMessage);
            Controls.Add(txtNewMessage);
            Controls.Add(mnuMain);
            Font = new System.Drawing.Font("Tahoma" , 8.25F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 177 ) ));
            MinimumSize = new System.Drawing.Size(354 , 292);
            Name = "PrivateFrm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Private Chat";
            Deactivate += new System.EventHandler(PrivateFrm_Deactivate);
            Activated += new System.EventHandler(PrivateFrm_Activated);
            FormClosing += new System.Windows.Forms.FormClosingEventHandler(PrivateFrm_FormClosing);
            Load += new System.EventHandler(PrivateFrm_Load);
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
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
    }
}

