using System.Drawing;
using System.Windows.Forms;

namespace Backupper
{
    partial class BackupperForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupperForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_FilesToBackupLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_FilesToBackup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_FilesInBackup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_SizeToBackup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_BackupSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeRestoreFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfSubs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumSubFoldersInBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumOfFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumFilesInBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeMb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeInMbInBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_FilesToBackupLabel,
            this.toolStripStatusLabel_FilesToBackup,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel_FilesInBackup,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel_SizeToBackup,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel_BackupSize});
            this.statusStrip.Location = new System.Drawing.Point(0, 362);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1427, 25);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_FilesToBackupLabel
            // 
            this.toolStripStatusLabel_FilesToBackupLabel.Name = "toolStripStatusLabel_FilesToBackupLabel";
            this.toolStripStatusLabel_FilesToBackupLabel.Size = new System.Drawing.Size(111, 20);
            this.toolStripStatusLabel_FilesToBackupLabel.Text = "Files to Backup:";
            // 
            // toolStripStatusLabel_FilesToBackup
            // 
            this.toolStripStatusLabel_FilesToBackup.Name = "toolStripStatusLabel_FilesToBackup";
            this.toolStripStatusLabel_FilesToBackup.Size = new System.Drawing.Size(57, 20);
            this.toolStripStatusLabel_FilesToBackup.Text = "111111";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(37, 20);
            this.toolStripStatusLabel5.Text = "   |   ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(109, 20);
            this.toolStripStatusLabel6.Text = "Files in Backup:";
            // 
            // toolStripStatusLabel_FilesInBackup
            // 
            this.toolStripStatusLabel_FilesInBackup.Name = "toolStripStatusLabel_FilesInBackup";
            this.toolStripStatusLabel_FilesInBackup.Size = new System.Drawing.Size(57, 20);
            this.toolStripStatusLabel_FilesInBackup.Text = "111111";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 20);
            this.toolStripStatusLabel1.Text = "   |   ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(138, 20);
            this.toolStripStatusLabel4.Text = "Size to Backup(Gb):";
            // 
            // toolStripStatusLabel_SizeToBackup
            // 
            this.toolStripStatusLabel_SizeToBackup.Name = "toolStripStatusLabel_SizeToBackup";
            this.toolStripStatusLabel_SizeToBackup.Size = new System.Drawing.Size(73, 20);
            this.toolStripStatusLabel_SizeToBackup.Text = "33333333";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(37, 20);
            this.toolStripStatusLabel3.Text = "   |   ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(120, 20);
            this.toolStripStatusLabel2.Text = "Backup Size(Gb):";
            // 
            // toolStripStatusLabel_BackupSize
            // 
            this.toolStripStatusLabel_BackupSize.Name = "toolStripStatusLabel_BackupSize";
            this.toolStripStatusLabel_BackupSize.Size = new System.Drawing.Size(73, 20);
            this.toolStripStatusLabel_BackupSize.Text = "33333333";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.acctionsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1427, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // acctionsToolStripMenuItem
            // 
            this.acctionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem1,
            this.removeRestoreFolderToolStripMenuItem,
            this.backupNowToolStripMenuItem});
            this.acctionsToolStripMenuItem.Name = "acctionsToolStripMenuItem";
            this.acctionsToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.acctionsToolStripMenuItem.Text = "Acctions";
            // 
            // addFolderToolStripMenuItem1
            // 
            this.addFolderToolStripMenuItem1.Image = global::Backupper.Properties.Resources.add;
            this.addFolderToolStripMenuItem1.Name = "addFolderToolStripMenuItem1";
            this.addFolderToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addFolderToolStripMenuItem1.Size = new System.Drawing.Size(272, 26);
            this.addFolderToolStripMenuItem1.Text = "Add Folder";
            this.addFolderToolStripMenuItem1.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // removeRestoreFolderToolStripMenuItem
            // 
            this.removeRestoreFolderToolStripMenuItem.Image = global::Backupper.Properties.Resources.delete;
            this.removeRestoreFolderToolStripMenuItem.Name = "removeRestoreFolderToolStripMenuItem";
            this.removeRestoreFolderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeRestoreFolderToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.removeRestoreFolderToolStripMenuItem.Text = "Remove/Restore Folder";
            this.removeRestoreFolderToolStripMenuItem.Click += new System.EventHandler(this.removeFolderToolStripMenuItem_Click);
            // 
            // backupNowToolStripMenuItem
            // 
            this.backupNowToolStripMenuItem.Image = global::Backupper.Properties.Resources.Backupper_png;
            this.backupNowToolStripMenuItem.Name = "backupNowToolStripMenuItem";
            this.backupNowToolStripMenuItem.Size = new System.Drawing.Size(272, 26);
            this.backupNowToolStripMenuItem.Text = "Backup Now";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Image = global::Backupper.Properties.Resources.add;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // removeFolderToolStripMenuItem
            // 
            this.removeFolderToolStripMenuItem.Image = global::Backupper.Properties.Resources.delete;
            this.removeFolderToolStripMenuItem.Name = "removeFolderToolStripMenuItem";
            this.removeFolderToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.removeFolderToolStripMenuItem.Text = "Remove/Restore Folder";
            this.removeFolderToolStripMenuItem.Click += new System.EventHandler(this.removeFolderToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folder,
            this.NumOfSubs,
            this.NumSubFoldersInBackup,
            this.NumOfFiles,
            this.NumFilesInBackup,
            this.SizeMb,
            this.SizeInMbInBackup,
            this.IsDeleted});
            this.dataGridView.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1427, 307);
            this.dataGridView.TabIndex = 3;
            // 
            // Folder
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Folder.DefaultCellStyle = dataGridViewCellStyle2;
            this.Folder.HeaderText = "Folder";
            this.Folder.Name = "Folder";
            this.Folder.ReadOnly = true;
            // 
            // NumOfSubs
            // 
            dataGridViewCellStyle3.Format = "N0";
            this.NumOfSubs.DefaultCellStyle = dataGridViewCellStyle3;
            this.NumOfSubs.HeaderText = "# Sub Folders";
            this.NumOfSubs.Name = "NumOfSubs";
            this.NumOfSubs.ReadOnly = true;
            // 
            // NumSubFoldersInBackup
            // 
            dataGridViewCellStyle4.Format = "N0";
            this.NumSubFoldersInBackup.DefaultCellStyle = dataGridViewCellStyle4;
            this.NumSubFoldersInBackup.HeaderText = "# Sub Folders in Backup";
            this.NumSubFoldersInBackup.Name = "NumSubFoldersInBackup";
            this.NumSubFoldersInBackup.ReadOnly = true;
            // 
            // NumOfFiles
            // 
            dataGridViewCellStyle5.Format = "N0";
            this.NumOfFiles.DefaultCellStyle = dataGridViewCellStyle5;
            this.NumOfFiles.HeaderText = "# Files";
            this.NumOfFiles.Name = "NumOfFiles";
            this.NumOfFiles.ReadOnly = true;
            // 
            // NumFilesInBackup
            // 
            dataGridViewCellStyle6.Format = "N0";
            this.NumFilesInBackup.DefaultCellStyle = dataGridViewCellStyle6;
            this.NumFilesInBackup.HeaderText = "# Files in Backup";
            this.NumFilesInBackup.Name = "NumFilesInBackup";
            this.NumFilesInBackup.ReadOnly = true;
            // 
            // SizeMb
            // 
            dataGridViewCellStyle7.Format = "N0";
            this.SizeMb.DefaultCellStyle = dataGridViewCellStyle7;
            this.SizeMb.HeaderText = "Size (Bytes)";
            this.SizeMb.Name = "SizeMb";
            this.SizeMb.ReadOnly = true;
            // 
            // SizeInMbInBackup
            // 
            dataGridViewCellStyle8.Format = "N0";
            this.SizeInMbInBackup.DefaultCellStyle = dataGridViewCellStyle8;
            this.SizeInMbInBackup.HeaderText = "Size in Backup (Bytes)";
            this.SizeInMbInBackup.Name = "SizeInMbInBackup";
            this.SizeInMbInBackup.ReadOnly = true;
            // 
            // IsDeleted
            // 
            this.IsDeleted.HeaderText = "IsDeleted";
            this.IsDeleted.Name = "IsDeleted";
            this.IsDeleted.ReadOnly = true;
            this.IsDeleted.Visible = false;
            // 
            // contextMenuStripGrid
            // 
            this.contextMenuStripGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderToolStripMenuItem,
            this.removeFolderToolStripMenuItem});
            this.contextMenuStripGrid.Name = "contextMenuStripGrid";
            this.contextMenuStripGrid.Size = new System.Drawing.Size(183, 56);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1427, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::Backupper.Properties.Resources.add;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonAdd.Text = "Add Folder";
            this.toolStripButtonAdd.ToolTipText = "Add folder to the backup list.";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::Backupper.Properties.Resources.delete;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRemove.Text = "Remove/Restore Folder";
            this.toolStripButtonRemove.ToolTipText = "Remove or Restore a folder from/in the backup list.";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.removeFolderToolStripMenuItem_Click);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dataGridView);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 55);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1427, 307);
            this.panelGrid.TabIndex = 5;
            // 
            // BackupperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 387);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "BackupperForm";
            this.Text = "Backupper";
            this.Load += new System.EventHandler(this.BackupperForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acctionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGrid;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonRemove;
        private ToolStripMenuItem addFolderToolStripMenuItem1;
        private ToolStripMenuItem removeRestoreFolderToolStripMenuItem;
        private Panel panelGrid;
        private ToolStripStatusLabel toolStripStatusLabel_FilesToBackupLabel;
        private ToolStripStatusLabel toolStripStatusLabel_FilesToBackup;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel_BackupSize;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel_SizeToBackup;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel toolStripStatusLabel6;
        private ToolStripStatusLabel toolStripStatusLabel_FilesInBackup;
        private DataGridViewTextBoxColumn Folder;
        private DataGridViewTextBoxColumn NumOfSubs;
        private DataGridViewTextBoxColumn NumSubFoldersInBackup;
        private DataGridViewTextBoxColumn NumOfFiles;
        private DataGridViewTextBoxColumn NumFilesInBackup;
        private DataGridViewTextBoxColumn SizeMb;
        private DataGridViewTextBoxColumn SizeInMbInBackup;
        private DataGridViewCheckBoxColumn IsDeleted;
        //private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem1;
        //private System.Windows.Forms.ToolStripMenuItem removeFolderToolStripMenuItem1;
    }
}

