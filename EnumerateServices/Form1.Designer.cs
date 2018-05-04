namespace EnumerateServices
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeader_Service = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader_Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button_Close = new System.Windows.Forms.Button();
			this.panel_Top = new System.Windows.Forms.Panel();
			this.textBox_Domain = new System.Windows.Forms.TextBox();
			this.textBox_Pwd = new System.Windows.Forms.TextBox();
			this.textBox_UserName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button_Go = new System.Windows.Forms.Button();
			this.textBox_ComputerName = new System.Windows.Forms.TextBox();
			this.label_ComputerName = new System.Windows.Forms.Label();
			this.panel_Bottom = new System.Windows.Forms.Panel();
			this.textBox_Filter = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.imageListStatus = new System.Windows.Forms.ImageList(this.components);
			this.panel_Top.SuspendLayout();
			this.panel_Bottom.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Service,
            this.columnHeader_Status});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.Name = "listView";
			this.listView.ShowItemToolTips = true;
			this.listView.Size = new System.Drawing.Size(711, 339);
			this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader_Service
			// 
			this.columnHeader_Service.Text = "Status";
			this.columnHeader_Service.Width = 50;
			// 
			// columnHeader_Status
			// 
			this.columnHeader_Status.Text = "Service";
			this.columnHeader_Status.Width = 300;
			// 
			// button_Close
			// 
			this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Close.Location = new System.Drawing.Point(624, 12);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(75, 23);
			this.button_Close.TabIndex = 0;
			this.button_Close.Text = "Close";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
			// 
			// panel_Top
			// 
			this.panel_Top.Controls.Add(this.textBox_Domain);
			this.panel_Top.Controls.Add(this.textBox_Pwd);
			this.panel_Top.Controls.Add(this.textBox_UserName);
			this.panel_Top.Controls.Add(this.label2);
			this.panel_Top.Controls.Add(this.label3);
			this.panel_Top.Controls.Add(this.label1);
			this.panel_Top.Controls.Add(this.button_Go);
			this.panel_Top.Controls.Add(this.textBox_ComputerName);
			this.panel_Top.Controls.Add(this.label_ComputerName);
			this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_Top.Location = new System.Drawing.Point(0, 0);
			this.panel_Top.Name = "panel_Top";
			this.panel_Top.Size = new System.Drawing.Size(711, 69);
			this.panel_Top.TabIndex = 2;
			// 
			// textBox_Domain
			// 
			this.textBox_Domain.Location = new System.Drawing.Point(104, 38);
			this.textBox_Domain.Name = "textBox_Domain";
			this.textBox_Domain.Size = new System.Drawing.Size(110, 20);
			this.textBox_Domain.TabIndex = 1;
			// 
			// textBox_Pwd
			// 
			this.textBox_Pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_Pwd.Location = new System.Drawing.Point(483, 38);
			this.textBox_Pwd.Name = "textBox_Pwd";
			this.textBox_Pwd.PasswordChar = '*';
			this.textBox_Pwd.Size = new System.Drawing.Size(136, 20);
			this.textBox_Pwd.TabIndex = 3;
			// 
			// textBox_UserName
			// 
			this.textBox_UserName.Location = new System.Drawing.Point(299, 38);
			this.textBox_UserName.Name = "textBox_UserName";
			this.textBox_UserName.Size = new System.Drawing.Size(116, 20);
			this.textBox_UserName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(421, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Domain:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(230, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "User Name:";
			// 
			// button_Go
			// 
			this.button_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Go.Location = new System.Drawing.Point(624, 12);
			this.button_Go.Name = "button_Go";
			this.button_Go.Size = new System.Drawing.Size(75, 23);
			this.button_Go.TabIndex = 4;
			this.button_Go.Text = "GO";
			this.button_Go.UseVisualStyleBackColor = true;
			this.button_Go.Click += new System.EventHandler(this.button_Go_Click);
			// 
			// textBox_ComputerName
			// 
			this.textBox_ComputerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_ComputerName.Location = new System.Drawing.Point(104, 12);
			this.textBox_ComputerName.Name = "textBox_ComputerName";
			this.textBox_ComputerName.Size = new System.Drawing.Size(514, 20);
			this.textBox_ComputerName.TabIndex = 0;
			// 
			// label_ComputerName
			// 
			this.label_ComputerName.AutoSize = true;
			this.label_ComputerName.Location = new System.Drawing.Point(12, 15);
			this.label_ComputerName.Name = "label_ComputerName";
			this.label_ComputerName.Size = new System.Drawing.Size(86, 13);
			this.label_ComputerName.TabIndex = 0;
			this.label_ComputerName.Text = "Computer Name:";
			// 
			// panel_Bottom
			// 
			this.panel_Bottom.Controls.Add(this.textBox_Filter);
			this.panel_Bottom.Controls.Add(this.button_Close);
			this.panel_Bottom.Controls.Add(this.label4);
			this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel_Bottom.Location = new System.Drawing.Point(0, 408);
			this.panel_Bottom.Name = "panel_Bottom";
			this.panel_Bottom.Size = new System.Drawing.Size(711, 47);
			this.panel_Bottom.TabIndex = 3;
			// 
			// textBox_Filter
			// 
			this.textBox_Filter.Location = new System.Drawing.Point(50, 14);
			this.textBox_Filter.Name = "textBox_Filter";
			this.textBox_Filter.Size = new System.Drawing.Size(138, 20);
			this.textBox_Filter.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 17);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Filter:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.listView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 69);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(711, 339);
			this.panel1.TabIndex = 4;
			// 
			// imageListStatus
			// 
			this.imageListStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListStatus.ImageStream")));
			this.imageListStatus.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListStatus.Images.SetKeyName(0, "Green.bmp");
			this.imageListStatus.Images.SetKeyName(1, "Red.BMP");
			// 
			// Form1
			// 
			this.AcceptButton = this.button_Go;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Close;
			this.ClientSize = new System.Drawing.Size(711, 455);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel_Bottom);
			this.Controls.Add(this.panel_Top);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Windows Service Status";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel_Top.ResumeLayout(false);
			this.panel_Top.PerformLayout();
			this.panel_Bottom.ResumeLayout(false);
			this.panel_Bottom.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.Button button_Close;
		private System.Windows.Forms.ColumnHeader columnHeader_Service;
		private System.Windows.Forms.ColumnHeader columnHeader_Status;
		private System.Windows.Forms.Panel panel_Top;
		private System.Windows.Forms.TextBox textBox_ComputerName;
		private System.Windows.Forms.Label label_ComputerName;
		private System.Windows.Forms.Panel panel_Bottom;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button_Go;
		private System.Windows.Forms.ImageList imageListStatus;
		private System.Windows.Forms.TextBox textBox_UserName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_Pwd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox_Domain;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_Filter;
		private System.Windows.Forms.Label label4;
	}
}

