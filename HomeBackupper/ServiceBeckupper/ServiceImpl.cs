using HTTPCommLib;
using System;
using System.ServiceProcess;
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

            m_BackupManager = new BackupManager();

        }

		protected override void OnStart(string[] args)
		{
            StartCustomService();
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
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionHandler);


                // Load Settings
                SettingsManager.Instance.LoadSettings();

                // Start OWIN host 
                HttpService.StartService(Communicator.POSTProc, Communicator.GETProc);

                m_BackupManager.StartSchedulerThread();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "7a9ada27-63ac-41bd-8578-6928731e6b8f");
            }

        }

        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            try
            {
                Logger.WriteErrorLogOnly((Exception)args.ExceptionObject, "5b2609a7-8f89-457d-9f5b-a2ecb2695aa2");

                Logger.WriteWarning("An unhandled exception was caught and the service will be stopped.", "7b97e0d4-ceac-4d83-bf36-a41905167617");

                this.Stop();

            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "be0815cf-8051-49cd-9df9-626c1a44f64e");
            }
        }

        public void StopCustomService()
		{
            HttpService.Stop();

            m_BackupManager.StopBackupManagerThread();
            m_BackupManager.StopSchedulerThread();
        }
	}
}
