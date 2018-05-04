using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace AppRunnerService
{
	public partial class AppRunnerService : ServiceBase
	{
		public AppRunnerService()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			try
			{
				Logger.WriteInfo("AppRunnerService service started.", "6837cd02-7f93-417a-9c80-4b8db2e1dd51");

				RunApps.Run();
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "76c8b622-1160-4436-ae63-146a967b7d54");
			}
		}

		protected override void OnStop()
		{
			Logger.WriteInfo("AppRunnerService service stopped.", "9aa1690c-e050-45c5-8a5b-b5b1293703fe");
		}
	}
}
