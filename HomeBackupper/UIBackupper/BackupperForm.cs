using SettingBackupper;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Backupper
{
    public partial class BackupperForm : Form
    {
        private SerializableDictionary<string, FolderInfo> m_FI = null;
        private string m_sInitialFolderPath = string.Empty;
        private long m_lFilesToBackup = 0L;
        private long m_lBackedFiles = 0L;
        private long m_lSizeToBackup = 0L;
        private long m_lBackupSize = 0L;

        public BackupperForm()
        {
            m_FI = new SerializableDictionary<string, FolderInfo>();
            InitializeComponent();
        }

        private void BackupperForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_FI.LoadData();

                foreach (FolderInfo fi in m_FI.ValuesToList())
                {
                    this.dataGridView.Rows.Add(fi.FolderSourcePath
                                               , fi.NumberOfSubFolderInSource
                                               , fi.NumberOfSubFoldersInDestination
                                               , fi.NumberOfFilesInSource
                                               , fi.SizeOfFolderInDestination
                                               , fi.SizeOfFolderInSource
                                               , fi.SizeOfFolderInDestination
                                               , fi.IsDeleted);

                    m_lBackedFiles += fi.NumberOfFilesInDestination;
                    m_lBackupSize += fi.SizeOfFolderInDestination;
                    m_lFilesToBackup += fi.NumberOfFilesInSource;
                    m_lSizeToBackup += fi.SizeOfFolderInSource;

                    if (fi.IsDeleted == true)
                    {
                        RemoveRestoreRow(this.dataGridView.Rows[this.dataGridView.Rows.Count - 1]);
                    }
                }

                toolStripStatusLabel_FilesToBackup.Text = GetFormatedNumber(m_lFilesToBackup);
                toolStripStatusLabel_SizeToBackup.Text = GetFormatedNumberInGB(m_lSizeToBackup);
                toolStripStatusLabel_BackupSize.Text = GetFormatedNumberInGB(m_lBackupSize);
                toolStripStatusLabel_FilesInBackup.Text = GetFormatedNumber(m_lBackedFiles);

                this.dataGridView.AutoResizeColumns();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "eae5b998-667d-47ea-b21e-9dbfbd7ea88a");
                Logger.ShowErrorMessageBox(exp, "Failed to load data.");
            }
        }

        private string GetFormatedNumberInGB(long _lNumber)
        {
            return string.Format("{0:0.##}", (double)_lNumber/1024/1024/1024);
        }

        private string GetFormatedNumber(long _lNumber)
        {
            return string.Format("{0:N0}", _lNumber);
        }

        private void RemoveRestoreRow(DataGridViewRow _row)
        {
            try
            {
                if ((bool)_row.Cells["IsDeleted"].Value == true)
                {
                    _row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Strikeout);
                }
                else
                {
                    _row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "29668dba-8bdb-41ab-abe1-f98947702107");
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog(this);
        }

        private void removeFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sbRemoved = new StringBuilder();
                StringBuilder sbRestored = new StringBuilder();

                foreach (DataGridViewRow row in this.dataGridView.SelectedRows)
                {
                    if ((bool)row.Cells["IsDeleted"].Value == true)
                    {
                        row.Cells["IsDeleted"].Value = false;
                        sbRestored.AppendLine((string)row.Cells["Folder"].Value);
                    }
                    else
                    {
                        row.Cells["IsDeleted"].Value = true;
                        sbRemoved.AppendLine((string)row.Cells["Folder"].Value);
                    }

                    RemoveRestoreRow(row);                    
                }

                SaveGridData();

                string sRemoved = string.Empty;
                string sRestored = string.Empty;

                if (sbRemoved.Length > 0)
                {
                    sRemoved = string.Format("The following folder(s) will be removed from the backup list during the next backup session:\r\n{0}\r\n\r\n", sbRemoved.ToString());
                }

                if (sbRestored.Length > 0)
                {
                    sRestored = string.Format("The following folder(s) restored in the backup list:\r\n{0}", sbRestored.ToString());
                }

                Logger.ShowInfoMessageBox("{0}{1}", sRemoved, sRestored);
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "fbf079f4-399d-43aa-9278-a14f4ea9eff3");
                Logger.ShowErrorMessageBox(exp, "Failed to remove folder.");
            }
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog fb = new FolderBrowserDialog())
                {
                    fb.RootFolder = Environment.SpecialFolder.MyComputer;

                    if (string.IsNullOrWhiteSpace(m_sInitialFolderPath) == false)
                    {
                        fb.SelectedPath = m_sInitialFolderPath;
                    }

                    fb.Description = "Select a folder you'd like to backup";

                    fb.ShowNewFolderButton = false;
                    if (fb.ShowDialog(this) == DialogResult.OK)
                    {
                        m_sInitialFolderPath = fb.SelectedPath;

                        if (IsFolderParentInBackup(m_sInitialFolderPath) == false)
                        {
                            long lFiles = (long)Directory.GetFiles(m_sInitialFolderPath, "*.*", SearchOption.AllDirectories).Count();

                            this.dataGridView.Rows.Add(m_sInitialFolderPath
                                                        , (long)Directory.GetDirectories(m_sInitialFolderPath, "*", SearchOption.AllDirectories).Count()
                                                        , (long)0 // number of sub-folders in backup
                                                        , lFiles
                                                        , (long)0 // number of files in backup
                                                        , GetFolderSizeInMb(m_sInitialFolderPath)
                                                        , (long)0 // size of foldes in backup
                                                        , false);

                            m_lFilesToBackup += lFiles;

                            toolStripStatusLabel_FilesToBackup.Text = m_lFilesToBackup.ToString();

                            SaveGridData();
                        }
                        else
                        {
                            Logger.ShowInfoMessageBox("The specified path has been already added to the list of backed up folders.");
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "fbe6d5ce-57bb-4b04-9bea-2c82d9bed12b");
                Logger.ShowErrorMessageBox(exp, "Failed to add folder.");
            }
        }

        private long GetFolderSizeInMb(string _sFolderPath)
        {
           long lSize = GetFolderSize(new DirectoryInfo(_sFolderPath));

            return lSize;//(int)lSize / 1024 / 1024 / 1024;
        }

        private long GetFolderSize(DirectoryInfo dir)
        {
            try
            {
                return dir.GetFiles().Sum(fi => fi.Length) +
                       dir.GetDirectories().Sum(di => GetFolderSize(di));
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "98fbf9c4-c2bc-4ab2-b1d7-12ec77b11e12");
                return 0;
            }
        }

        private void SaveGridData()
        {
            try
            {
                if (this.dataGridView.Rows != null)
                {
                    foreach (DataGridViewRow row in this.dataGridView.Rows)
                    {
                        FolderInfo fi = new FolderInfo();

                        fi.FolderSourcePath = (string)row.Cells["Folder"].Value;
                        fi.NumberOfSubFolderInSource = (long)row.Cells["NumOfSubs"].Value;
                        fi.NumberOfSubFoldersInDestination = (long)row.Cells["NumSubFoldersInBackup"].Value;
                        fi.NumberOfFilesInSource = (long)row.Cells["NumOfFiles"].Value;
                        fi.NumberOfSubFoldersInDestination = (long)row.Cells["NumFilesInBackup"].Value;
                        fi.SizeOfFolderInSource = (long)row.Cells["SizeMb"].Value;
                        fi.SizeOfFolderInDestination = (long)row.Cells["SizeInMbInBackup"].Value;
                        fi.IsDeleted = (bool)row.Cells["IsDeleted"].Value;

                        m_FI.Add(fi.GetUnitKey(), fi);
                    }

                    m_FI.SaveData();
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "9723c66b-45b6-4a8a-b000-f27afd28f1c1");
                Logger.ShowErrorMessageBox(exp, "Failed to save folder list.");
            }
        }

        public bool IsFolderParentInBackup(string _sCandidate)
        {
            try
            {
                foreach (FolderInfo fi in m_FI.ValuesToList())
                {
                    if (IsFolderParentInBackup(_sCandidate, fi.FolderSourcePath) == true)
                    {
                        return true;
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "615465ee-60a1-41fa-bdf3-494f1b465687");
            }

            return false;
        }

        public bool IsFolderParentInBackup(string _sCandidate, string _sOther)
        {
            bool bIsChild = false;

            try
            {
                DirectoryInfo candidateInfo = new DirectoryInfo(_sCandidate);
                DirectoryInfo otherInfo = new DirectoryInfo(_sOther);

                while (candidateInfo.Parent != null)
                {
                    if (candidateInfo.Parent.FullName == otherInfo.FullName)
                    {
                        bIsChild = true;
                        break;
                    }
                    else
                    {
                        candidateInfo = candidateInfo.Parent;
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "21362a51-490a-4a05-81b8-17b8b4e452af");
                return false;
            }

            return bIsChild;
        }
    }
}
