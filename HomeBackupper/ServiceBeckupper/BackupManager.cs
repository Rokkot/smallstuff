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
    // Multi-Threading toolkit
    // https://docs.eyesopen.com/toolkits/csharp/oechemtk/multithreading.html


    // ROBOCOPY
    // https://github.com/tjscience/RoboSharp C#
    // https://blogs.msdn.microsoft.com/granth/2009/12/07/multi-threaded-robocopy-for-faster-copies/
    // https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/robocopy
    // https://ss64.com/nt/robocopy.html

    // MTCopy: A Multi-threaded Single/Multi File Copying Tool
    // https://www.codeproject.com/Articles/24984/MTCopy-A-Multi-threaded-Single-Multi-File-Copying

    // Multi threaded file processing with .NET
    // https://stackoverflow.com/questions/2807654/multi-threaded-file-processing-with-net
    // https://dotnetfiddle.net/5yQ4Vc

    public class BackupManager
    {
        private TimeSpan m_tsSchedulerInterval = TimeSpan.Zero;
        private TimeSpan m_tsBackupManagerInterval = TimeSpan.Zero;
        //private TimeSpan m_tsManagerInterval = TimeSpan.Zero;

        private Thread m_tSchedulerThread = null;
        private object m_oStartStopScheduler = null;
        private object m_oStartStopBackupManager = null;

        private Thread m_tBackupManagerThread = null;

       // private Thread m_tManagerThread = null;

        private Backup<Local> m_LocalBackup = null;

        private static ManualResetEvent m_meSchedulerEvent = null;
        //private static ManualResetEvent m_meMemanagerThreadEvent = null;

        public BackupManager()
        {
            try
            {
                //m_tsSchedulerInterval = TimeSpan.FromMinutes(1); // every 1 min
                m_tsSchedulerInterval = TimeSpan.FromSeconds(10); // every 5 min
                m_tsBackupManagerInterval = TimeSpan.FromSeconds(5); // 5 seconds
                //m_tsManagerInterval = TimeSpan.FromSeconds(5);

                m_meSchedulerEvent = new ManualResetEvent(true);
                //m_meMemanagerThreadEvent = new ManualResetEvent(false);

                m_LocalBackup = new Backup<Local>();
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "33d753ad-0064-41aa-9f32-1116e411a1a1");
            }
        }


        #region @cmnt SKislyuk: [20 July 18, 17:19:23]   [180720_171923]
        //public bool StartManagerThread()
        //{
        //try
        //{
        //if (m_tManagerThread == null)
        //{
        //m_tManagerThread = new Thread(ManagerThread);
        //m_tManagerThread.Name = "Manager";
        //m_tManagerThread.IsBackground = true;

        //m_tManagerThread.Start();
        //}

        //return true;
        //}
        //catch (Exception exp)
        //{
        //Logger.WriteError(exp, "e8ab2e20-0837-4977-bb6e-3c0601192f1f");
        //return false;
        //}
        //}

        //public void ManagerThread()
        //{
        //try
        //{
        //while (true)
        //{
        //if (m_meMemanagerThreadEvent.WaitOne(m_tsManagerInterval) == false)
        //{
        ////stop all threads
        //break;
        //}
        //else
        //{
        //// re-start paused thread or pause thread
        //}                    
        //}
        //} catch (Exception exp)
        //{
        //Logger.WriteErrorLogOnly(exp, "b3c68ee8-d4e7-40f3-8db0-b1571d9db39a");
        //}
        //}

        //public void StopManagerThread()
        //{
        //try
        //{
        //if (m_meMemanagerThreadEvent != null)
        //{
        //m_meMemanagerThreadEvent.Set();

        //Thread.Sleep((int)m_tsManagerInterval.TotalMilliseconds * 2);

        //if (m_tManagerThread != null)
        //{
        //if (m_tManagerThread.ThreadState != ThreadState.Stopped)
        //{
        //m_tManagerThread.Abort();
        //}

        //m_tManagerThread = null;
        //}
        //}
        //}
        //catch (Exception exp)
        //{
        //Logger.WriteError(exp, "06eb6b7e-20df-4f13-b6f7-a89e16ef49f6");
        //}
        //}
        #endregion @cmnt SKislyuk: [20 July 18, 17:19:23]   [180720_171923]

        private void HandleToalRestartThread()
        {
            try
            {
                Logger.WriteInfo("Start HandleToalRestartThread", "37a59b82-accd-4a8b-872e-4abc48ce7d01");

                StopBackupManagerThread();

                Thread.Sleep(3000);

                StopSchedulerThread();

                Thread.Sleep(3000);

                StartSchedulerThread();

                Logger.WriteInfo("End HandleToalRestartThread", "1668a27f-e175-402f-92fb-909a825195a1");

            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "a41a2ab7-ceb0-46d8-afdc-8c2bf31123bb");
            }
        }

        public void HandleTotalRestart()
        {
            try
            {
                Logger.WriteInfo("Start HandleTotalRestart", "37a59b82-accd-4a8b-872e-4abc48ce7d01");

                Thread trHandleRestart = new Thread(HandleToalRestartThread);
                trHandleRestart.IsBackground = true;
                trHandleRestart.Start();

                Logger.WriteInfo("End HandleTotalRestart", "ad65cf87-f31f-4aef-8d68-2711b545a674");
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "afc9138b-0d84-4e31-b5af-4e6656f2eddb");
            }
        }


        public bool StartSchedulerThread()
        {
            try
            {
                Logger.WriteInfo("Start StartSchedulerThread", "bb0c2a42-969a-436d-a112-2746d5110a61");

                if (m_oStartStopScheduler == null)
                {
                    m_oStartStopScheduler = new object();
                    m_tSchedulerThread = new Thread(SchedulerThread);
                    m_tSchedulerThread.Name = "Scheduler";
                    m_tSchedulerThread.IsBackground = true;
                }

                if (m_tSchedulerThread == null)
                {
                    m_tSchedulerThread = new Thread(SchedulerThread);
                    m_tSchedulerThread.Name = "Scheduler";
                    m_tSchedulerThread.IsBackground = true;
                }

                m_tSchedulerThread.Start(m_oStartStopScheduler);

                Logger.WriteInfo("End StartSchedulerThread", "81bec757-bf2f-417d-9a31-1f037485bd69");

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
                Logger.WriteInfo("Start SchedulerThread", "42eb8f4b-9d1f-4186-91c9-57ee7ea4e90f");

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
                            if (m_meSchedulerEvent.WaitOne(m_tsSchedulerInterval) == false)
                            {
                                continue;
                            }
                            else
                            {
                                Thread.Sleep(10);
                            }

                            // checked time and start backup process if needed.
                            if ((SettingsManager.Instance.IsBackupDay() == true) && (SettingsManager.Instance.IsBackupTime() == true))
                            {
                                // Start backup;
                                StartBackupManagerThread();

                                // Stop this thread while the backupper thread is running.
                                // This thread will be restarted once backupper thread is done.
                                //break;

                                /////////////////////////////////////////////////////////////////////////////////
                                //FOR TEST ONLY!!! SKislyuk 7/20/2018 5:50:42 PM
                                //
                                int iii = 0;

                                if (iii > 0)
                                {
                                    iii /= 0;
                                }
                                //
                                //END TEST CODE!!!
                                /////////////////////////////////////////////////////////////////////////////////
                            }
                        }
                    }
                }

                Logger.WriteInfo("End SchedulerThread", "591a662a-9feb-4026-bb10-2dcfc6e4451d");
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "a4569866-14a5-411b-8bb9-f01a4412557f");
            }
            finally
            {
                m_tSchedulerThread = null;
            }
        }

        public void StopSchedulerThread()
        {
            try
            {
                Logger.WriteInfo("Start StopSchedulerThread", "3903aaab-d6bd-434b-a112-4416afc193f9");

                if (m_oStartStopScheduler != null)
                {
                    lock (m_oStartStopScheduler)
                    {
                        Monitor.Pulse(m_oStartStopScheduler);
                    }

                    Thread.Sleep((int)m_tsSchedulerInterval.TotalMilliseconds * 2);

                    if (m_tSchedulerThread != null)
                    {
                        m_tSchedulerThread = null;
                    }
                }

                Logger.WriteInfo("End StopSchedulerThread", "97bea120-3bda-43ea-9ec1-fbb9894961ac");
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
                Logger.WriteInfo("Start StartBackupManagerThread", "fd05eda5-6389-48c1-85f3-b7b44311c291");

                if (m_oStartStopBackupManager == null)
                {
                    m_oStartStopBackupManager = new object();
                }

                if (m_tBackupManagerThread == null)
                {
                    m_tBackupManagerThread = new Thread(BackupManagerThread);
                    m_tBackupManagerThread.Name = "BackupManager";
                    m_tBackupManagerThread.IsBackground = true;
                }

                m_tBackupManagerThread.Start(m_oStartStopBackupManager);

                Logger.WriteInfo("End StartBackupManagerThread", "16239734-082d-48c7-9622-965d7d9386f8");

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
                Logger.WriteInfo("Start BackupManagerThread", "10d6ffde-141b-423c-b094-81458fed1910");

                lock (oStop)
                {
                    DateTime dtStartBackupHour = DateTime.Now;

                    m_meSchedulerEvent.Reset();

                    Thread.Sleep(3000);
                    m_LocalBackup.StartThread();

                    while (true)
                    {
                        if (Monitor.Wait(oStop, m_tsBackupManagerInterval) == true)
                        {
                            // stop Backup thread
                            m_LocalBackup.StopThread();

                            Thread.Sleep(3000);

                            break;
                        }
                        else
                        {
                            if (m_LocalBackup.IsBackupRunning == false)
                            {
                                m_LocalBackup.StopThread();
                                Thread.Sleep(3000);
                                m_meSchedulerEvent.Set();
                                break;
                            }

                            /////////////////////////////////////////////////////////////////////////////////
                            //FOR TEST ONLY!!! SKislyuk 7/20/2018 5:50:42 PM
                            //
                            int iii = 0;

                            if (iii > 0)
                            {
                                iii /= 0;
                            }
                            //
                            //END TEST CODE!!!
                            /////////////////////////////////////////////////////////////////////////////////

                            // checked time and start backup process if needed.
                            if (SettingsManager.Instance.IsBackupRunningTooLong(dtStartBackupHour) == true)
                            {
                                // Stop backup;
                                m_LocalBackup.StopThread();
                                Thread.Sleep(3000);
                                //StartSchedulerThread();
                                m_meSchedulerEvent.Set();

                                // Stop this thread while the backupper thread is running.
                                // This thread will be restarted once backupper thread is done.
                                break;
                            }
                        }
                    }
                }

                Logger.WriteInfo("End BackupManagerThread", "821c453d-efd5-424a-adc5-5468e87d57c8");
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "7cedc726-e23e-4d23-8003-b7c7abaa6529");
            }
            finally
            {
                m_LocalBackup.StopThread();

                Thread.Sleep(3000);

                m_meSchedulerEvent.Set();

                m_tBackupManagerThread = null;
            }
        }
        
        public void StopBackupManagerThread()
        {
            try
            {
                Logger.WriteInfo("Start StopBackupManagerThread", "62e95751-4085-45df-bfbc-a05c697c048e");

                if (m_oStartStopBackupManager != null)
                {
                    lock (m_oStartStopBackupManager)
                    {
                        Monitor.Pulse(m_oStartStopBackupManager);
                    }

                    Thread.Sleep((int)m_tsBackupManagerInterval.TotalMilliseconds * 2);

                    if (m_tBackupManagerThread != null)
                    {
                        m_tBackupManagerThread = null;
                    }
                }

                Logger.WriteInfo("End StopBackupManagerThread", "9329314a-7e8b-41eb-8413-db471fc7790d");
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "b3612ff3-47e7-48e4-91fc-03d2d455100e");
            }
        }
    }
}
