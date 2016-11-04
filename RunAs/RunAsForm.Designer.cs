namespace RunAs
{
	partial class RunAsForm
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
			this.components = new System.ComponentModel.Container();
			this.listView = new System.Windows.Forms.ListView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.button_Add = new System.Windows.Forms.Button();
			this.button_Remove = new System.Windows.Forms.Button();
			this.button_Admin = new System.Windows.Forms.Button();
			this.button_RunAs = new System.Windows.Forms.Button();
			this.button_Exit = new System.Windows.Forms.Button();
			this.checkBox_CloseWhenRun = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView.LargeImageList = this.imageList;
			this.listView.Location = new System.Drawing.Point(12, 12);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(401, 282);
			this.listView.SmallImageList = this.imageList;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(listView_MouseDoubleClick);
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList.ImageSize = new System.Drawing.Size(32, 32);
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// button_Add
			// 
			this.button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Add.Location = new System.Drawing.Point(419, 12);
			this.button_Add.Name = "button_Add";
			this.button_Add.Size = new System.Drawing.Size(75, 23);
			this.button_Add.TabIndex = 1;
			this.button_Add.Text = "Add";
			this.button_Add.UseVisualStyleBackColor = true;
			this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
			// 
			// button_Remove
			// 
			this.button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Remove.Location = new System.Drawing.Point(419, 41);
			this.button_Remove.Name = "button_Remove";
			this.button_Remove.Size = new System.Drawing.Size(75, 23);
			this.button_Remove.TabIndex = 2;
			this.button_Remove.Text = "Remove";
			this.button_Remove.UseVisualStyleBackColor = true;
			this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
			// 
			// button_Admin
			// 
			this.button_Admin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Admin.Location = new System.Drawing.Point(419, 70);
			this.button_Admin.Name = "button_Admin";
			this.button_Admin.Size = new System.Drawing.Size(75, 23);
			this.button_Admin.TabIndex = 3;
			this.button_Admin.Text = "Admin";
			this.button_Admin.UseVisualStyleBackColor = true;
			this.button_Admin.Click += new System.EventHandler(this.button_Admin_Click);
			// 
			// button_RunAs
			// 
			this.button_RunAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_RunAs.Location = new System.Drawing.Point(419, 271);
			this.button_RunAs.Name = "button_RunAs";
			this.button_RunAs.Size = new System.Drawing.Size(75, 23);
			this.button_RunAs.TabIndex = 4;
			this.button_RunAs.Text = "RunAs";
			this.button_RunAs.UseVisualStyleBackColor = true;
			this.button_RunAs.Click += new System.EventHandler(this.button_RunAs_Click);
			// 
			// button_Exit
			// 
			this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Exit.Location = new System.Drawing.Point(419, 312);
			this.button_Exit.Name = "button_Exit";
			this.button_Exit.Size = new System.Drawing.Size(75, 23);
			this.button_Exit.TabIndex = 5;
			this.button_Exit.Text = "Exit";
			this.button_Exit.UseVisualStyleBackColor = true;
			this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
			// 
			// checkBox_CloseWhenRun
			// 
			this.checkBox_CloseWhenRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox_CloseWhenRun.AutoSize = true;
			this.checkBox_CloseWhenRun.Checked = true;
			this.checkBox_CloseWhenRun.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_CloseWhenRun.Location = new System.Drawing.Point(12, 316);
			this.checkBox_CloseWhenRun.Name = "checkBox_CloseWhenRun";
			this.checkBox_CloseWhenRun.Size = new System.Drawing.Size(177, 17);
			this.checkBox_CloseWhenRun.TabIndex = 6;
			this.checkBox_CloseWhenRun.Text = "Close the application on RunAs ";
			this.checkBox_CloseWhenRun.UseVisualStyleBackColor = true;
			// 
			// RunAsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 347);
			this.ControlBox = false;
			this.Controls.Add(this.checkBox_CloseWhenRun);
			this.Controls.Add(this.button_Exit);
			this.Controls.Add(this.button_RunAs);
			this.Controls.Add(this.button_Admin);
			this.Controls.Add(this.button_Remove);
			this.Controls.Add(this.button_Add);
			this.Controls.Add(this.listView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RunAsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RunAs";
			this.Load += new System.EventHandler(this.RunAsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.Button button_Add;
		private System.Windows.Forms.Button button_Remove;
		private System.Windows.Forms.Button button_Admin;
		private System.Windows.Forms.Button button_RunAs;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button button_Exit;
		private System.Windows.Forms.CheckBox checkBox_CloseWhenRun;
	}
}

