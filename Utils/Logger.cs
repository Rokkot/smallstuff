using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
	public static class Logger
	{
		/// <summary>
		/// executable file location
		/// </summary>
		/// <param name="_sMessge"></param>
		/// <param name="_sID"></param>
		public static void WriteEmergencyLog(string _sMessge, string _sID)
		{
			try
			{
				string sAssemblyPath = Assembly.GetEntryAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, "Logs");

				if (Directory.Exists(sAssemblyPath) == false)
				{
					Directory.CreateDirectory(sAssemblyPath);
				}

				File.WriteAllText(sAssemblyPath
								, string.Format("Date: {2} \r\nMessageID: {1} \r\n{0}", _sMessge, _sID, DateTime.Now));
			}
			catch
			{
				//If we cannot write emergensy log - we toast.
			}
		}

		public static void ThrowException(Exception _exp, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Information, _exp.Message, _sID);
			throw _exp;
		}

		public static void ThrowExceptionError(Exception _exp, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Error, _exp.Message, _sID);
			throw _exp;
		}

		/// <summary>
		/// Loggs Info to EventLog
		/// </summary>
		/// <param name="_sMessge"></param>
		/// <param name="_sID"></param>
		public static void WriteInfo(string _sMessge, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Information, _sMessge, _sID);
		}

		/// <summary>
		/// Loggs Warning to EventLog
		/// </summary>
		/// <param name="_sMessge"></param>
		/// <param name="_sID"></param>
		public static void WriteWarning(string _sMessge, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Warning, _sMessge, _sID);
		}

		/// <summary>
		/// Loggs Error to EventLog
		/// </summary>
		/// <param name="_sMessage"></param>
		/// <param name="_sID"></param>
		public static void WriteError(string _sMessage, string _sID)
		{
			ThrowExceptionError(new Exception(_sMessage), _sID);
		}

		/// <summary>
		/// Loggs Error to EventLog
		/// </summary>
		/// <param name="_exp"></param>
		/// <param name="_sID"></param>
		public static void WriteError(Exception _exp, string _sID)
		{
			ThrowExceptionError(_exp, _sID);
		}

		/// <summary>
		/// Loggs Error to EventLog
		/// </summary>
		/// <param name="_sMessage"></param>
		/// <param name="_sID"></param>
		public static void WriteErrorLogOnly(string _sMessage, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Error, _sMessage, _sID);
		}

		/// <summary>
		/// Loggs Error to EventLog
		/// </summary>
		/// <param name="_exp"></param>
		/// <param name="_sID"></param>
		public static void WriteErrorLogOnly(Exception _exp, string _sID)
		{
			WriteToEventLog(EventLogEntryType.Error, _exp.Message, _sID);
		}

		/// <summary>
		/// Loggs message to EventLog
		/// </summary>
		/// <param name="_eLogType"></param>
		/// <param name="_sMessge"></param>
		/// <param name="_sID"></param>
		public static void WriteToEventLog(EventLogEntryType _eLogType, string _sMessge, string _sID)
		{
			try
			{
				string sSource;
				string sLog;

				sSource = Assembly.GetEntryAssembly().GetName().Name;
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

		public static void DisplayError(string _sMessage)
		{
			try
			{
				MessageBox.Show(_sMessage, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception exp)
			{
				WriteEmergencyLog(exp.Message, "17ae5e60-f140-43c2-b6ad-832fb93e7c6b");
			}
		}

        public static void ShowMessageBox(string _sText, MessageBoxButtons _mButton, MessageBoxIcon _mIcon)
        {
            MessageBox.Show(_sText, Assembly.GetEntryAssembly().GetName().Name, _mButton, _mIcon);
        }

        public static void ShowErrorMessageBox(String format, params object[] args)
        {
            ShowMessageBox(string.Format(format, args), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowErrorMessageBox(Exception exp, String format, params object[] args)
        {
            string sText = string.Format("{0} \r\nSystem error: {1}", string.Format(format, args), exp.Message);

            ShowMessageBox(sText, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInfoMessageBox(String format, params object[] args)
        {
            ShowMessageBox(string.Format(format, args), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowWarningMessageBox(String format, params object[] args)
        {
            ShowMessageBox(string.Format(format, args), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
