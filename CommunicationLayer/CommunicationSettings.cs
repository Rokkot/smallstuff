using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CommunicationLayer
{
	public class SettingsMngr
	{
		public SettingsMngr()
		{
#if DEBUG
			try
			{
				SettingsConfig<Settings> s = new SettingsConfig<Settings>(InitSettingObjecForDebugModeSettingFileCreationDelegate);


				//SettingsConfig<Settings>.Instance.InitSettingObjecForDebugModeSettingFileCreation = InitSettingObjecForDebugModeSettingFileCreationDelegate;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "d6f7abf6-ef18-4e0a-b58d-f792b09c08c2");
			}
#endif

		}

		public static Settings GetSettings()
		{
			try
			{
				return SettingsConfig<Settings>.Instance.Settings;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "670f1d49-c4ca-45df-9ec3-67c44df69dca");
			}

			return null;
		}

		public void InitSettingObjecForDebugModeSettingFileCreationDelegate(out Settings _tSettings)
		{
			_tSettings = null;

			try
			{
				_tSettings = new Settings();

				_tSettings.SharedFolderPath = @"\\SKISLYU-CONC-D1\Transfer\11111";

				_tSettings.LocalFolderPath = @"C:\Dev\EnterpriseMainStream\Tools\PrepareTestClent\PrepareTestClent\Test\A";

				_tSettings.HTTPAdress = @"http://google.com";

			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "cb720904-ae44-4536-9c72-e1d0828ef0bd");
			}
		}
	}


	[Serializable]
	public class Settings
	{
		private const int m_ciDefaultTimeoutInMinutes = 3;

		public Settings()
		{
			Port = 9085;
			SendTimeout = m_ciDefaultTimeoutInMinutes;
			CloseTimeout = m_ciDefaultTimeoutInMinutes;
			OpenTimeout = m_ciDefaultTimeoutInMinutes;
			ReceiveTimeout = m_ciDefaultTimeoutInMinutes;

			ServiceName = @"";
			BaseAdderss = @
		}

		public string BaseAdderss { get; set; }
		public string ServiceName { get; set; }
		public int Port { get; set; }
		public int SendTimeout { get; set; }
		public int CloseTimeout { get; set; }
		public int OpenTimeout { get; set; }
		public int ReceiveTimeout { get; set; }


	}

	public class SettingUnit
	{
		public string Parm1 { get; set; }
		public string Param2 { get; set; }
		public string Param3 { get; set; }

		public SettingUnit()
		{

		}

		public SettingUnit(string _sParm1, string _sParm2, string _sParm3)
		{
			Parm1 = _sParm1;
			Parm2 = _sParm2;
			Parm3 = _sParm3;
		}
	}
}
