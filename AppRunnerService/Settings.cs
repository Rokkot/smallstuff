using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Utils;

namespace AppRunnerService
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

/*
	public sealed class SettingsConfig
	{
		private const string c_sSettingConfigFileName = "Settings.config";

		private Settings m_Settings = null;

		private SettingsConfig()
		{
			CreateSettings();
		}

		public static SettingsConfig Instance
		{
			get
			{
				return Nested_SettingsConfig.instance;
			}
		}

		public Settings Settings
		{
			get { return m_Settings; }
		}

		public void LoadSettings()
		{
			try
			{
				string sAssemblyPath = Assembly.GetExecutingAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, c_sSettingConfigFileName);

				if (File.Exists(sAssemblyPath) == false)
				{
					throw new Exception(string.Format("{0} file does not exist.", c_sSettingConfigFileName));
				}

				m_Settings = (Settings)Serialization.DeserializeObject(File.ReadAllText(sAssemblyPath)
																		, typeof(Settings));
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "36a5bfe0-5bd0-4dc4-b026-daa70fc4abff");
				
				throw new Exception("Failed to read configuration file.");
			}
		}

		private void CreateSettings()
		{
#if DEBUG
			try
			{
				string sAssemblyPath = Assembly.GetExecutingAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, c_sSettingConfigFileName);

				if (File.Exists(sAssemblyPath) == true)
				{
					return;
				}

				Settings settings = new Settings();
				settings.AppsToRunList = new List<AppsToRunUnit>();
				
				settings.AppsToRunList.Add(new AppsToRunUnit("Calulator", "Calc.exe", "5"));

				File.WriteAllText(sAssemblyPath, Serialization.SerializeObject(settings));
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "2703e09d-3d35-4a34-8ad1-400f7ab8e365");
			}
#endif //DEBUG
		}

		private class Nested_SettingsConfig
		{
			internal static readonly SettingsConfig instance;

			static Nested_SettingsConfig()
			{
				SettingsConfig dummy = new SettingsConfig();
				instance = dummy;
			}
		}
	}
*/
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
			get{ return m_list;}
			set{m_list = value;}
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
