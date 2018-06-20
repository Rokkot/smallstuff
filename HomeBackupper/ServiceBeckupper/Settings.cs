using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace SKFlickrSync
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

				_tSettings.AppsToRunList = new List<AppsToRunUnit>();

				_tSettings.AppsToRunList.Add(new AppsToRunUnit("Calulator", "Calc.exe", "5"));
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
		private List<AppsToRunUnit> m_list = null;

		public Settings()
		{
			//m_list = new List<AppsToRunUnit>();
		}

		public List<AppsToRunUnit> AppsToRunList
		{
			get { return m_list; }
			set { m_list = value; }
		}
	}

	public class AppsToRunUnit
	{
		public string AppName { get; set; }
		public string AppPath { get; set; }
		public string AppArgs { get; set; }

		public AppsToRunUnit()
		{

		}

		public AppsToRunUnit(string _sAppName, string _sAppPath, string _sAppArgs)
		{
			AppName = _sAppName;
			AppPath = _sAppPath;
			AppArgs = _sAppArgs;
		}
	}
}
