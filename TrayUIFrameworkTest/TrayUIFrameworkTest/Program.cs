using System;
using System.Windows.Forms;
using Utils;
using WinTrayUI;

namespace TrayUIFrameworkTest
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try
			{
				ManagerClass obj = new ManagerClass();

				SKMain.Main_WinTrayApp(obj.AppContext, "asdasdad", true);
			}
			catch (Exception exp)
			{
				Logger.DisplayError(exp.Message);
			}

		}
	}
}
