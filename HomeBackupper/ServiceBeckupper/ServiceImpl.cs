using HTTPCommLib;
using System;
using System.ServiceProcess;
using System.Threading;
using Utils;


namespace BackupperService
{
	partial class ServiceImpl : ServiceBase
	{
        BackupManager m_BackupManager = null;
        public const string C_APPLICATION_NAME = "";
        public ServiceImpl()
		{
			InitializeComponent();

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);
        }

		protected override void OnStart(string[] args)
		{
            try
            {
                StartCustomService();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "e4f66c4b-68f2-4988-b9c1-d3c32fd42ef2");
            }
        }

		protected override void OnStop()
		{
            try
            {
                StopCustomService();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "79754f38-9694-4f11-92bd-2a1a6b56956e");
            }
        }

		public void StartCustomService()
		{
            try
            {
                // Load Settings
                SettingsManager.Instance.LoadSettings(true);

                Logger.WriteInfo("Start StartCustomService", "477ebd10-c9e5-465b-8193-3d9e8bbeab06");

                // Start OWIN host 
                HttpService.StartService(Communicator.POSTProc, Communicator.GETProc);

                m_BackupManager = new BackupManager();

                m_BackupManager.StartSchedulerThread();

                Logger.WriteInfo("End StartCustomService", "73641c23-223b-452a-bd06-0b07af4504fb");

            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "7a9ada27-63ac-41bd-8578-6928731e6b8f");
            }

        }

        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            try
            {
                Logger.WriteErrorLogOnly((Exception)args.ExceptionObject, "5b2609a7-8f89-457d-9f5b-a2ecb2695aa2");

                Logger.WriteWarning("An unhandled exception was caught and the service will be stopped.", "7b97e0d4-ceac-4d83-bf36-a41905167617");

                m_BackupManager.HandleTotalRestart();

            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "be0815cf-8051-49cd-9df9-626c1a44f64e");
                this.Stop();
            }
        }

        public void StopCustomService()
		{
            try
            {
                Logger.WriteInfo("Start StopCustomService", "7ea86d42-34b3-4fdc-88b4-f1190220ab9e");

                HttpService.Stop();

                m_BackupManager.StopBackupManagerThread();
                m_BackupManager.StopSchedulerThread();

                m_BackupManager = null;

                Logger.WriteInfo("End StopCustomService", "d4c29ea0-6f52-41a0-9ad0-08b859c482d1");

            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "37d234cb-ac90-4d34-91c6-e07b10ce7598");
            }
        }
	}
}
