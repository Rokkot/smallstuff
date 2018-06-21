using SettingBackupper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace BackupperService
{
    public class BackupManager
    {
        private SerializableDictionary<string, FolderInfo> m_FI = null;
        private TimeSpan m_tsSchedulerInterval = TimeSpan.Zero;
        private TimeSpan m_tsBackupperInterval = TimeSpan.Zero;
        private Thread m_tScheduler = null;
        private object m_oStartStopScheduler = null;
        private object m_oStartStopBackupper = null;
        private double m_dHoursToRun = -1.0;

        private Thread m_tBackupper = null;

        public BackupManager()
        {
            try
            {
                m_FI = new SerializableDictionary<string, FolderInfo>();
                //m_tsSchedulerInterval = TimeSpan.FromMinutes(1); // every 1 min
                m_tsSchedulerInterval = TimeSpan.FromSeconds(10); // every 5 min
                m_tsBackupperInterval = TimeSpan.FromSeconds(5); // 5 seconds
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "33d753ad-0064-41aa-9f32-1116e411a1a1");
            }
        }

        public bool StartScheduler()
        {
            try
            {
                m_oStartStopScheduler = new object();
                m_tScheduler = new Thread(SchedulerThread);
                m_tScheduler.IsBackground = true;
                m_tScheduler.Start(m_oStartStopScheduler);

                return true;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "84914a1d-220f-4fe4-a17d-9c1f5d6c13eb");
                return false;
            }
        }
        public void SchedulerThread(object oStop)
        {
            try
            {
                lock (oStop)
                {
                    while (true)
                    {
                        if (Monitor.Wait(oStop, m_tsSchedulerInterval) == true)
                        {
                            break;
                        }
                        else
                        {
                            // checked time and start backup process if needed.
                            if ((IsBackupDay() == true) && (IsBackupTime() == true))
                            {
                                // Start backup;
                                StartBackupper();
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "a4569866-14a5-411b-8bb9-f01a4412557f");
            }
        }

        private bool StartBackupper()
        {
            try
            {
                m_oStartStopBackupper = new object();
                m_tBackupper = new Thread(SchedulerThread);
                m_tBackupper.IsBackground = true;
                m_tBackupper.Start(m_oStartStopBackupper);

                return true;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "729d5f1f-e7ca-42a4-bda0-7713880f1403");
                return false;
            }
        }
        public void BackupperThread(object oStop)
        {
            try
            {
                lock (oStop)
                {
                    DateTime dtStartBackupHour = DateTime.Now;
                    List<string> lstFoldrs = null;
                    string sDestinationRoot = string.Empty;

                    lock (SettingsManager.Instance)
                    {
                        m_dHoursToRun = (double)SettingsManager.Instance.Settings.RunBackupForNHours;
                        sDestinationRoot = SettingsManager.Instance.Settings.BackupDestinationRootPath;
                    }

                    lock (m_FI)
                    {
                        m_FI.LoadData();
                        lstFoldrs = m_FI.KeysToList();
                    }

                    while (true)
                    {
                        if (Monitor.Wait(oStop, m_tsBackupperInterval) == true)
                        {
                            break;
                        }
                        else
                        {
                            // if backup is running less the hours to run from settings then continue. Otherwise stop backup
                            if(IsBackupRunningTooLong(dtStartBackupHour) == false)
                            {
                                if (lstFoldrs != null)
                                {
                                    foreach (string sPath in lstFoldrs)
                                    {
                                        BackupFilderSearch(sPath, sDestinationRoot, dtStartBackupHour);
                                    }
                                }
                            }
                            else
                            {
                                // the backup was running longer than defined by a user in the serrings
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "a4569866-14a5-411b-8bb9-f01a4412557f");
            }
        }

        private bool IsBackupRunningTooLong(DateTime _dtStartBackupHour)
        {
            try
            {
                // calculate number of hours the buckup is already running
                double dRunningHours = DateTime.Now.TimeOfDay.Subtract(_dtStartBackupHour.TimeOfDay).TotalHours;

                // if backup is running less the hours to run from settings then continue. Otherwise stop backup
                return (dRunningHours < m_dHoursToRun) ? false : true;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "45c3a960-c3ef-45a4-b0b4-96acba6f6d53");
            }

            return true;
        }
        void BackupFilderSearch(string _sStartDirSource, string _sStartDirDestination, DateTime _dtStartBackupHour)
        {
            try
            {
                string sFileName = string.Empty;
                string sDestFile = string.Empty;

                // let processor to breathe
                Thread.Sleep(100);

                if (IsBackupRunningTooLong(_dtStartBackupHour) == true)
                {
                    // stop backup
                    return;
                }

                _sStartDirDestination = Path.Combine(_sStartDirDestination, Path.GetDirectoryName(_sStartDirSource));

                if (Directory.Exists(_sStartDirDestination) == false)
                {
                    Directory.CreateDirectory(_sStartDirDestination);
                }

                foreach (string d in Directory.GetDirectories(_sStartDirSource))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        // copy all files in the folder
                        sFileName = Path.GetFileName(f);
                        sDestFile = Path.Combine(_sStartDirDestination, sFileName);
                        File.Copy(f, sDestFile, true);
                    }

                    BackupFilderSearch(d, _sStartDirDestination, _dtStartBackupHour);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "d9cddfe7-f013-4712-990a-1d9fc524d3e1");
            }
        }

        private bool IsBackupTime()
        {
            try
            {
                lock (SettingsManager.Instance)
                {
                    DateTime settingTime = SettingsManager.Instance.Settings.BackupTime;
                    TimeSpan timeDiff = DateTime.Now.TimeOfDay.Subtract(settingTime.TimeOfDay);

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

        private bool IsBackupDay()
        {
            try
            {
                bool bIsBackupDay = false;

                lock (SettingsManager.Instance)
                {
                    int iDaysOfWeek = SettingsManager.Instance.Settings.BackupDays;
                
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

        public void StopScheduler()
        {
            try
            {
                if (m_oStartStopScheduler != null)
                {
                    lock (m_oStartStopScheduler)
                    {

                        Monitor.Pulse(m_oStartStopScheduler);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "3fe69b77-4fa1-49c8-af7b-fc8b511a0047");
            }
        }

        public void StopBackupper()
        {
            try
            {
                if (m_oStartStopBackupper != null)
                {
                    lock (m_oStartStopBackupper)
                    {
                        m_dHoursToRun = 0.0001;
                        Monitor.Pulse(m_oStartStopBackupper);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "b3612ff3-47e7-48e4-91fc-03d2d455100e");
            }
        }
    }
}
