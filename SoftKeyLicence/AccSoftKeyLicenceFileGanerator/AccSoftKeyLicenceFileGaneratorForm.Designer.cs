namespace AccSoftKeyLicenceFileGanerator
{
	partial class AccSoftKeyLicenceFileGaneratorForm
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
			this.buttonGO = new System.Windows.Forms.Button();
			this.textBoxRegistrationID = new System.Windows.Forms.TextBox();
			this.labelRegistrationID = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonGO
			// 
			this.buttonGO.Location = new System.Drawing.Point(96, 39);
			this.buttonGO.Name = "buttonGO";
			this.buttonGO.Size = new System.Drawing.Size(430, 43);
			this.buttonGO.TabIndex = 0;
			this.buttonGO.Text = "Generate Licence File";
			this.buttonGO.UseVisualStyleBackColor = true;
			this.buttonGO.Click += new System.EventHandler(this.buttonGO_Click);
			// 
			// textBoxRegistrationID
			// 
			this.textBoxRegistrationID.Location = new System.Drawing.Point(96, 13);
			this.textBoxRegistrationID.Name = "textBoxRegistrationID";
			this.textBoxRegistrationID.Size = new System.Drawing.Size(430, 20);
			this.textBoxRegistrationID.TabIndex = 1;
			// 
			// labelRegistrationID
			// 
			this.labelRegistrationID.AutoSize = true;
			this.labelRegistrationID.Location = new System.Drawing.Point(12, 16);
			this.labelRegistrationID.Name = "labelRegistrationID";
			this.labelRegistrationID.Size = new System.Drawing.Size(80, 13);
			this.labelRegistrationID.TabIndex = 2;
			this.labelRegistrationID.Text = "Registration ID:";
			// 
			// AccMachineIDConfirmationGaneratorForm
			// 
			this.AcceptButton = this.buttonGO;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(538, 94);
			this.Controls.Add(this.labelRegistrationID);
			this.Controls.Add(this.textBoxRegistrationID);
			this.Controls.Add(this.buttonGO);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AccMachineIDConfirmationGaneratorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Softkey Licence Ganerator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonGO;
		private System.Windows.Forms.TextBox textBoxRegistrationID;
		private System.Windows.Forms.Label labelRegistrationID;
	}
}

