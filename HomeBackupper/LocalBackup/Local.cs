using System;
using System.IO;
using System.Threading;
using ibkplib;
using Utils;

namespace LocalBackup
{
    public class Local : IBackup
    {
        public long BackupFolder(string _sStartDirSource, string _sStartDirDestination, DateTime _dtStartBackupHour, ManualResetEvent _meStopEvent)
        {
            long lSizeOfFiles = 0;

            try
            {
                string sFileName = string.Empty;
                string sDestFile = string.Empty;    

                // let processor to breathe
                // and wait for stop process.
                if (_meStopEvent.WaitOne(10) == true)
                {
                    return lSizeOfFiles;
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
                    foreach (FileInfo fi in di.GetFiles(_sStartDirSource))
                    {
                        if (_meStopEvent.WaitOne(10) == true)
                        {
                            break;
                        }
                        else
                        {
                            // copy all files in the folder
                            sFileName = Path.GetFileName(fi.FullName);
                            sDestFile = Path.Combine(_sStartDirDestination, sFileName);
                            lSizeOfFiles += fi.Length;
                            fi.CopyTo(sDestFile, true);
                        }
                    }

                    foreach (string d in Directory.GetDirectories(_sStartDirSource))
                    {
                        if (_meStopEvent.WaitOne(10) == true)
                        {
                            break;
                        }
                        else
                        {
                            lSizeOfFiles += BackupFolder(d, _sStartDirDestination, _dtStartBackupHour, _meStopEvent);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "d9cddfe7-f013-4712-990a-1d9fc524d3e1");
            }

            return lSizeOfFiles;
        }
    }
}
