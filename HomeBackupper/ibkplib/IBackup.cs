using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ibkplib
{
    public interface IBackup
    {
        void BackupFolder(string _sStartDirSource, string _sStartDirDestination, DateTime _dtStartBackupHour, object _oStopObject);
    }
}
