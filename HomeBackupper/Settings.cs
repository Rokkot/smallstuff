using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backupper
{
    public enum enumWeekdays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64,
        All = Int32.MaxValue
    }

    public class Settings
    {
        private static string C_KEY_SETTINGS = "Settings";

        private Dictionary<string, FolderInfo> m_dictFolderInfo = new Dictionary<string, FolderInfo>();

        public DateTime BackupTime { get; set; }
        public int BackupDays { get; set; }
        public bool WatchFolders { get; set; }
        public string BackupDestinationRootPath { get; set; }
        public Dictionary<string, FolderInfo> DictFolderInfo { get => m_dictFolderInfo; set => m_dictFolderInfo = value; }
        public static string GetUnitKey()
        {
            return C_KEY_SETTINGS;
        }

        public Type GetUnitType()
        {
            return this.GetType();
        }
    }

    public class FolderInfo
    {
        public string FolderSourcePath { get; set; }
        public long NumberOfFilesInSource { get; set; }
        public long NumberOfSubFolderInSource { get; set; }
        public long NumberOfFilesInDestination { get; set; }
        public long NumberOfSubFoldersInDestination { get; set; }
        public string ChecksumSource { get; set; }
        public string ChecksumDestination { get; set; }

        public Type GetUnitType()
        {
            return this.GetType();
        }

        public string GetUnitKey()
        {
            return FolderSourcePath;
        }
    }
}
