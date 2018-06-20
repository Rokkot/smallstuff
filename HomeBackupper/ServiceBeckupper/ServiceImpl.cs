﻿using HTTPCommLib;
using System.ServiceProcess;
using Utils;


namespace BackupperService
{
	partial class ServiceImpl : ServiceBase
	{
		public ServiceImpl()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
            StartCustomService();
        }

		protected override void OnStop()
		{
            StopCustomService();
        }

		public void StartCustomService()
		{
            // Start OWIN host 
            HttpService.StartService();
        }

		public void StopCustomService()
		{
            HttpService.Stop();

        }
	}
}
