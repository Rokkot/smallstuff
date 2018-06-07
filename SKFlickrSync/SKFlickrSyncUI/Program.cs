using System;
using System.Windows.Forms;
using Utils;

namespace SKFlickrSyncUI
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            AppContextManager context = new AppContextManager();

            SKMain.Main_WinTrayApp(context.AppContext, FlickrSyncMonitorForm.APP_NAME, true);

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

		}
	}
}
