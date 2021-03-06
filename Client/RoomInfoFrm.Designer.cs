namespace Client
{
  partial class RoomInfoFrm
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
      lblRoomName = new Proshot.UtilityLib.Label();
      txtRoomName = new Proshot.UtilityLib.TextBox();
      lblRoomDescription = new Proshot.UtilityLib.Label();
      txtRoomDescription = new Proshot.UtilityLib.TextBox();
      btnEnter = new Proshot.UtilityLib.Button();
      btnExit = new Proshot.UtilityLib.Button();
      SuspendLayout();
      // 
      // lblRoomName
      // 
      lblRoomName.AutoSize = true;
      lblRoomName.BorderWidth = 1F;
      lblRoomName.Location = new System.Drawing.Point(4, 9);
      lblRoomName.Name = "lblRoomName";
      lblRoomName.Size = new System.Drawing.Size(81, 14);
      lblRoomName.TabIndex = 0;
      lblRoomName.Text = "Room Name :";
      // 
      // txtRoomName
      // 
      txtRoomName.BorderWidth = 1F;
      txtRoomName.FloatValue = 0D;
      txtRoomName.Location = new System.Drawing.Point(86, 6);
      txtRoomName.MaxLength = 20;
      txtRoomName.Name = "txtRoomName";
      txtRoomName.Size = new System.Drawing.Size(115, 22);
      txtRoomName.TabIndex = 1;
      // 
      // lblRoomDescription
      // 
      lblRoomDescription.AutoSize = true;
      lblRoomDescription.BorderWidth = 1F;
      lblRoomDescription.Location = new System.Drawing.Point(4, 35);
      lblRoomDescription.Name = "lblRoomDescription";
      lblRoomDescription.Size = new System.Drawing.Size(83, 14);
      lblRoomDescription.TabIndex = 2;
      lblRoomDescription.Text = "Description   :";
      // 
      // txtRoomDescription
      // 
      txtRoomDescription.BorderWidth = 1F;
      txtRoomDescription.FloatValue = 0D;
      txtRoomDescription.Location = new System.Drawing.Point(86, 31);
      txtRoomDescription.MaxLength = 100;
      txtRoomDescription.Name = "txtRoomDescription";
      txtRoomDescription.Size = new System.Drawing.Size(115, 22);
      txtRoomDescription.TabIndex = 3;
      // 
      // btnEnter
      // 
      btnEnter.Location = new System.Drawing.Point(150, 59);
      btnEnter.Name = "btnEnter";
      btnEnter.Size = new System.Drawing.Size(48, 23);
      btnEnter.TabIndex = 4;
      btnEnter.Text = "Enter";
      btnEnter.UseVisualStyleBackColor = true;
      btnEnter.Click += new System.EventHandler(btnEnter_Click);
      // 
      // btnExit
      // 
      btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      btnExit.Location = new System.Drawing.Point(93, 59);
      btnExit.Name = "btnExit";
      btnExit.Size = new System.Drawing.Size(48, 23);
      btnExit.TabIndex = 5;
      btnExit.Text = "Exit";
      btnExit.UseVisualStyleBackColor = true;
      btnExit.Click += new System.EventHandler(btnExit_Click);
      // 
      // RoomInfoFrm
      // 
      AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(212, 89);
      ControlBox = false;
      Controls.Add(btnExit);
      Controls.Add(btnEnter);
      Controls.Add(txtRoomName);
      Controls.Add(lblRoomName);
      Controls.Add(txtRoomDescription);
      Controls.Add(lblRoomDescription);
      Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      Name = "RoomInfoFrm";
      RightToLeft = System.Windows.Forms.RightToLeft.No;
      ShowIcon = false;
      ShowInTaskbar = false;
      StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      FormClosing += new System.Windows.Forms.FormClosingEventHandler(RoomInfoFrm_FormClosing);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Proshot.UtilityLib.Label lblRoomName;
    private Proshot.UtilityLib.TextBox txtRoomName;
    private Proshot.UtilityLib.Label lblRoomDescription;
    private Proshot.UtilityLib.TextBox txtRoomDescription;
    private Proshot.UtilityLib.Button btnEnter;
    private Proshot.UtilityLib.Button btnExit;
  }
}