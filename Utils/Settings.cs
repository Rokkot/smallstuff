using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace Utils
{
	public sealed class SettingsConfig<T>
	{
		private const string c_sSettingConfigFileName = "Settings.config";

		private T m_Settings = default(T);

		public delegate void InitSettingObjecForDebugModeSettingFileCreationDelegate(out T _tSettings);

		private InitSettingObjecForDebugModeSettingFileCreationDelegate m_InitSettingObjecForDebugModeSettingFileCreation = null;

		//public delegate void SaveSettingsDelegate(T _tSettings);

		//private SaveSettingsDelegate m_SaveSettingsDelegate = null;

		public SettingsConfig(InitSettingObjecForDebugModeSettingFileCreationDelegate _InitSettingObjecForDebugModeSettingFileCreation)
		{
			try
			{
#if DEBUG
				m_InitSettingObjecForDebugModeSettingFileCreation = _InitSettingObjecForDebugModeSettingFileCreation;

				CreateSettings();
#endif
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "47940f76-1d1d-4826-be66-7b7faec7edf3");
				throw exp;
			}

		}

		private SettingsConfig()
		{
		}

		public static SettingsConfig<T> Instance
		{
			get
			{
				return Nested_SettingsConfig.instance;
			}
		}

		public T Settings
		{
			get { return m_Settings; }
		}

		public void LoadSettings()
		{
			LoadSettings(true);
		}

		private void LoadSettings(bool _bReload)
		{
			try
			{
				if ((m_Settings != null)
					&& (_bReload == false))
				{
					return;
				}

				string sAssemblyPath = Assembly.GetEntryAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, c_sSettingConfigFileName);

				if (File.Exists(sAssemblyPath) == false)
				{
					throw new Exception(string.Format("{0} file does not exist.", c_sSettingConfigFileName));
				}

				m_Settings = (T)Serialization.DeserializeObject(File.ReadAllText(sAssemblyPath)
																		, typeof(T));
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "36a5bfe0-5bd0-4dc4-b026-daa70fc4abff");

				throw new Exception("Failed to read configuration file.");
			}
		}

		public bool SaveSettings(T _tSettings)
		{
			try
			{
				string sAssemblyPath = Assembly.GetEntryAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, c_sSettingConfigFileName);

				if (File.Exists(sAssemblyPath) == true)
				{
					File.Delete(sAssemblyPath);
				}

				if (_tSettings == null)
				{
					throw new Exception("the setting object is null.");
				}

				string sXml = Serialization.SerializeObject(_tSettings);

				File.WriteAllText(sAssemblyPath, sXml);

				LoadSettings(true);

				return true;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "1d748d25-08e7-40e3-8185-f61b77f49e43");
			}

			return false;
		}

		private void CreateSettings()
		{
#if DEBUG
			try
			{

				string sAssemblyPath = Assembly.GetEntryAssembly().Location;

				sAssemblyPath = Path.GetDirectoryName(sAssemblyPath);

				sAssemblyPath = Path.Combine(sAssemblyPath, c_sSettingConfigFileName);

				if (File.Exists(sAssemblyPath) == true)
				{
					return;
				}

				if (m_InitSettingObjecForDebugModeSettingFileCreation != null)
				{
					m_InitSettingObjecForDebugModeSettingFileCreation(out m_Settings);
				}
/*
				Settings settings = new Settings();
				settings.AppsToRunList = new List<SettingUnit>();
				
				settings.AppsToRunList.Add(new AppsToRunUnit("Calulator", "Calc.exe", "5"));
*/

				if (m_Settings == null)
				{
					throw new Exception("Failed to init m_Settings in debug mode.");
				}

				string sXml = Serialization.SerializeObject(m_Settings);

				File.WriteAllText(sAssemblyPath, sXml);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "2703e09d-3d35-4a34-8ad1-400f7ab8e365");
			}
#endif //DEBUG
		}

		private class Nested_SettingsConfig
		{
			internal static readonly SettingsConfig<T> instance;

			static Nested_SettingsConfig()
			{
				SettingsConfig<T> dummy = new SettingsConfig<T>();

				try
				{
					dummy.LoadSettings(false);
				}
				catch (Exception exp)
				{
					Logger.WriteError(exp, "81e34f85-d316-48ec-93e1-c5b5919ce87b");
				}

				
				instance = dummy;
			}
		}
	}

/*
* Example of Setting class and SettingUnit class
* 
		
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
		private List<SettingUnit> m_list = null;

		public Settings()
		{
			m_list = new List<SettingUnit>();
		}

		public List<SettingUnit> AppsToRunList
		{
			get{ return m_list;}
			set{m_list = value;}
		}
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
*/
}
