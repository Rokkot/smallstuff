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

        private static ManualResetEvent m_meBackupFunction = null;

        public Backup()
        {
            m_FI = new SerializableDictionary<string, FolderInfo>();
            m_tsBackupperInterval = TimeSpan.FromSeconds(5);
            m_meBackupFunction = new ManualResetEvent(false);
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

                    m_meBackupFunction.Reset();
                    m_tBackupper.Name = "Backup";
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
                    DirectoryInfo di = null;
                    string sFolderName = string.Empty;
                    long lSizeOfFiles = 0;

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
                            m_meBackupFunction.Set();

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

                                            di = new DirectoryInfo(fi.FolderSourcePath);

                                            fi.NumberOfFilesInSource = di.GetFiles("*", SearchOption.AllDirectories).Length;

                                            // if fi.FolderSourcePath = "C:\\" replace the folder name with empty string. 
                                            // Otherwise Path.Combine(sDestinationRoot, "C:\\") will return "C:\\"
                                            sFolderName = (di.Root.FullName != di.Name) ? di.Name : string.Empty;
                                            
                                            sFolderToDelete = Path.Combine(sDestinationRoot, sFolderName);

                                            if (Directory.Exists(sFolderToDelete) == true)
                                            {
                                                Directory.Delete(sFolderToDelete, true);
                                            }
                                        }
                                        else
                                        {
                                            lSizeOfFiles += inBackup.BackupFolder(fi.FolderSourcePath, sDestinationRoot, dtStartBackupHour, m_meBackupFunction);
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
                Logger.WriteErrorLogOnly(exp, "a4569866-14a5-411b-8bb9-f01a4412557f");
            }
            finally
            {
                m_tBackupper = null;
                m_bIsBackupRunning = false;
            }
        }

        public void StopThread()
        {
            try
            {
                if (m_oStartStopBackup != null)
                {
                    m_meBackupFunction.Set();

                    Thread.Sleep(100);

                    lock (m_oStartStopBackup)
                    {
                        Monitor.Pulse(m_oStartStopBackup);
                    }

                    Thread.Sleep((int)m_tsBackupperInterval.TotalMilliseconds * 2);

                    if (m_tBackupper != null)
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
