using System;
using System.Threading;

namespace ibkplib
{
    public interface IBackup
    {
        void BackupFolder(string _sStartDirSource, string _sStartDirDestination, DateTime _dtStartBackupHour, ManualResetEvent _meStopEvent);
    }
}
