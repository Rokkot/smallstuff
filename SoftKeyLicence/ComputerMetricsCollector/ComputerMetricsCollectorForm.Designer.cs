namespace ComputerMetricsCollector
{
	partial class ComputerMetricsCollectorForm
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
			this.radioButtonMachineID = new System.Windows.Forms.RadioButton();
			this.radioButtonLargeSubSet = new System.Windows.Forms.RadioButton();
			this.radioButtonAllInfo = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonStart = new System.Windows.Forms.Button();
			this.progressBar = new SoftKeyUtils.CustomProgressBar();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// radioButtonMachineID
			// 
			this.radioButtonMachineID.AutoSize = true;
			this.radioButtonMachineID.Checked = true;
			this.radioButtonMachineID.Location = new System.Drawing.Point(6, 22);
			this.radioButtonMachineID.Name = "radioButtonMachineID";
			this.radioButtonMachineID.Size = new System.Drawing.Size(80, 17);
			this.radioButtonMachineID.TabIndex = 3;
			this.radioButtonMachineID.TabStop = true;
			this.radioButtonMachineID.Text = "Machine ID";
			this.radioButtonMachineID.UseVisualStyleBackColor = true;
			// 
			// radioButtonLargeSubSet
			// 
			this.radioButtonLargeSubSet.AutoSize = true;
			this.radioButtonLargeSubSet.Location = new System.Drawing.Point(6, 45);
			this.radioButtonLargeSubSet.Name = "radioButtonLargeSubSet";
			this.radioButtonLargeSubSet.Size = new System.Drawing.Size(139, 17);
			this.radioButtonLargeSubSet.TabIndex = 3;
			this.radioButtonLargeSubSet.Text = "Large SubSet of Metrics";
			this.radioButtonLargeSubSet.UseVisualStyleBackColor = true;
			// 
			// radioButtonAllInfo
			// 
			this.radioButtonAllInfo.AutoSize = true;
			this.radioButtonAllInfo.Location = new System.Drawing.Point(17, 115);
			this.radioButtonAllInfo.Name = "radioButtonAllInfo";
			this.radioButtonAllInfo.Size = new System.Drawing.Size(140, 17);
			this.radioButtonAllInfo.TabIndex = 3;
			this.radioButtonAllInfo.Text = "All Info (will take a while)";
			this.radioButtonAllInfo.UseVisualStyleBackColor = true;
			this.radioButtonAllInfo.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonStart);
			this.groupBox1.Controls.Add(this.radioButtonMachineID);
			this.groupBox1.Controls.Add(this.radioButtonLargeSubSet);
			this.groupBox1.Location = new System.Drawing.Point(12, 38);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(531, 71);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Collect The Following info:";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(163, 22);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(362, 40);
			this.buttonStart.TabIndex = 5;
			this.buttonStart.Text = "Go";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// progressBar
			// 
			this.progressBar.CustomText = null;
			this.progressBar.DisplayStyle = SoftKeyUtils.ProgressBarDisplayText.Percentage;
			this.progressBar.Location = new System.Drawing.Point(12, 9);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(531, 23);
			this.progressBar.TabIndex = 2;
			this.progressBar.UseCustomText = false;
			this.progressBar.Visible = false;
			// 
			// ComputerMetricsCollectorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 140);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.radioButtonAllInfo);
			this.Controls.Add(this.progressBar);
			this.Name = "ComputerMetricsCollectorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Computer Metrics";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SoftKeyUtils.CustomProgressBar progressBar;
		private System.Windows.Forms.RadioButton radioButtonMachineID;
		private System.Windows.Forms.RadioButton radioButtonLargeSubSet;
		private System.Windows.Forms.RadioButton radioButtonAllInfo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonStart;
	}
}

