using SettingBackupper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace BackupperService
{
    public sealed class SettingsManager
    {
        private SerializableDictionary<string, Settings> m_dictSettings = null;
        private Settings m_Settings = null;

        private SettingsManager()
        {
            m_dictSettings = new SerializableDictionary<string, Settings>();
        }

        public void LoadSettings()
        {
            LoadSettings(false);
        }
        public void LoadSettings(bool _bReload)
        {
            try
            {
                if ((m_Settings == null)
                    || (_bReload == true))
                {
                    m_dictSettings.LoadData();

                    m_Settings = m_dictSettings[Settings.GetUnitKey()];
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "c80f7845-0a6c-45fd-a2b9-1694001ea607");
            }
        }

        public Settings Settings
        {
            get
            {
                if(m_Settings == null)
                {
                    LoadSettings(true);
                }

                return m_Settings;
            }
        }

        public static SettingsManager Instance
        {
            get
            {
                return Nested_BackupSetting.instance;
            }
        }

        private class Nested_BackupSetting
        {
            internal static readonly SettingsManager instance;

            static Nested_BackupSetting()
            {
                SettingsManager dummy = new SettingsManager();

                try
                {
                    dummy.LoadSettings(false);
                }
                catch (Exception exp)
                {
                    Logger.WriteError(exp, "81e34f85-d316-48ec-93e1-c5b5919ce87b");
                }


                instance = dummy;
            }
        }
    }
}
