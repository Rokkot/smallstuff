using System;
using System.IO;
using System.Threading;
using ibkplib;
using Utils;

namespace LocalBackup
{
    public class Local : IBackup
    {
        public void BackupFolder(string _sStartDirSource, string _sStartDirDestination, DateTime _dtStartBackupHour, object _oStopObject)
        {
            try
            {
                string sFileName = string.Empty;
                string sDestFile = string.Empty;

                lock (_oStopObject)
                {
                    // let processor to breathe
                    // and wait for stop process.
                    if (Monitor.Wait(_oStopObject, 100) == true)
                    {
                        return;
                    }
                    else
                    {
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

                            BackupFolder(d, _sStartDirDestination, _dtStartBackupHour, _oStopObject);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "d9cddfe7-f013-4712-990a-1d9fc524d3e1");
            }
        }
    }
}
