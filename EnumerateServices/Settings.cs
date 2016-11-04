using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace EnumerateServices
{
	public class SettingsMngr
	{
		public SettingsMngr()
		{
#if DEBUG
			try
			{
				SettingsConfig<Settings> s = new SettingsConfig<Settings>(InitSettingObjecForDebugModeSettingFileCreationDelegate);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "4d7111d4-9f78-4820-bd81-70dd2cf5bb8b");
			}
#endif

		}

		public static bool SaveSettings(Settings _Settings)
		{
			try
			{
				return SettingsConfig<Settings>.Instance.SaveSettings(_Settings);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "6b0ba75b-5918-4aca-bad8-a6d050659f8a");
			}

			return false;
		}

		public static Settings GetSettings()
		{
			try
			{
				return SettingsConfig<Settings>.Instance.Settings;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "e6f16362-f02f-4743-81a1-9a3d646a6db2");
			}

			return null;
		}

		public void InitSettingObjecForDebugModeSettingFileCreationDelegate(out Settings _tSettings)
		{
			_tSettings = null;

			try
			{
				_tSettings = new Settings();

				_tSettings.MachineName = @"";

				_tSettings.Domain = @"";

				_tSettings.UserName = @"";

				_tSettings.Filter = @"";

			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "f8fe66ce-cf88-4cf7-b7cc-5b271503d962");
			}
		}
	}


	//[Serializable]
	//public class Settings
	//{
	//	private List<SettingUnit> m_list = null;

	//	public Settings()
	//	{
	//		m_list = new List<SettingUnit>();
	//	}

	//	public List<SettingUnit> AppsToRunList
	//	{
	//		get { return m_list; }
	//		set { m_list = value; }
	//	}
	//}

	public class Settings
	{
		public string MachineName { get; set; }
		public string Domain { get; set; }
		public string UserName { get; set; }
		public string Filter { get; set; }

		public Settings()
		{

		}

		public Settings(string _sMachineName, string _sDomain, string _sUserName, string _sFilter)
		{
			MachineName = _sMachineName;
			Domain = _sDomain;
			Filter = _sFilter;
		}
	}
}
