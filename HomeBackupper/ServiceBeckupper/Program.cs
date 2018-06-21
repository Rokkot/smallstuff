using System;
using Utils;

namespace BackupperService
{
	class Program
	{
		static void Main(string[] args)
		{
            ServiceImpl sevice = new ServiceImpl();

            SKMain.Main_Service_Console<ServiceImpl>(sevice.StartCustomService, sevice.StopCustomService);
		}
	}
}
