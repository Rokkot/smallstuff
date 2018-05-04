using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Utils;

namespace RunAs
{
	public partial class AdminSettingsForm : Form
	{
		bool m_bCheckPWD = false;

		public AdminSettingsForm(bool _bCheckPWD)
		{
			InitializeComponent();

			m_bCheckPWD = _bCheckPWD;

			if (m_bCheckPWD == true)
			{
				textBox_UserName.Enabled = false;
				textBox_Domain.Enabled = false;

				textBox_PWD.Focus();

				this.Text = "Password verification";
			}
		}
		
		public AdminSettingsForm()
		{
			InitializeComponent();
		}

		private void AdminSettingsForm_Load(object sender, EventArgs e)
		{
			try
			{
				textBox_UserName.Text = Environment.UserName;
				textBox_Domain.Text = (Environment.UserDomainName != Environment.MachineName) ? Environment.UserDomainName : string.Empty;
				
				
				AdminEntity admin = new AdminEntity();
				textBox_UserName.Text = (string.IsNullOrEmpty(admin.UserName) == false) ? admin.UserName : textBox_UserName.Text;
				textBox_Domain.Text = (string.IsNullOrEmpty(admin.Domain) == false) ? admin.Domain : textBox_Domain.Text;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "de418775-c060-467b-8ec9-7d30f3ba1f9a");
			}
		}


		/// <summary>
		/// Gets the admin encrypted entity.
		/// </summary>
		/// <returns></returns>
		public string GetAdminEncryptedEntity()
		{
			try
			{
				AdminEntity admin = new AdminEntity(textBox_UserName.Text
													, textBox_Domain.Text
													, textBox_PWD.Text);

				return admin.ToString();
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "755a13ad-3f88-4961-91fd-7658f0cbe232");
			}

			return string.Empty;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			if (m_bCheckPWD == true)
			{
				AdminEntity admin = new AdminEntity();
				if (textBox_PWD.Text.Equals(admin.Password) == true)
				{
					this.DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					MessageBox.Show("Wrong password.");

					textBox_PWD.Focus();
				}
			}
			else
			{
				this.DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
