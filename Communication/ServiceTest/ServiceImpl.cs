//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
//using System.Linq;
using System.ServiceProcess;
//using System.Text;
//using System.Threading.Tasks;
using Utils;
using CommunicationLayer;

namespace Service
{
	partial class ServiceImpl : ServiceBase //, ICustomServiceControl
	{
		private CommunicatorController m_CommunicationServiceControl = null;

		public ServiceImpl()
		{
			InitializeComponent();

			m_CommunicationServiceControl = new CommunicatorController();
		}

		protected override void OnStart(string[] args)
		{
			m_CommunicationServiceControl.StartCommunicationService();
		}

		protected override void OnStop()
		{
			m_CommunicationServiceControl.StopCommunicationService();
		}

		public void StartCustomService()
		{
			m_CommunicationServiceControl.StartCommunicationService();
		}

		public void StopCustomService()
		{
			m_CommunicationServiceControl.StopCommunicationService();
		}
	}
}
