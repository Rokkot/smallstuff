using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CommunicationLayer
{
	public class CommunicatorController
	{
		private CommunicationService m_CommService = null;
		private ServiceHost m_ServiceHost = null;
		private string m_sCommServiceStatus = string.Empty;

		public bool StartCommunicationService()
		{
			try
			{
/*
				if (m_CommService != null)
				{
					m_sCommServiceStatus = "Service is running.";
					Logger.WriteInfo(m_sCommServiceStatus, "b1c91a0a-9429-44d5-9e65-a5569d9f50f6");
					return true;
				}

				//SettingsMngr setting1 = new SettingsMngr();

				Settings setting = SettingsMngr.GetSettings();

				m_CommService = new CommunicationService();


				Uri baseAddress = new Uri(setting.GetHostBaseAddress());

				m_ServiceHost = new ServiceHost(m_CommService, baseAddress);

				Binding binding = GetBinding(setting.Binding, setting);
				binding.SendTimeout = TimeSpan.FromMinutes(setting.SendTimeout);
				binding.CloseTimeout = TimeSpan.FromMinutes(setting.CloseTimeout);
				binding.OpenTimeout = TimeSpan.FromMinutes(setting.OpenTimeout);
				binding.ReceiveTimeout = TimeSpan.FromMinutes(setting.ReceiveTimeout);

				m_ServiceHost.AddServiceEndpoint(typeof(ICommunicationService), (NetTcpBinding)binding, setting.EndPoint);


				m_ServiceHost.Open();

				if (m_ServiceHost.State == CommunicationState.Opened)
				{
					m_sCommServiceStatus = "Server is running.";
					Logger.WriteInfo(m_sCommServiceStatus, "3c8e1c8f-c971-48c0-a789-4714962572bc");
				}
*/
				return true;
			}
			catch (Exception exp)
			{
				m_sCommServiceStatus = string.Format("Error: {0}.", exp.Message);
				Logger.WriteError(exp, "f2b0080a-a92b-4108-be1a-fe56d4323ddc");
			}

			return false;
		}

		public void StopCommunicationService()
		{
			try
			{
				if (m_CommService == null)
				{
					return;
				}

				m_CommService.Dispose();

				if (m_ServiceHost != null)
				{
					m_ServiceHost.Close();
					m_ServiceHost = null;
				}

				m_sCommServiceStatus = "Server is stoped.";
				Logger.WriteInfo(m_sCommServiceStatus, "3eb21aee-53ee-4b9f-9c39-4bf5dda5019d");
			}
			catch (Exception exp)
			{
				m_sCommServiceStatus = string.Format("Error: {0}.", exp.Message);
				Logger.WriteError(exp, "1690aedf-3e3f-403e-ac45-f17207605b92");
			}
		}

		//private Binding GetBinding(string _sBindingType, Settings _Settings)
		//{
		//	Binding binding = null;

		//	switch (_sBindingType)
		//	{
		//		case SettingsMngr.C_BASIC_HTTPBIN_DING:
		//			{
		//				binding = new BasicHttpBinding();
		//				break;
		//			}
		//		case SettingsMngr.C_NET_TCP_BINDING:
		//			{
		//				binding = new NetTcpBinding();
		//				((NetTcpBinding)binding).ReliableSession.Enabled = true;
		//				((NetTcpBinding)binding).ReliableSession.InactivityTimeout = TimeSpan.FromMinutes(_Settings.InactivityTimeout);
		//				((NetTcpBinding)binding).MaxConnections = _Settings.MaxConnections;
		//				break;
		//			}
		//		default:
		//			throw new Exception(string.Format("Unnowne binding type: {0}", _sBindingType));
		//	}

		//	return binding;
		//}

		public string GetLastServiceErrorMsg()
		{
			return m_sCommServiceStatus;
		}
	}
}
