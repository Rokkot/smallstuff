using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using WinTrayUI;

namespace TrayUIFrameworkTest
{
	public partial class Form1 : Form
	{
        SerializableDictionary<string, Settings> m_Settings = null;
        SerializableDictionary<string, FolderInfo> m_FI = null;

        public Form1()
		{
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e)
        {
            m_Settings = new SerializableDictionary<string, Settings>();
            m_FI = new SerializableDictionary<string, FolderInfo>();

            f1();

            m_Settings.LoadData();
            m_FI.LoadData();
        }

        public void f1()
        {
            try
            {
                //SettingsConfigDict s = new SettingsConfigDict(InitSettingDictObjecForDebugModeSettingFileCreationDelegate);

                Settings _tSettings = null;

                _tSettings = new Settings();

                _tSettings.BackupDestinationRootPath = @"C:\Development";

                _tSettings.BackupTime = new DateTime(1, 1, 1, 5, 0, 0);

                _tSettings.BackupDays = (int)(enumWeekdays.Monday | enumWeekdays.Tuesday | enumWeekdays.Wednesday | enumWeekdays.Thursday | enumWeekdays.Friday);

                m_Settings.Add(_tSettings.GetUnitKey(), _tSettings);

                m_Settings.SaveData();

                // if(_tSettings.BackupDays & (int)enumWeekdays.Friday == (int)enumWeekdays.Friday)
                // if( _tSettings.BackupDays & (int)enumWeekdays.Friday > 0)

                FolderInfo fi = null;

                foreach (string path in Directory.GetDirectories(@"C:\Development"))
                {
                    fi = new FolderInfo();
                    fi.FolderSourcePath = path;
                    fi.NumberOfFilesInSource = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Count();
                    fi.NumberOfSubFolderInSource = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).Count();
                    m_FI.Add(fi.GetUnitKey(), fi);
                }

                m_FI.SaveData();                
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "cb720904-ae44-4536-9c72-e1d0828ef0bd");
            }
        }
    }
}
