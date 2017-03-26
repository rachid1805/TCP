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
      txtUsetName = new Proshot.UtilityLib.TextBox();
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
      // txtUsetName
      // 
      txtUsetName.BorderWidth = 1F;
      txtUsetName.FloatValue = 0;
      txtUsetName.Location = new System.Drawing.Point(78 , 6);
      txtUsetName.MaxLength = 10;
      txtUsetName.Name = "txtUsetName";
      txtUsetName.Size = new System.Drawing.Size(94 , 22);
      txtUsetName.TabIndex = 1;
      // 
      // btnEnter
      // 
      btnEnter.Location = new System.Drawing.Point(125 , 34);
      btnEnter.Name = "btnEnter";
      btnEnter.Size = new System.Drawing.Size(48 , 23);
      btnEnter.TabIndex = 2;
      btnEnter.Text = "Enter";
      btnEnter.UseVisualStyleBackColor = true;
      btnEnter.Click += new System.EventHandler(btnEnter_Click);
      // 
      // btnExit
      // 
      btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnExit.Location = new System.Drawing.Point(77 , 34);
      btnExit.Name = "btnExit";
      btnExit.Size = new System.Drawing.Size(48 , 23);
      btnExit.TabIndex = 3;
      btnExit.Text = "Exit";
      btnExit.UseVisualStyleBackColor = true;
      btnExit.Click += new System.EventHandler(btnExit_Click);
      // 
      // LoginFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F , 14F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(178 , 70);
      ControlBox = false;
      Controls.Add(btnExit);
      Controls.Add(btnEnter);
      Controls.Add(txtUsetName);
      Controls.Add(lblUserName);
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
    private Proshot.UtilityLib.TextBox txtUsetName;
    private Proshot.UtilityLib.Button btnEnter;
    private Proshot.UtilityLib.Button btnExit;
  }
}