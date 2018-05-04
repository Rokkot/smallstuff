using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppRunnerService
{
	public static class Logger
	{
		public static void WriteEmergencyLog(string _sMessge, string _sID)
		{
			try
			{
				string sAssemblyPath = Assembly.GetExecutingAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, "Logs");

				if (Directory.Exists(sAssemblyPath) == false)
				{
					Directory.CreateDirectory(sAssemblyPath);
				}

				File.WriteAllText(sAssemblyPath
								, string.Format("Date: {2} \r\nMessageID: {1} \r\n{0}", _sMessge, _sID, DateTime.Now));
			}
			catch (Exception exp)
			{
				//If we cannot write emergensy log - we toast.
			}
		}

		public static void WriteInfo(string _sMessge, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Information, _sMessge, _sID);
		}

		public static void WriteWarning(string _sMessge, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Warning, _sMessge, _sID);
		}

		public static void WriteError(string _sMessage, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Error, _sMessage, _sID);
		}

		public static void WriteError(Exception _exp, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Error, _exp.Message, _sID);
		}

		public static void WriteToEventLog(EventLogEntryType _eLogType, string _sMessge, string _sID)
		{
			try
			{
				string sSource;
				string sLog;

				sSource = Assembly.GetExecutingAssembly().GetName().Name;
				sLog = "Application";

				if (!EventLog.SourceExists(sSource))
				{
					EventLog.CreateEventSource(sSource, sLog);
				}

				EventLog.WriteEntry(sSource
									, string.Format("MessageID: {1} \r\n{0}", _sMessge, _sID)
									, _eLogType);
			}
			catch (Exception exp)
			{
				WriteEmergencyLog(exp.Message, "6b59380c-7713-4594-9e5a-72aa2e571043");
			}
		}
	}
}
