namespace Client
{
    partial class ProfileFrm
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
            if (disposing && (components != null))
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileFrm));
      this.userName = new System.Windows.Forms.Label();
      this.dateJoinedLabel = new System.Windows.Forms.Label();
      this.lastConnectionLabel = new System.Windows.Forms.Label();
      this.dateJoined = new System.Windows.Forms.Label();
      this.lastConnection = new System.Windows.Forms.Label();
      this.profileOK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // userName
      // 
      this.userName.AutoSize = true;
      this.userName.Dock = System.Windows.Forms.DockStyle.Fill;
      this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.userName.Location = new System.Drawing.Point(0, 0);
      this.userName.Name = "userName";
      this.userName.Size = new System.Drawing.Size(100, 37);
      this.userName.TabIndex = 0;
      this.userName.Text = "label1";
      this.userName.Click += new System.EventHandler(this.userName_Click);
      // 
      // dateJoinedLabel
      // 
      this.dateJoinedLabel.AutoSize = true;
      this.dateJoinedLabel.Location = new System.Drawing.Point(12, 67);
      this.dateJoinedLabel.Name = "dateJoinedLabel";
      this.dateJoinedLabel.Size = new System.Drawing.Size(73, 13);
      this.dateJoinedLabel.TabIndex = 1;
      this.dateJoinedLabel.Text = "Date Joined : ";
      // 
      // lastConnectionLabel
      // 
      this.lastConnectionLabel.AutoSize = true;
      this.lastConnectionLabel.Location = new System.Drawing.Point(12, 95);
      this.lastConnectionLabel.Name = "lastConnectionLabel";
      this.lastConnectionLabel.Size = new System.Drawing.Size(92, 13);
      this.lastConnectionLabel.TabIndex = 2;
      this.lastConnectionLabel.Text = "Last connection : ";
      // 
      // dateJoined
      // 
      this.dateJoined.AutoSize = true;
      this.dateJoined.Location = new System.Drawing.Point(104, 67);
      this.dateJoined.Name = "dateJoined";
      this.dateJoined.Size = new System.Drawing.Size(35, 13);
      this.dateJoined.TabIndex = 3;
      this.dateJoined.Text = "label1";
      // 
      // lastConnection
      // 
      this.lastConnection.AutoSize = true;
      this.lastConnection.Location = new System.Drawing.Point(104, 95);
      this.lastConnection.Name = "lastConnection";
      this.lastConnection.Size = new System.Drawing.Size(35, 13);
      this.lastConnection.TabIndex = 4;
      this.lastConnection.Text = "label2";
      // 
      // profileOK
      // 
      this.profileOK.Location = new System.Drawing.Point(107, 163);
      this.profileOK.Name = "profileOK";
      this.profileOK.Size = new System.Drawing.Size(75, 23);
      this.profileOK.TabIndex = 5;
      this.profileOK.Text = "OK";
      this.profileOK.UseVisualStyleBackColor = true;
      this.profileOK.Click += new System.EventHandler(this.profileOK_Click);
      // 
      // ProfileFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 215);
      this.Controls.Add(this.profileOK);
      this.Controls.Add(this.lastConnection);
      this.Controls.Add(this.dateJoined);
      this.Controls.Add(this.lastConnectionLabel);
      this.Controls.Add(this.dateJoinedLabel);
      this.Controls.Add(this.userName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "ProfileFrm";
      this.Text = "My Profile";
      this.Load += new System.EventHandler(this.ProfileFrm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateJoinedLabel;
        private System.Windows.Forms.Label lastConnectionLabel;
        private System.Windows.Forms.Button profileOK;
    public System.Windows.Forms.Label dateJoined;
    public System.Windows.Forms.Label lastConnection;
    public System.Windows.Forms.Label userName;
  }
}