using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using Utils;
using System.Globalization;

namespace EnumerateServices
{
	public partial class Form1 : Form
	{
		Settings m_Settings = null;

		public Form1()
		{
			InitializeComponent();

			//SettingsMngr sm = new SettingsMngr();
		}

		private List<ServiceDetailes> EnumWinServices()
        {
			try
			{
				if ((string.IsNullOrWhiteSpace(textBox_UserName.Text) == true)
					|| (string.IsNullOrWhiteSpace(textBox_ComputerName.Text) == true)
					|| (string.IsNullOrWhiteSpace(textBox_Pwd.Text) == true))
				{
					throw new Exception("The machine name, user name or passowd is empty.");
				}

				List<ServiceDetailes> list = new List<ServiceDetailes>();

				ServiceController[] services = null;

				m_Settings.Domain = textBox_Domain.Text;
				m_Settings.UserName = textBox_UserName.Text;
				m_Settings.MachineName = textBox_ComputerName.Text;
				m_Settings.Filter = textBox_Filter.Text;

				using (new Impersonation(m_Settings.Domain
										, m_Settings.UserName
										, textBox_Pwd.Text))
				{
					services = ServiceController.GetServices(m_Settings.MachineName);
				}

				if (services != null)
				{
					foreach (ServiceController service in services)
					{
						if (string.IsNullOrWhiteSpace(m_Settings.Filter) == false)
						{
							if (service.DisplayName.StartsWith(m_Settings.Filter, true, CultureInfo.CurrentUICulture) == true)
							{
								list.Add(new ServiceDetailes(service.DisplayName, service.Status));
							}
						}
						else
						{
							list.Add(new ServiceDetailes(service.DisplayName, service.Status));
						}

					}

					if (SettingsMngr.SaveSettings(m_Settings) == false)
					{
						throw new Exception("Failed to save settings.");
					}
				}

				return list;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "34e3822c-1c49-4076-98e0-4d89ad554a7f");

				throw exp;

			}
        }

		private void FillList()
		{
			try
			{
				listView.Items.Clear();

				if (string.IsNullOrWhiteSpace(textBox_UserName.Text) == true)
				{
					textBox_UserName.Focus();
					return;
				}

				if(string.IsNullOrWhiteSpace(textBox_ComputerName.Text) == true)
				{
					textBox_ComputerName.Focus();
					return;
				}

				if(string.IsNullOrWhiteSpace(textBox_Pwd.Text) == true)
				{
					textBox_Pwd.Focus();
					return;
				}

				List<ServiceDetailes> list = EnumWinServices();

				if ((list == null)
					|| (list.Count == 0))
				{
					MessageBox.Show(string.Format("Could not find Windows Services that strarts with {1} on {0} machine.", textBox_ComputerName.Text, textBox_Filter.Text));

					return;
				}

				listView.SmallImageList = imageListStatus;
				listView.LargeImageList = imageListStatus;
				ListViewItem item = null;

				foreach (ServiceDetailes service in list)
				{
					item = new ListViewItem("", GetImageIndex(service.Status));
					item.ToolTipText = service.Status.ToString();

					item.SubItems.Add(new ListViewItem.ListViewSubItem(item, service.ServiceName));

					listView.Items.Add(item);
				}

			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "b884ea7f-b005-47c9-8bbb-b5c42458f32f");
				MessageBox.Show(exp.Message);
			}
		}

		private int GetImageIndex(ServiceControllerStatus _eStatus)
		{
			switch (_eStatus)
			{
 				case ServiceControllerStatus.Running:
					return 0;
				default:
					return 1;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			try
			{
				m_Settings = SettingsMngr.GetSettings();

				if (m_Settings == null)
				{
					m_Settings = new Settings();
					m_Settings.MachineName = @"";
					m_Settings.Domain = @"";
					m_Settings.UserName = @"";
					m_Settings.Filter = @"";

					SettingsMngr.SaveSettings(m_Settings);

					m_Settings = SettingsMngr.GetSettings();
				}

				textBox_Domain.Text = m_Settings.Domain;
				textBox_UserName.Text = m_Settings.UserName;
				textBox_ComputerName.Text = m_Settings.MachineName;
				textBox_Filter.Text = m_Settings.Filter;

				button_Go.Focus();
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "c0e6736c-0c81-45f1-b971-a9c4345aa5ac");

				MessageBox.Show(exp.Message, "WinServicesStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);

				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}

		}

		private void button_Go_Click(object sender, EventArgs e)
		{
			FillList();
		}

		private void button_Close_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}

	public class ServiceDetailes
	{
		string m_sServiceName = string.Empty;
		ServiceControllerStatus m_eStatus = ServiceControllerStatus.Stopped;

		public ServiceDetailes(string _sServiceName, ServiceControllerStatus _eStatus)
		{
			m_sServiceName = _sServiceName;
			m_eStatus = _eStatus;
		}

		public string ServiceName
		{
			get { return m_sServiceName; }
			set { m_sServiceName = value; }
		}
		public ServiceControllerStatus Status
		{
			get { return m_eStatus; }
			set { m_eStatus = value; }
		}
	}
}
