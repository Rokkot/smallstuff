using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Utils;

namespace AppRunnerService
{
	public static class RunApps
	{
		public static void Run()
		{
			try
			{
				//Settings settings = SettingsConfig.Instance.Settings;
#if DEBUG
				SettingsMngr s = new SettingsMngr();
#endif
				Settings settings = SettingsMngr.GetSettings();

				if (settings == null)
				{
					throw new Exception("Failed to get settings.");
				}

				if ((settings.AppsToRunList == null)
					|| (settings.AppsToRunList.Count == 0))
				{
					Logger.WriteInfo("No apps to run.", "b793cc74-01e3-4c1e-8cb7-deabf217ee8b");
					return;
				}

				foreach (AppsToRunUnit unit in settings.AppsToRunList)
				{
					Logger.WriteInfo(string.Format("Starting: {0} \r\nFile Path: {1} \r\nArguments: {2}", unit.AppName
																								, unit.AppPath
																								, unit.AppArgs)
									, "a220ba6b-00b5-47dd-9465-2451d2e712cc");

					//if (File.Exists(unit.AppPath) == false)
					//{
					//	Logger.WriteError(string.Format("The {0} file does not exists.", unit.AppPath)
					//					, "893dc543-aa82-4229-a4d4-82b5a5aa8c7f");

					//	continue;
					//}

					if (IsAppRunning(unit.AppName) == false)
					{
						Process.Start(unit.AppPath, unit.AppArgs);
					}
					else
					{
						Logger.WriteInfo(string.Format("Process {0} already running.", unit.AppPath)
										, "57eae429-9a91-4645-a195-6e33d6719c2b");
					}

					Thread.Sleep(500);
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "846fafd2-cc07-4808-81b9-f38d3d527598");
			}
		}

		private static bool IsAppRunning(string _sAppName)
		{
			//if (File.Exists(_sFullPath) == false)
			//{
			//	Logger.WriteError(string.Format("The {0} file does not exists.", _sFullPath)
			//					, "26532b1c-61c2-4ca2-a9c1-498db5f89ff6");

			//	throw new Exception(string.Format("The {0} file does not exists.", _sFullPath));
			//}

			if (string.IsNullOrWhiteSpace(_sAppName) == true)
			{
				throw new Exception("The app name is empty.");
			}

			Process[] procName = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(_sAppName));

			return (procName.Length > 0);
		}
	}
}
