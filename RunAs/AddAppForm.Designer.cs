namespace RunAs
{
	partial class AddAppForm
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
			this.textBox_AppNamePath = new System.Windows.Forms.TextBox();
			this.textBox_Label = new System.Windows.Forms.TextBox();
			this.button_Browse = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.button_Add = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Application";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Label";
			// 
			// textBox_AppNamePath
			// 
			this.textBox_AppNamePath.Location = new System.Drawing.Point(77, 6);
			this.textBox_AppNamePath.Name = "textBox_AppNamePath";
			//this.textBox_AppNamePath.ReadOnly = true;
			this.textBox_AppNamePath.Size = new System.Drawing.Size(218, 20);
			this.textBox_AppNamePath.TabIndex = 2;
			// 
			// textBox_Label
			// 
			this.textBox_Label.Location = new System.Drawing.Point(77, 32);
			this.textBox_Label.Name = "textBox_Label";
			this.textBox_Label.Size = new System.Drawing.Size(218, 20);
			this.textBox_Label.TabIndex = 3;
			// 
			// button_Browse
			// 
			this.button_Browse.Location = new System.Drawing.Point(301, 6);
			this.button_Browse.Name = "button_Browse";
			this.button_Browse.Size = new System.Drawing.Size(75, 23);
			this.button_Browse.TabIndex = 4;
			this.button_Browse.Text = "Browse";
			this.button_Browse.UseVisualStyleBackColor = true;
			this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(301, 58);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 5;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			// 
			// button_Add
			// 
			this.button_Add.Location = new System.Drawing.Point(220, 58);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 6;
			this.button_Add.Text = "Add";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// AddAppForm
			// 
			this.AcceptButton = this.button_Add;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(388, 93);
			this.ControlBox = false;
			this.Controls.Add(this.button_Add);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_Browse);
			this.Controls.Add(this.textBox_Label);
			this.Controls.Add(this.textBox_AppNamePath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AddAppForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Application";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_AppNamePath;
		private System.Windows.Forms.TextBox textBox_Label;
		private System.Windows.Forms.Button button_Browse;
		private System.Windows.Forms.Button button_Cancel;
		private System.Windows.Forms.Button button_Add;
	}
}