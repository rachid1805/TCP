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
      this.lblRoomName = new Proshot.UtilityLib.Label();
      this.txtRoomName = new Proshot.UtilityLib.TextBox();
      this.lblRoomDescription = new Proshot.UtilityLib.Label();
      this.txtRoomDescription = new Proshot.UtilityLib.TextBox();
      this.btnEnter = new Proshot.UtilityLib.Button();
      this.btnExit = new Proshot.UtilityLib.Button();
      this.SuspendLayout();
      // 
      // lblRoomName
      // 
      this.lblRoomName.AutoSize = true;
      this.lblRoomName.BorderWidth = 1F;
      this.lblRoomName.Location = new System.Drawing.Point(4, 9);
      this.lblRoomName.Name = "lblRoomName";
      this.lblRoomName.Size = new System.Drawing.Size(81, 14);
      this.lblRoomName.TabIndex = 0;
      this.lblRoomName.Text = "Room Name :";
      // 
      // txtRoomName
      // 
      this.txtRoomName.BorderWidth = 1F;
      this.txtRoomName.FloatValue = 0D;
      this.txtRoomName.Location = new System.Drawing.Point(86, 6);
      this.txtRoomName.MaxLength = 20;
      this.txtRoomName.Name = "txtRoomName";
      this.txtRoomName.Size = new System.Drawing.Size(115, 22);
      this.txtRoomName.TabIndex = 1;
      // 
      // lblRoomDescription
      // 
      this.lblRoomDescription.AutoSize = true;
      this.lblRoomDescription.BorderWidth = 1F;
      this.lblRoomDescription.Location = new System.Drawing.Point(4, 35);
      this.lblRoomDescription.Name = "lblRoomDescription";
      this.lblRoomDescription.Size = new System.Drawing.Size(83, 14);
      this.lblRoomDescription.TabIndex = 2;
      this.lblRoomDescription.Text = "Description   :";
      // 
      // txtRoomDescription
      // 
      this.txtRoomDescription.BorderWidth = 1F;
      this.txtRoomDescription.FloatValue = 0D;
      this.txtRoomDescription.Location = new System.Drawing.Point(86, 31);
      this.txtRoomDescription.MaxLength = 100;
      this.txtRoomDescription.Name = "txtRoomDescription";
      this.txtRoomDescription.Size = new System.Drawing.Size(115, 22);
      this.txtRoomDescription.TabIndex = 3;
      // 
      // btnEnter
      // 
      this.btnEnter.Location = new System.Drawing.Point(150, 59);
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
      this.btnExit.Location = new System.Drawing.Point(93, 59);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(48, 23);
      this.btnExit.TabIndex = 5;
      this.btnExit.Text = "Exit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // RoomInfoFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(212, 89);
      this.ControlBox = false;
      this.Controls.Add(this.btnExit);
      this.Controls.Add(this.btnEnter);
      this.Controls.Add(this.txtRoomName);
      this.Controls.Add(this.lblRoomName);
      this.Controls.Add(this.txtRoomDescription);
      this.Controls.Add(this.lblRoomDescription);
      this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "RoomInfoFrm";
      this.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomInfoFrm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

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