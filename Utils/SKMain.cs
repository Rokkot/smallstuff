using System;
using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading;
using System.ServiceProcess;
using WinTrayUI;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Utils
{
	public static class SKMain
	{
		public delegate void StartDelegate();
		public delegate void StopDelegate();
		private delegate void CustomMain();

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		public static void Main_Service_Console<T>()
		{
			Main_Service_Console<T>(null, null, string.Empty, false);
		}

		public static void Main_Service_Console<T>(StartDelegate _StartDelegate, StopDelegate _StopDelegate)
		{
			Main_Service_Console<T>(_StartDelegate, _StopDelegate, string.Empty, false);
		}

		public static void Main_Service_Console<T>(StartDelegate _StartDelegate, StopDelegate _StopDelegate, string _sApplicationName, bool _bShouldRunAsSingleInstance)
		{
			if (Environment.UserInteractive)
			{
				try
				{
					bool createdNew = true;

					Process currentProcess = Process.GetCurrentProcess();
					string sAppName = (string.IsNullOrWhiteSpace(_sApplicationName) == true) ? currentProcess.ProcessName : _sApplicationName.RemoveWhiteSpace();

					using (Mutex mutex = new Mutex(true, sAppName, out createdNew))
					{
						// SKislyuk 11/3/2016 2:23:09 PM
						// if the app can run as multiple instances app then disregard the mutex
						createdNew = (_bShouldRunAsSingleInstance == true) ? createdNew : true;

						if (createdNew)
						{
							
							//@cmnt SKislyuk: [03 November 16, 14:33:02]   [161103_143302]
							// running as console app
							if (_StartDelegate != null)
							{
								_StartDelegate();
							}

							Console.WriteLine("Press any key to stop...");
							Console.ReadKey(true);

							if (_StopDelegate != null)
							{
								_StopDelegate();
							}
						}
						else
						{
							ShowProcess();
						}
					}
				}
				catch (Exception exp)
				{
					Logger.WriteError(exp, "cc27108e-0987-4cbf-b9de-69001127b72f");
				}
			}
			else
			{
				try
				{
					// running as service
					using (ServiceBase service = (ServiceBase)Activator.CreateInstance(typeof(T)))
					{
						ServiceBase.Run(service);
					}
				}
				catch (Exception exp)
				{
					Logger.WriteError(exp, "ed78d049-1bc4-47f9-8f21-8c25376714fe");
				}
			}
		}

		public static void ShowProcess()
		{
			try
			{
				Process current = Process.GetCurrentProcess();

				foreach (Process process in Process.GetProcessesByName(current.ProcessName))
				{
					if (process.Id != current.Id)
					{
						SetForegroundWindow(process.MainWindowHandle);
						break;
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "222f398a-1113-4104-bea3-89a53da1186d");
			}
		}

		public static void Main_WinTrayApp(CustomApplicationContext _CustomApplicationContext, string _sApplicationName)
		{
			Main_WinTrayApp(_CustomApplicationContext, _sApplicationName, false);
		}

		public static void Main_WinTrayApp(CustomApplicationContext _CustomApplicationContext, string _sApplicationName, bool _bShouldRunAsSingleInstance)
		{
			try
			{
				bool createdNew = true;

				Process currentProcess = Process.GetCurrentProcess();
				string sAppName = (string.IsNullOrWhiteSpace(_sApplicationName) == true) ? currentProcess.ProcessName : _sApplicationName.RemoveWhiteSpace();

				using (Mutex mutex = new Mutex(true, sAppName, out createdNew))
				{
					// SKislyuk 11/3/2016 2:23:09 PM
					// if the app can run as multiple instances app then disregard the mutex
					createdNew = (_bShouldRunAsSingleInstance == true) ? createdNew : true;

					if (createdNew)
					{
						if (_CustomApplicationContext == null)
						{
							throw new Exception("The CustomApplicationContext class is not initialized.");
						}

						Application.Run(_CustomApplicationContext);
					}
					else
					{
						ShowProcess();
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "b4d12487-4e99-4ed9-a9f4-38e02de2f41f");
				Logger.DisplayError(exp.Message);
			}
		}
	}
}
