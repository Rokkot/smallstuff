using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFServiceTest.CommClient;

namespace WCFServiceTest
{
	public partial class Form1 : Form, ICommunicationServiceCallback
	{
		private const int m_ciDefaultOpenTimeoutInSeconds = 10;
		public const string C_WS_DUAL_HTTP_BINDING = "wsDualHttpBinding";
		public const string C_NET_TCP_BINDING = "netTcpBinding";

		public Form1()
		{
			InitializeComponent();

			try
			{
				//Connect(C_WS_DUAL_HTTP_BINDING);
				Connect(C_NET_TCP_BINDING);

				if (m_ServiceClient.IsRunning())
				{
					m_ServiceClient.SubscribeForEvernts();
				}
			}
			catch (Exception exp)
			{
				
			}

		}

		private void Connect(string _sBinding)
		{
			InstanceContext siteAccDigitizerHandler = new InstanceContext(null, this);

			string sEndpointAddress = GetEndPointAddress(_sBinding);

			System.ServiceModel.Channels.Binding binding = null;

			switch (_sBinding)
			{
				case C_WS_DUAL_HTTP_BINDING:
					{
						binding = new WSDualHttpBinding();
						binding.SendTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						binding.CloseTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						binding.OpenTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						binding.ReceiveTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						break;
					}
				case C_NET_TCP_BINDING:
					{
						binding = new NetTcpBinding();
						binding.SendTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						binding.CloseTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						binding.OpenTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						binding.ReceiveTimeout = TimeSpan.FromSeconds(m_ciDefaultOpenTimeoutInSeconds);
						//binding.ReliableSession.Enabled = false;
						//binding.ReliableSession.InactivityTimeout = TimeSpan.FromMinutes(m_ciDefaultOpenTimeoutInSeconds);
						break;
					}
				default:
					MessageBox.Show(string.Format("The {0} binding is not supported.", _sBinding));
					break;
			}

			m_ServiceClient = new CommunicationServiceClient(siteAccDigitizerHandler, binding, new EndpointAddress(sEndpointAddress));
		}

		private string GetEndPointAddress(string _sBinding)
		{
			string sAddress = string.Empty;

			ClientSection clientSettings = ConfigurationManager.GetSection("system.serviceModel/client") as ClientSection;

			foreach (ChannelEndpointElement endpoint in clientSettings.Endpoints)
			{
				if (_sBinding == endpoint.Binding)
				{
					sAddress = endpoint.Address.ToString();
					break;
				}
			}

			return sAddress;
		}

		CommunicationServiceClient m_ServiceClient = null;

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				CommandData command = new CommandData();
				command.CommandID = 1;
				command.CommandParams = new object[] { (int)5000 };

				if (m_ServiceClient.ExecuteCommand(command) == true)
				{
					MessageBox.Show("Started");
				}

			}
			catch (Exception exp)
			{

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				CommandData command = new CommandData();
				command.CommandID = 2;
				command.CommandParams = new string[] { "WCFServiceTest" };

				if (m_ServiceClient.ExecuteCommand(command) == true)
				{
					MessageBox.Show("Stopped");
				}

			}
			catch (Exception exp)
			{

			}
		}

		public void CustomEventRaised(string newData)
		{
			MessageBox.Show(newData);
		}

	}
}
