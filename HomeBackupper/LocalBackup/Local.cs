using System;
using System.IO;
using System.Threading;
using ibkplib;
using Utils;

namespace LocalBackup
{
    public class Local : IBackup
    {
        public void BackupFolder(string _sStartDirSource, string _sStartDirDestination, DateTime _dtStartBackupHour, ManualResetEvent _meStopEvent)
        {
            try
            {
                string sFileName = string.Empty;
                string sDestFile = string.Empty;

                //lock (_oStopObject)
                {
                    // let processor to breathe
                    // and wait for stop process.
                    if (_meStopEvent.WaitOne(100) == true)
                    {
                        return;
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(_sStartDirSource);

                        // if fi.FolderSourcePath = "C:\\" replace the folder name with empty string. 
                        // Otherwise Path.Combine(sDestinationRoot, "C:\\") will return "C:\\"
                        string sFolderName = (di.Root.FullName != di.Name) ? di.Name : string.Empty;

                        _sStartDirDestination = Path.Combine(_sStartDirDestination, sFolderName);

                        if (Directory.Exists(_sStartDirDestination) == false)
                        {
                            Directory.CreateDirectory(_sStartDirDestination);
                        }

                        // copy all files in the root of the source folder
                        foreach (string f in Directory.GetFiles(_sStartDirSource))
                        {
                            // copy all files in the folder
                            sFileName = Path.GetFileName(f);
                            sDestFile = Path.Combine(_sStartDirDestination, sFileName);
                            File.Copy(f, sDestFile, true);
                        }

                        foreach (string d in Directory.GetDirectories(_sStartDirSource))
                        {
                            //foreach (string f in Directory.GetFiles(d))
                            //{
                            //    // copy all files in the folder
                            //    sFileName = Path.GetFileName(f);
                            //    sDestFile = Path.Combine(_sStartDirDestination, sFileName);
                            //    File.Copy(f, sDestFile, true);
                            //}

                            BackupFolder(d, _sStartDirDestination, _dtStartBackupHour, _meStopEvent);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "d9cddfe7-f013-4712-990a-1d9fc524d3e1");
            }
        }
    }
}
