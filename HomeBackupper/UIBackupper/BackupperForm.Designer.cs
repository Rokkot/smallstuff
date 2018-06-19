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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupperForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.contextMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStripGrid.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 365);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1427, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
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
            this.backupNowToolStripMenuItem});
            this.acctionsToolStripMenuItem.Name = "acctionsToolStripMenuItem";
            this.acctionsToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.acctionsToolStripMenuItem.Text = "Acctions";
            // 
            // backupNowToolStripMenuItem
            // 
            this.backupNowToolStripMenuItem.Name = "backupNowToolStripMenuItem";
            this.backupNowToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
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
            this.removeFolderToolStripMenuItem.Text = "Remove Folder";
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
            this.SizeInMbInBackup});
            this.dataGridView.ContextMenuStrip = this.contextMenuStripGrid;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(1427, 337);
            this.dataGridView.TabIndex = 3;
            // 
            // Folder
            // 
            this.Folder.HeaderText = "Folder";
            this.Folder.Name = "Folder";
            // 
            // NumOfSubs
            // 
            dataGridViewCellStyle2.Format = "N0";
            this.NumOfSubs.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumOfSubs.HeaderText = "# Sub Folders";
            this.NumOfSubs.Name = "NumOfSubs";
            // 
            // NumSubFoldersInBackup
            // 
            this.NumSubFoldersInBackup.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumSubFoldersInBackup.HeaderText = "# Sub Folders in Backup";
            this.NumSubFoldersInBackup.Name = "NumSubFoldersInBackup";
            // 
            // NumOfFiles
            // 
            this.NumOfFiles.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumOfFiles.HeaderText = "# Files";
            this.NumOfFiles.Name = "NumOfFiles";
            // 
            // NumFilesInBackup
            // 
            this.NumFilesInBackup.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumFilesInBackup.HeaderText = "# Files in Backup";
            this.NumFilesInBackup.Name = "NumFilesInBackup";
            // 
            // SizeMb
            // 
            this.SizeMb.DefaultCellStyle = dataGridViewCellStyle2;
            this.SizeMb.HeaderText = "Size (Bytes)";
            this.SizeMb.Name = "SizeMb";
            // 
            // SizeInMbInBackup
            // 
            this.SizeInMbInBackup.DefaultCellStyle = dataGridViewCellStyle2;
            this.SizeInMbInBackup.HeaderText = "Size in Backup (Bytes)";
            this.SizeInMbInBackup.Name = "SizeInMbInBackup";
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
            this.toolStripButtonAdd.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::Backupper.Properties.Resources.delete;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonRemove.Text = "Remove Folder";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.removeFolderToolStripMenuItem_Click);
            // 
            // BackupperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 387);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "BackupperForm";
            this.Text = "Backupper";
            this.Load += new System.EventHandler(this.BackupperForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStripGrid.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private DataGridViewTextBoxColumn Folder;
        private DataGridViewTextBoxColumn NumOfSubs;
        private DataGridViewTextBoxColumn NumSubFoldersInBackup;
        private DataGridViewTextBoxColumn NumOfFiles;
        private DataGridViewTextBoxColumn NumFilesInBackup;
        private DataGridViewTextBoxColumn SizeMb;
        private DataGridViewTextBoxColumn SizeInMbInBackup;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonRemove;
        //private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem1;
        //private System.Windows.Forms.ToolStripMenuItem removeFolderToolStripMenuItem1;
    }
}

