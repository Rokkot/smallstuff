using LocalBackup;
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
        private TimeSpan m_tsSchedulerInterval = TimeSpan.Zero;
        private TimeSpan m_tsBackupManagerInterval = TimeSpan.Zero;
        private Thread m_tSchedulerThread = null;
        private object m_oStartStopScheduler = null;
        private object m_oStartStopBackupManager = null;

        private Thread m_tBackupManagerThread = null;

        private Backup<Local> m_LocalBackup = null;

        public BackupManager()
        {
            try
            {
                //m_tsSchedulerInterval = TimeSpan.FromMinutes(1); // every 1 min
                m_tsSchedulerInterval = TimeSpan.FromSeconds(10); // every 5 min
                m_tsBackupManagerInterval = TimeSpan.FromSeconds(5); // 5 seconds

                m_LocalBackup = new Backup<Local>();
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "33d753ad-0064-41aa-9f32-1116e411a1a1");
            }
        }

        public bool StartSchedulerThread()
        {
            try
            {
                if (m_oStartStopScheduler == null)
                {
                    m_oStartStopScheduler = new object();
                }

                if (m_tSchedulerThread == null)
                {
                    m_tSchedulerThread = new Thread(SchedulerThread);
                }

                m_tSchedulerThread.IsBackground = true;
                m_tSchedulerThread.Start(m_oStartStopScheduler);

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
                            if ((SettingsManager.Instance.IsBackupDay() == true) && (SettingsManager.Instance.IsBackupTime() == true))
                            {
                                // Start backup;
                                StartBackupManagerThread();

                                // Stop this thread while the backupper thread is running.
                                // This thread will be restarted once backupper thread is done.
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

        public void StopSchedulerThread()
        {
            try
            {
                if (m_oStartStopScheduler != null)
                {
                    lock (m_oStartStopScheduler)
                    {
                        Monitor.Pulse(m_oStartStopScheduler);
                    }

                    Thread.Sleep(1000);

                    if ((m_tSchedulerThread != null) && (m_tSchedulerThread.ThreadState == ThreadState.Stopped))
                    {
                        m_tSchedulerThread = null;
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "3fe69b77-4fa1-49c8-af7b-fc8b511a0047");
            }
        }

        public bool StartBackupManagerThread()
        {
            try
            {
                if (m_oStartStopBackupManager == null)
                {
                    m_oStartStopBackupManager = new object();
                }

                if (m_tBackupManagerThread == null)
                {
                    m_tBackupManagerThread = new Thread(BackupManagerThread);
                }

                m_tBackupManagerThread.IsBackground = true;
                m_tBackupManagerThread.Start(m_oStartStopBackupManager);

                return true;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "6f7956fd-c063-4f0e-998b-4448d924e453");
                return false;
            }
        }

        public void BackupManagerThread(object oStop)
        {
            try
            {
                lock (oStop)
                {
                    DateTime dtStartBackupHour = DateTime.Now;

                    StopSchedulerThread();
                    Thread.Sleep(3000);
                    m_LocalBackup.StartThread();

                    while (true)
                    {
                        if (Monitor.Wait(oStop, m_tsBackupManagerInterval) == true)
                        {
                            // stop Backup thread
                            m_LocalBackup.StopThread();
                            break;
                        }
                        else
                        {
                            if (m_LocalBackup.IsBackupRunning == false)
                            {
                                m_LocalBackup.StopThread();
                                Thread.Sleep(3000);
                                StartSchedulerThread();
                                break;
                            }

                            // checked time and start backup process if needed.
                            if (SettingsManager.Instance.IsBackupRunningTooLong(dtStartBackupHour) == true)
                            {
                                // Stop backup;
                                m_LocalBackup.StopThread();
                                Thread.Sleep(3000);
                                StartSchedulerThread();

                                // Stop this thread while the backupper thread is running.
                                // This thread will be restarted once backupper thread is done.
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "7cedc726-e23e-4d23-8003-b7c7abaa6529");
            }
        }
        
        public void StopBackupManagerThread()
        {
            try
            {
                if (m_oStartStopBackupManager != null)
                {
                    lock (m_oStartStopBackupManager)
                    {
                        Monitor.Pulse(m_oStartStopBackupManager);
                    }

                    Thread.Sleep(1000);

                    if ((m_tBackupManagerThread != null) && (m_tBackupManagerThread.ThreadState == ThreadState.Stopped))
                    {
                        m_tBackupManagerThread = null;
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
