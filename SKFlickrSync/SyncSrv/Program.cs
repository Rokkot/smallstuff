using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.ServiceProcess;
using Utils;

namespace SKFlickrSync
{
	public static class Program
	{
		static void Main(string[] args)
		{
			SKMain.Main_Service_Console<SKFlickrSyncService>();
		}
	}
}
