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
      lblUserName = new Proshot.UtilityLib.Label();
      txtUserName = new Proshot.UtilityLib.TextBox();
      lblPassword = new Proshot.UtilityLib.Label();
      txtPassword = new Proshot.UtilityLib.TextBox();
      btnEnter = new Proshot.UtilityLib.Button();
      btnExit = new Proshot.UtilityLib.Button();
      SuspendLayout();
      // 
      // lblUserName
      // 
      lblUserName.AutoSize = true;
      lblUserName.BorderWidth = 1F;
      lblUserName.Location = new System.Drawing.Point(4 , 9);
      lblUserName.Name = "lblUserName";
      lblUserName.Size = new System.Drawing.Size(74 , 14);
      lblUserName.TabIndex = 0;
      lblUserName.Text = "User Name :";
      // 
      // txtUserName
      // 
      txtUserName.BorderWidth = 1F;
      txtUserName.FloatValue = 0;
      txtUserName.Location = new System.Drawing.Point(78 , 6);
      txtUserName.MaxLength = 10;
      txtUserName.Name = "txtUserName";
      txtUserName.Size = new System.Drawing.Size(94 , 22);
      txtUserName.TabIndex = 1;
      // 
      // lblPassword
      // 
      lblPassword.AutoSize = true;
      lblPassword.BorderWidth = 1F;
      lblPassword.Location = new System.Drawing.Point(4, 35);
      lblPassword.Name = "lblPassword";
      lblPassword.Size = new System.Drawing.Size(74, 14);
      lblPassword.TabIndex = 2;
      lblPassword.Text = "Password   :";
      // 
      // txtPassword
      // 
      txtPassword.BorderWidth = 1F;
      txtPassword.FloatValue = 0;
      txtPassword.Location = new System.Drawing.Point(78, 32);
      txtPassword.MaxLength = 10;
      txtPassword.Name = "txtPassword";
      txtPassword.Size = new System.Drawing.Size(94, 22);
      txtPassword.TabIndex = 3;
      // 
      // btnEnter
      // 
      btnEnter.Location = new System.Drawing.Point(125 , 59);
      btnEnter.Name = "btnEnter";
      btnEnter.Size = new System.Drawing.Size(48 , 23);
      btnEnter.TabIndex = 4;
      btnEnter.Text = "Enter";
      btnEnter.UseVisualStyleBackColor = true;
      btnEnter.Click += new System.EventHandler(btnEnter_Click);
      // 
      // btnExit
      // 
      btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnExit.Location = new System.Drawing.Point(77 , 59);
      btnExit.Name = "btnExit";
      btnExit.Size = new System.Drawing.Size(48 , 23);
      btnExit.TabIndex = 5;
      btnExit.Text = "Exit";
      btnExit.UseVisualStyleBackColor = true;
      btnExit.Click += new System.EventHandler(btnExit_Click);
      // 
      // LoginFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F , 14F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(178 , 95);
      ControlBox = false;
      Controls.Add(btnExit);
      Controls.Add(btnEnter);
      Controls.Add(txtUserName);
      Controls.Add(lblUserName);
      Controls.Add(txtPassword);
      Controls.Add(lblPassword);
      Font = new System.Drawing.Font("Tahoma" , 9F , System.Drawing.FontStyle.Regular , System.Drawing.GraphicsUnit.Point , ( (byte)( 0 ) ));
      FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      Name = "LoginFrm";
      RightToLeft = System.Windows.Forms.RightToLeft.No;
      ShowIcon = false;
      ShowInTaskbar = false;
      StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(LoginFrm_FormClosing);
      ResumeLayout(false);
      PerformLayout();
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