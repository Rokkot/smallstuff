namespace AccClientRegistrationIDGenerator
{
	partial class AccClientRegistrationIDGeneratorForm
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
			this.buttonStart = new System.Windows.Forms.Button();
			this.progressBar = new SoftKeyUtils.CustomProgressBar();
			this.textEdit = new System.Windows.Forms.TextBox();
			this.labelControl1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(12, 39);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(531, 26);
			this.buttonStart.TabIndex = 5;
			this.buttonStart.Text = "Generate";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(12, 12);
			this.progressBar.Name = "progressBar";
			this.progressBar.Step = 1;
			this.progressBar.Size = new System.Drawing.Size(531, 21);
			this.progressBar.TabIndex = 8;
			// 
			// textEdit
			// 
			this.textEdit.Location = new System.Drawing.Point(94, 12);
			this.textEdit.Name = "textEdit";
			this.textEdit.Size = new System.Drawing.Size(449, 20);
			this.textEdit.TabIndex = 9;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 15);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(76, 13);
			this.labelControl1.TabIndex = 10;
			this.labelControl1.Text = "Registration ID:";
			// 
			// AccClientRegistrationIDGeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 77);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.textEdit);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.buttonStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AccClientRegistrationIDGeneratorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Client Licence Registration ID Generator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private SoftKeyUtils.CustomProgressBar progressBar;
        private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.TextBox textEdit;
		private System.Windows.Forms.Label labelControl1;
	}
}

