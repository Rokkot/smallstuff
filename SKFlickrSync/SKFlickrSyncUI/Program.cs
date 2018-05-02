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
			SKMain.Main_WinTrayApp(FlickrSyncMonitorForm.APP_NAME, "Flickr_1.jpg");

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

		}
	}
}
