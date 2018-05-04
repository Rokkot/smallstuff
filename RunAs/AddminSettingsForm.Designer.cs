namespace RunAs
{
	partial class AdminSettingsForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox_UserName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_Domain = new System.Windows.Forms.TextBox();
			this.textBox_PWD = new System.Windows.Forms.TextBox();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_OK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// textBox_UserName
			// 
			this.textBox_UserName.Location = new System.Drawing.Point(81, 12);
			this.textBox_UserName.Name = "textBox_UserName";
			this.textBox_UserName.Size = new System.Drawing.Size(272, 20);
			this.textBox_UserName.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Domain:";
			// 
			// textBox_Domain
			// 
			this.textBox_Domain.Location = new System.Drawing.Point(81, 38);
			this.textBox_Domain.Name = "textBox_Domain";
			this.textBox_Domain.Size = new System.Drawing.Size(272, 20);
			this.textBox_Domain.TabIndex = 1;
			// 
			// textBox_PWD
			// 
			this.textBox_PWD.Location = new System.Drawing.Point(81, 64);
			this.textBox_PWD.Name = "textBox_PWD";
			this.textBox_PWD.Size = new System.Drawing.Size(272, 20);
			this.textBox_PWD.TabIndex = 2;
			this.textBox_PWD.UseSystemPasswordChar = true;
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(278, 90);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 4;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(197, 90);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 3;
			this.button_OK.Text = "OK";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
			// 
			// AdminSettingsForm
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(365, 120);
			this.ControlBox = false;
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.textBox_PWD);
			this.Controls.Add(this.textBox_Domain);
			this.Controls.Add(this.textBox_UserName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AdminSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Admin Settings";
			this.Load += new System.EventHandler(this.AdminSettingsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_UserName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_Domain;
		private System.Windows.Forms.TextBox textBox_PWD;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_OK;
	}
}