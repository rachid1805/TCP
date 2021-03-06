namespace Client
{
  partial class LoginFrm
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
      this.lblUserName = new Proshot.UtilityLib.Label();
      this.txtUserName = new Proshot.UtilityLib.TextBox();
      this.lblPassword = new Proshot.UtilityLib.Label();
      this.txtPassword = new Proshot.UtilityLib.TextBox();
      this.btnEnter = new Proshot.UtilityLib.Button();
      this.btnExit = new Proshot.UtilityLib.Button();
      this.SuspendLayout();
      // 
      // lblUserName
      // 
      this.lblUserName.AutoSize = true;
      this.lblUserName.BorderWidth = 1F;
      this.lblUserName.Location = new System.Drawing.Point(4, 9);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Size = new System.Drawing.Size(74, 14);
      this.lblUserName.TabIndex = 0;
      this.lblUserName.Text = "User Name :";
      // 
      // txtUserName
      // 
      this.txtUserName.BorderWidth = 1F;
      this.txtUserName.FloatValue = 0D;
      this.txtUserName.Location = new System.Drawing.Point(78, 6);
      this.txtUserName.MaxLength = 10;
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(94, 22);
      this.txtUserName.TabIndex = 1;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.BorderWidth = 1F;
      this.lblPassword.Location = new System.Drawing.Point(4, 35);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(74, 14);
      this.lblPassword.TabIndex = 2;
      this.lblPassword.Text = "Password   :";
      // 
      // txtPassword
      // 
      this.txtPassword.BorderWidth = 1F;
      this.txtPassword.FloatValue = 0D;
      this.txtPassword.Location = new System.Drawing.Point(78, 32);
      this.txtPassword.MaxLength = 10;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(94, 22);
      this.txtPassword.TabIndex = 3;
      // 
      // btnEnter
      // 
      this.btnEnter.Location = new System.Drawing.Point(125, 59);
      this.btnEnter.Name = "btnEnter";
      this.btnEnter.Size = new System.Drawing.Size(48, 23);
      this.btnEnter.TabIndex = 4;
      this.btnEnter.Text = "Enter";
      this.btnEnter.UseVisualStyleBackColor = true;
      this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
      // 
      // btnExit
      // 
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.Location = new System.Drawing.Point(77, 59);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(48, 23);
      this.btnExit.TabIndex = 5;
      this.btnExit.Text = "Exit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // LoginFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(178, 95);
      this.ControlBox = false;
      this.Controls.Add(this.btnExit);
      this.Controls.Add(this.btnEnter);
      this.Controls.Add(this.txtUserName);
      this.Controls.Add(this.lblUserName);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.lblPassword);
      this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "LoginFrm";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginFrm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Proshot.UtilityLib.Label lblUserName;
    private Proshot.UtilityLib.TextBox txtUserName;
    private Proshot.UtilityLib.Label lblPassword;
    private Proshot.UtilityLib.TextBox txtPassword;
    private Proshot.UtilityLib.Button btnEnter;
    private Proshot.UtilityLib.Button btnExit;
  }
}