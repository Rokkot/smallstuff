using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AppRunnerService
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
			try
			{
				Logger.WriteInfo("Starting AppRunnerService ...", "68efd9a3-50b5-4f99-8767-fc4ee8ae6796");

				//SettingsConfig.Instance.LoadSettings();

				if ((args != null)
					&& (args.Length > 0))
				{
					Console.WriteLine("AppRunnerService started as console.");

					RunApps.Run();

					Console.ReadKey();
				}
				else
				{
					ServiceBase[] ServicesToRun;
					
					ServicesToRun = new ServiceBase[] { new AppRunnerService() };

					ServiceBase.Run(ServicesToRun);
				}

				Logger.WriteInfo("Exiting AppRunnerService ...", "351b0e54-3304-43ea-ae91-e86c6010c10a");
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "1275cb2d-3b0f-49f2-8e6d-544b7917cc86");
			}
		}
	}
}
