using System;
using System.Windows.Forms;
//using Utils;
//using WinTrayUI;

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
			//SKMain.Main_WinTrayApp(FlickrSyncMonitorForm.APP_NAME, "Flickr_1.jpg");
			try
			{
				Application.EnableVisualStyles();

				Application.SetCompatibleTextRenderingDefault(false);
				try
				{
					//CustomApplicationContext applicationContext = new CustomApplicationContext(FlickrSyncMonitorForm.APP_NAME, "Flickr_1.jpg");
					//Application.Run(applicationContext);
					Application.Run(new FlickrSyncMonitorForm());
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Program Terminated Unexpectedly",
						 MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception exp)
			{
				//Logger.WriteError(exp, "b4d12487-4e99-4ed9-a9f4-38e02de2f41f");
			}

		}
	}
}
