using ibkplib;
using SettingBackupper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Utils;

namespace BackupperService
{
    public class Backup<T>
    {
        private SerializableDictionary<string, FolderInfo> m_FI = null;
        private TimeSpan m_tsBackupperInterval = TimeSpan.Zero;
        private object m_oStartStopBackup = null;

        private Thread m_tBackupper = null;

        private bool m_bIsBackupRunning = false;

        public Backup()
        {
            m_FI = new SerializableDictionary<string, FolderInfo>();
            m_tsBackupperInterval = TimeSpan.FromSeconds(5);
        }

        public bool IsBackupRunning
        {
            get { return m_bIsBackupRunning; }
        }

        public void StartThread()
        {
            try
            {
                if (m_bIsBackupRunning == false)
                {
                    if (m_oStartStopBackup == null)
                    {
                        m_oStartStopBackup = new object();
                    }

                    if (m_tBackupper == null)
                    {
                        m_tBackupper = new Thread(BackupThread);
                    }

                    m_tBackupper.IsBackground = true;
                    m_tBackupper.Start(m_oStartStopBackup);
                    m_bIsBackupRunning = true;
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "729d5f1f-e7ca-42a4-bda0-7713880f1403");
            }
        }
        public void BackupThread(object oStop)
        {
            try
            {
                lock (oStop)
                {
                    DateTime dtStartBackupHour = DateTime.Now;
                    List<FolderInfo> lstFoldrs = null;
                    string sDestinationRoot = string.Empty;

                    IBackup inBackup = (IBackup)Activator.CreateInstance(typeof(T));

                    lock (SettingsManager.Instance)
                    {
                        sDestinationRoot = SettingsManager.Instance.Settings.BackupDestinationRootPath;
                    }

                    lock (m_FI)
                    {
                        m_FI.LoadData();
                        lstFoldrs = m_FI.ValuesToList();
                    }

                    while (true)
                    {
                        if (Monitor.Wait(oStop, m_tsBackupperInterval) == true)
                        {
                            break;
                        }
                        else
                        {
                            string sFolderToDelete = string.Empty;

                            // if backup is running less the hours to run from settings then continue. Otherwise stop backup
                            if (SettingsManager.Instance.IsBackupRunningTooLong(dtStartBackupHour) == false)
                            {
                                if (lstFoldrs != null)
                                {
                                    foreach (FolderInfo fi in lstFoldrs)
                                    {
                                        if (fi.IsDeleted == true)
                                        {
                                            lock (m_FI)
                                            {
                                                m_FI.Remove(fi.FolderSourcePath);
                                            }

                                            string[] sFolders = fi.FolderSourcePath.Split(Path.DirectorySeparatorChar);

                                            sFolderToDelete = Path.Combine(sDestinationRoot, sFolders[sFolders.Length - 1]);
                                            //Directory.Delete(sFolderToDelete, true);

                                        }
                                        else
                                        {
                                            inBackup.BackupFolder(fi.FolderSourcePath, sDestinationRoot, dtStartBackupHour, );
                                        }
                                    }

                                    lock (m_FI)
                                    {
                                        m_FI.SaveData();
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
            finally
            {
                m_bIsBackupRunning = false;
            }
        }

        public void StopThread()
        {
            try
            {
                if (m_oStartStopBackup != null)
                {
                    lock (m_oStartStopBackup)
                    {
                        Monitor.Pulse(m_oStartStopBackup);
                    }

                    Thread.Sleep(1000);

                    if ((m_tBackupper != null) && (m_tBackupper.ThreadState == ThreadState.Stopped))
                    {
                        m_tBackupper = null;
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "69e1e46f-cca3-4117-930a-344a8ea5288a");
            }
        }
    }
}
