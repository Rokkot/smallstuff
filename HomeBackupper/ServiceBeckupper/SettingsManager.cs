using SettingBackupper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using static Utils.Logger;

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

                    Logger.SetLogLevel((LoggingLevel)m_Settings.LogLevel);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "c80f7845-0a6c-45fd-a2b9-1694001ea607");
            }
        }

        public bool IsBackupRunningTooLong(DateTime _dtStartBackupHour)
        {
            try
            {
                // calculate number of hours the buckup is already running
                double dRunningHours = DateTime.Now.TimeOfDay.Subtract(_dtStartBackupHour.TimeOfDay).TotalHours;

                // if backup is running less the hours to run from settings then continue. Otherwise stop backup
                if((dRunningHours < m_Settings.RunBackupForNHours) || (m_Settings.RunBackupForNHours == 0))
                {
                    return false;
                }

                return true;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "45c3a960-c3ef-45a4-b0b4-96acba6f6d53");
            }

            return true;
        }

        public bool IsBackupTime()
        {
            try
            {
                lock (this)
                {
                    TimeSpan timeDiff = DateTime.Now.TimeOfDay.Subtract(m_Settings.BackupTime.TimeOfDay);

                    if ((timeDiff.TotalMinutes > 0)
                        && (timeDiff.TotalMinutes <= 3))
                    {
                        return true;
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "07cc3ee8-2b2e-4c91-8426-e2742ad76ea4");
            }

            return false;
        }

        public bool IsBackupDay()
        {
            try
            {
                bool bIsBackupDay = false;

                lock (this)
                {
                    int iDaysOfWeek = m_Settings.BackupDays;

                    if ((iDaysOfWeek & (int)enumWeekdays.All) == (int)enumWeekdays.All)
                        return true;

                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Sunday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Sunday) == (int)enumWeekdays.Sunday);
                            break;
                        case DayOfWeek.Monday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Monday) == (int)enumWeekdays.Monday);
                            break;
                        case DayOfWeek.Tuesday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Tuesday) == (int)enumWeekdays.Tuesday);
                            break;
                        case DayOfWeek.Wednesday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Wednesday) == (int)enumWeekdays.Wednesday);
                            break;
                        case DayOfWeek.Thursday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Thursday) == (int)enumWeekdays.Thursday);
                            break;
                        case DayOfWeek.Friday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Friday) == (int)enumWeekdays.Friday);
                            break;
                        case DayOfWeek.Saturday:
                            bIsBackupDay = ((iDaysOfWeek & (int)enumWeekdays.Saturday) == (int)enumWeekdays.Saturday);
                            break;
                        default:
                            bIsBackupDay = false;
                            break;
                    }
                }

                return bIsBackupDay;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "b8d6fb61-5764-4d87-9495-781ec9b2b212");
                return false;
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
