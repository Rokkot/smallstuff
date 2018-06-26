using SettingBackupper;
using System;
using System.Windows.Forms;
using Utils;

namespace Backupper
{
    public partial class SettingsForm : Form
    {
        private SerializableDictionary<string, Settings> m_dictSettings = null;
        private Settings m_Settings = null;

        public SettingsForm()
        {
            m_dictSettings = new SerializableDictionary<string, Settings>();

            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                m_dictSettings.LoadData();

                m_Settings = m_dictSettings[Settings.GetUnitKey()];

                if (m_Settings != null)
                {
                    checkBoxMonday.Checked = IsDayChecked(enumWeekdays.Monday, m_Settings.BackupDays);
                    checkBoxTuesday.Checked = IsDayChecked(enumWeekdays.Tuesday, m_Settings.BackupDays);
                    checkBoxWednesday.Checked = IsDayChecked(enumWeekdays.Wednesday, m_Settings.BackupDays);
                    checkBoxThursday.Checked = IsDayChecked(enumWeekdays.Thursday, m_Settings.BackupDays);
                    checkBoxFriday.Checked = IsDayChecked(enumWeekdays.Friday, m_Settings.BackupDays);
                    checkBoxSaturday.Checked = IsDayChecked(enumWeekdays.Saturday, m_Settings.BackupDays);
                    checkBoxSunday.Checked = IsDayChecked(enumWeekdays.Sunday, m_Settings.BackupDays);

                    dateTimePicker_BackupAt.Value = m_Settings.BackupTime;

                    numericUpDown_RunForNHours.Value = m_Settings.RunBackupForNHours;

                    textBox_BackupRoot.Text = m_Settings.BackupDestinationRootPath;

                    checkBoxWatchFolders.Checked = m_Settings.WatchFolders;
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "8a8d680d-5cc4-4783-b0df-db06a4338309");
            }
        }
        
        private bool IsDayChecked(enumWeekdays _eDays, int _iBackupDays)
        {
            try
            {
                return ((_iBackupDays & (int)_eDays) == (int)_eDays);
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "3e70b0fe-34ba-49f7-b21a-0edc706f9610");
                return false;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_Settings == null)
                {
                    m_Settings = new Settings();
                }

                m_Settings.BackupDays |= (checkBoxMonday.Checked) ? (int)enumWeekdays.Monday : 0;
                m_Settings.BackupDays |= (checkBoxTuesday.Checked) ? (int)enumWeekdays.Tuesday : 0;
                m_Settings.BackupDays |= (checkBoxWednesday.Checked) ? (int)enumWeekdays.Wednesday : 0;
                m_Settings.BackupDays |= (checkBoxThursday.Checked) ? (int)enumWeekdays.Thursday : 0;
                m_Settings.BackupDays |= (checkBoxFriday.Checked) ? (int)enumWeekdays.Friday : 0;
                m_Settings.BackupDays |= (checkBoxSaturday.Checked) ? (int)enumWeekdays.Saturday : 0;
                m_Settings.BackupDays |= (checkBoxSunday.Checked) ? (int)enumWeekdays.Sunday : 0;

                m_Settings.BackupTime = dateTimePicker_BackupAt.Value;

                m_Settings.BackupDestinationRootPath = textBox_BackupRoot.Text;

                m_Settings.WatchFolders = checkBoxWatchFolders.Checked;

                m_Settings.RunBackupForNHours = (int)numericUpDown_RunForNHours.Value;

                m_dictSettings.Add(Settings.GetUnitKey(), m_Settings);


                m_dictSettings.SaveData();

                this.Close();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "e59c96fd-58d0-421f-9be1-ca96641f12bd");

                Logger.ShowErrorMessageBox(exp, "Failed to save settings to file.");
            }
        }

        private void button_BrowseRoot_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog())
            {
                fb.SelectedPath = textBox_BackupRoot.Text;

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    textBox_BackupRoot.Text = fb.SelectedPath;
                }
            }
        }
    }
}
