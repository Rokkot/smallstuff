namespace Backupper
{
    partial class SettingsForm
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
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_BackupAt = new System.Windows.Forms.DateTimePicker();
            this.label_Days = new System.Windows.Forms.Label();
            this.checkBoxSunday = new System.Windows.Forms.CheckBox();
            this.checkBoxMonday = new System.Windows.Forms.CheckBox();
            this.checkBoxTuesday = new System.Windows.Forms.CheckBox();
            this.checkBoxWednesday = new System.Windows.Forms.CheckBox();
            this.checkBoxThursday = new System.Windows.Forms.CheckBox();
            this.checkBoxFriday = new System.Windows.Forms.CheckBox();
            this.checkBoxSaturday = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.numericUpDown_RunForNHours = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageFolders = new System.Windows.Forms.TabPage();
            this.button_BrowseRoot = new System.Windows.Forms.Button();
            this.label_BrowseRoot = new System.Windows.Forms.Label();
            this.textBox_BackupRoot = new System.Windows.Forms.TextBox();
            this.checkBoxWatchFolders = new System.Windows.Forms.CheckBox();
            this.panel_OK_Cancel = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RunForNHours)).BeginInit();
            this.tabPageFolders.SuspendLayout();
            this.panel_OK_Cancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Save.Location = new System.Drawing.Point(344, 11);
            this.button_Save.Margin = new System.Windows.Forms.Padding(2);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(56, 19);
            this.button_Save.TabIndex = 0;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(405, 11);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(56, 19);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Backup at:";
            // 
            // dateTimePicker_BackupAt
            // 
            this.dateTimePicker_BackupAt.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_BackupAt.Location = new System.Drawing.Point(84, 20);
            this.dateTimePicker_BackupAt.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_BackupAt.Name = "dateTimePicker_BackupAt";
            this.dateTimePicker_BackupAt.ShowUpDown = true;
            this.dateTimePicker_BackupAt.Size = new System.Drawing.Size(86, 20);
            this.dateTimePicker_BackupAt.TabIndex = 3;
            this.dateTimePicker_BackupAt.Value = new System.DateTime(2018, 6, 18, 2, 0, 0, 0);
            // 
            // label_Days
            // 
            this.label_Days.AutoSize = true;
            this.label_Days.Location = new System.Drawing.Point(4, 44);
            this.label_Days.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Days.Name = "label_Days";
            this.label_Days.Size = new System.Drawing.Size(76, 13);
            this.label_Days.TabIndex = 4;
            this.label_Days.Text = "Backup every:";
            // 
            // checkBoxSunday
            // 
            this.checkBoxSunday.AutoSize = true;
            this.checkBoxSunday.Location = new System.Drawing.Point(84, 43);
            this.checkBoxSunday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSunday.Name = "checkBoxSunday";
            this.checkBoxSunday.Size = new System.Drawing.Size(62, 17);
            this.checkBoxSunday.TabIndex = 5;
            this.checkBoxSunday.Text = "Sunday";
            this.checkBoxSunday.UseVisualStyleBackColor = true;
            // 
            // checkBoxMonday
            // 
            this.checkBoxMonday.AutoSize = true;
            this.checkBoxMonday.Location = new System.Drawing.Point(157, 43);
            this.checkBoxMonday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxMonday.Name = "checkBoxMonday";
            this.checkBoxMonday.Size = new System.Drawing.Size(64, 17);
            this.checkBoxMonday.TabIndex = 6;
            this.checkBoxMonday.Text = "Monday";
            this.checkBoxMonday.UseVisualStyleBackColor = true;
            // 
            // checkBoxTuesday
            // 
            this.checkBoxTuesday.AutoSize = true;
            this.checkBoxTuesday.Location = new System.Drawing.Point(221, 43);
            this.checkBoxTuesday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxTuesday.Name = "checkBoxTuesday";
            this.checkBoxTuesday.Size = new System.Drawing.Size(67, 17);
            this.checkBoxTuesday.TabIndex = 7;
            this.checkBoxTuesday.Text = "Tuesday";
            this.checkBoxTuesday.UseVisualStyleBackColor = true;
            // 
            // checkBoxWednesday
            // 
            this.checkBoxWednesday.AutoSize = true;
            this.checkBoxWednesday.Location = new System.Drawing.Point(290, 43);
            this.checkBoxWednesday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxWednesday.Name = "checkBoxWednesday";
            this.checkBoxWednesday.Size = new System.Drawing.Size(83, 17);
            this.checkBoxWednesday.TabIndex = 8;
            this.checkBoxWednesday.Text = "Wednesday";
            this.checkBoxWednesday.UseVisualStyleBackColor = true;
            // 
            // checkBoxThursday
            // 
            this.checkBoxThursday.AutoSize = true;
            this.checkBoxThursday.Location = new System.Drawing.Point(84, 65);
            this.checkBoxThursday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxThursday.Name = "checkBoxThursday";
            this.checkBoxThursday.Size = new System.Drawing.Size(70, 17);
            this.checkBoxThursday.TabIndex = 9;
            this.checkBoxThursday.Text = "Thursday";
            this.checkBoxThursday.UseVisualStyleBackColor = true;
            // 
            // checkBoxFriday
            // 
            this.checkBoxFriday.AutoSize = true;
            this.checkBoxFriday.Location = new System.Drawing.Point(157, 65);
            this.checkBoxFriday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxFriday.Name = "checkBoxFriday";
            this.checkBoxFriday.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFriday.TabIndex = 10;
            this.checkBoxFriday.Text = "Friday";
            this.checkBoxFriday.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaturday
            // 
            this.checkBoxSaturday.AutoSize = true;
            this.checkBoxSaturday.Location = new System.Drawing.Point(221, 65);
            this.checkBoxSaturday.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxSaturday.Name = "checkBoxSaturday";
            this.checkBoxSaturday.Size = new System.Drawing.Size(68, 17);
            this.checkBoxSaturday.TabIndex = 11;
            this.checkBoxSaturday.Text = "Saturday";
            this.checkBoxSaturday.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSchedule);
            this.tabControl1.Controls.Add(this.tabPageFolders);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(470, 197);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.numericUpDown_RunForNHours);
            this.tabPageSchedule.Controls.Add(this.label3);
            this.tabPageSchedule.Controls.Add(this.label2);
            this.tabPageSchedule.Controls.Add(this.checkBoxTuesday);
            this.tabPageSchedule.Controls.Add(this.label1);
            this.tabPageSchedule.Controls.Add(this.checkBoxMonday);
            this.tabPageSchedule.Controls.Add(this.checkBoxSaturday);
            this.tabPageSchedule.Controls.Add(this.checkBoxWednesday);
            this.tabPageSchedule.Controls.Add(this.dateTimePicker_BackupAt);
            this.tabPageSchedule.Controls.Add(this.checkBoxSunday);
            this.tabPageSchedule.Controls.Add(this.checkBoxFriday);
            this.tabPageSchedule.Controls.Add(this.checkBoxThursday);
            this.tabPageSchedule.Controls.Add(this.label_Days);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageSchedule.Size = new System.Drawing.Size(462, 171);
            this.tabPageSchedule.TabIndex = 0;
            this.tabPageSchedule.Text = "Schedule";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_RunForNHours
            // 
            this.numericUpDown_RunForNHours.Location = new System.Drawing.Point(84, 87);
            this.numericUpDown_RunForNHours.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_RunForNHours.Name = "numericUpDown_RunForNHours";
            this.numericUpDown_RunForNHours.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown_RunForNHours.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(135, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "hours. The number of hours the backup will run. To run backup untill it is comple" +
    "te set 0.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Backup for:";
            // 
            // tabPageFolders
            // 
            this.tabPageFolders.Controls.Add(this.button_BrowseRoot);
            this.tabPageFolders.Controls.Add(this.label_BrowseRoot);
            this.tabPageFolders.Controls.Add(this.textBox_BackupRoot);
            this.tabPageFolders.Controls.Add(this.checkBoxWatchFolders);
            this.tabPageFolders.Location = new System.Drawing.Point(4, 22);
            this.tabPageFolders.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageFolders.Name = "tabPageFolders";
            this.tabPageFolders.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageFolders.Size = new System.Drawing.Size(462, 171);
            this.tabPageFolders.TabIndex = 1;
            this.tabPageFolders.Text = "Folders";
            this.tabPageFolders.UseVisualStyleBackColor = true;
            // 
            // button_BrowseRoot
            // 
            this.button_BrowseRoot.Location = new System.Drawing.Point(394, 5);
            this.button_BrowseRoot.Margin = new System.Windows.Forms.Padding(2);
            this.button_BrowseRoot.Name = "button_BrowseRoot";
            this.button_BrowseRoot.Size = new System.Drawing.Size(56, 19);
            this.button_BrowseRoot.TabIndex = 3;
            this.button_BrowseRoot.Text = "...";
            this.button_BrowseRoot.UseVisualStyleBackColor = true;
            this.button_BrowseRoot.Click += new System.EventHandler(this.button_BrowseRoot_Click);
            // 
            // label_BrowseRoot
            // 
            this.label_BrowseRoot.AutoSize = true;
            this.label_BrowseRoot.Location = new System.Drawing.Point(6, 7);
            this.label_BrowseRoot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_BrowseRoot.Name = "label_BrowseRoot";
            this.label_BrowseRoot.Size = new System.Drawing.Size(88, 13);
            this.label_BrowseRoot.TabIndex = 2;
            this.label_BrowseRoot.Text = "Backup to folder:";
            // 
            // textBox_BackupRoot
            // 
            this.textBox_BackupRoot.Location = new System.Drawing.Point(97, 5);
            this.textBox_BackupRoot.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_BackupRoot.Name = "textBox_BackupRoot";
            this.textBox_BackupRoot.ReadOnly = true;
            this.textBox_BackupRoot.Size = new System.Drawing.Size(282, 20);
            this.textBox_BackupRoot.TabIndex = 1;
            // 
            // checkBoxWatchFolders
            // 
            this.checkBoxWatchFolders.AutoSize = true;
            this.checkBoxWatchFolders.Location = new System.Drawing.Point(8, 35);
            this.checkBoxWatchFolders.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxWatchFolders.Name = "checkBoxWatchFolders";
            this.checkBoxWatchFolders.Size = new System.Drawing.Size(92, 17);
            this.checkBoxWatchFolders.TabIndex = 0;
            this.checkBoxWatchFolders.Text = "Watch folders";
            this.checkBoxWatchFolders.UseVisualStyleBackColor = true;
            // 
            // panel_OK_Cancel
            // 
            this.panel_OK_Cancel.Controls.Add(this.button_Cancel);
            this.panel_OK_Cancel.Controls.Add(this.button_Save);
            this.panel_OK_Cancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OK_Cancel.Location = new System.Drawing.Point(0, 158);
            this.panel_OK_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.panel_OK_Cancel.Name = "panel_OK_Cancel";
            this.panel_OK_Cancel.Size = new System.Drawing.Size(470, 39);
            this.panel_OK_Cancel.TabIndex = 15;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.button_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(470, 197);
            this.ControlBox = false;
            this.Controls.Add(this.panel_OK_Cancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSchedule.ResumeLayout(false);
            this.tabPageSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RunForNHours)).EndInit();
            this.tabPageFolders.ResumeLayout(false);
            this.tabPageFolders.PerformLayout();
            this.panel_OK_Cancel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_BackupAt;
        private System.Windows.Forms.Label label_Days;
        private System.Windows.Forms.CheckBox checkBoxSunday;
        private System.Windows.Forms.CheckBox checkBoxMonday;
        private System.Windows.Forms.CheckBox checkBoxTuesday;
        private System.Windows.Forms.CheckBox checkBoxWednesday;
        private System.Windows.Forms.CheckBox checkBoxThursday;
        private System.Windows.Forms.CheckBox checkBoxFriday;
        private System.Windows.Forms.CheckBox checkBoxSaturday;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.TabPage tabPageFolders;
        private System.Windows.Forms.Panel panel_OK_Cancel;
        private System.Windows.Forms.CheckBox checkBoxWatchFolders;
        private System.Windows.Forms.Button button_BrowseRoot;
        private System.Windows.Forms.Label label_BrowseRoot;
        private System.Windows.Forms.TextBox textBox_BackupRoot;
        private System.Windows.Forms.NumericUpDown numericUpDown_RunForNHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}