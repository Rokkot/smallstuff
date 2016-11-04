using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security;
using System.IO;

using Utils;

namespace RunAs
{
	public partial class RunAsForm : Form
	{
		[DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
		public static extern IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

		private string m_sEncEntity = string.Empty;

		public RunAsForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Handles the MouseDoubleClick event of the listView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
		void listView_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			RunAs2();
		}

		/// <summary>
		/// Extracts the app icon.
		/// </summary>
		/// <param name="_sAppPath">The application path.</param>
		/// <returns></returns>
		private Image ExtractAppIcon(string _sAppPath)
		{
			Image img = null;

			try
			{
				if (string.IsNullOrEmpty(_sAppPath) == true)
				{
					return img;
				}

				//Gets the handle of the icon.
				IntPtr lIcon = ExtractIcon(this.Handle.ToInt32(), _sAppPath, 0);

				//The handle cannot be zero.
				if (lIcon != IntPtr.Zero)
				{
					//Gets the real icon.
					Icon icon = Icon.FromHandle(lIcon);

					img = icon.ToBitmap();
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "4270ec8c-055c-426e-bc86-b80ecfc30c14");
			}

			return img;
		}

		/// <summary>
		/// Creates the app item.
		/// </summary>
		/// <param name="_appUnit">The application unit.</param>
		/// <returns></returns>
		private ListViewItem CreateAppItem(ApplicationUnit _appUnit)
		{
			ListViewItem item = null;

			try
			{
				if (_appUnit == null)
				{
					return item;
				}

				Image img = ExtractAppIcon(_appUnit.Path);

				item = new ListViewItem();

				item.Text = _appUnit.Label;

				item.Tag = _appUnit;

				if (img != null)
				{
					imageList.Images.Add(img);
					item.ImageIndex = imageList.Images.Count - 1;
				}

			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "3d1874d7-8be3-46dc-98ff-3c1f67dfbcd1");
			}

			return item;
		}

		/// <summary>
		/// Adds the item to list view.
		/// </summary>
		/// <param name="_appUnit">The application unit.</param>
		private void AddItemToListView(ApplicationUnit _appUnit)
		{
			try
			{
				if (_appUnit != null)
				{
					ListViewItem item = CreateAppItem(_appUnit);

					if (item != null)
					{
						listView.Items.Add(item);
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "7105d17e-8d8a-44bf-9e23-3deacf064c95");
			}
		}

		/// <summary>
		/// Handles the Click event of the button_Add control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button_Add_Click(object sender, EventArgs e)
		{
			try
			{
				if (CanDoAction() == false)
				{
					return;
				}

				using (AddAppForm addForm = new AddAppForm())
				{
					if (addForm.ShowDialog(this) == DialogResult.OK)
					{
						ApplicationUnit appUnit = addForm.ApplicationUnit;

						AddItemToListView(appUnit);
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "80ce4d8a-2d4a-434c-9edb-3560a62b7956");
			}
		}

		/// <summary>
		/// Handles the Click event of the button_Remove control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button_Remove_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView.SelectedItems.Count > 0)
				{
					if (MessageBox.Show(this, "Are you really want to remove selected application from the list?",
										"Remove an application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						listView.Items.Remove(listView.SelectedItems[0]);
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "ab274bc8-b66a-4c5e-a6fa-769cab4c748d");
			}
		}

		/// <summary>
		/// Handles the Click event of the button_Admin control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button_Admin_Click(object sender, EventArgs e)
		{
			try
			{
				using (AdminSettingsForm adminForm = new AdminSettingsForm())
				{
					if (adminForm.ShowDialog(this) == DialogResult.OK)
					{
						m_sEncEntity = adminForm.GetAdminEncryptedEntity();

						if (string.IsNullOrEmpty(m_sEncEntity) == true)
						{
							button_RunAs.Enabled = false;
							button_Add.Enabled = false;
						}
						else
						{
							button_RunAs.Enabled = true;
							button_Add.Enabled = true;
							SaveConfig();
						}
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "3a1a1b93-72e5-45e9-ae88-30f07bab4f29");
			}
		}

		/// <summary>
		/// Handles the Click event of the button_RunAs control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button_RunAs_Click(object sender, EventArgs e)
		{
			RunAs2();
		}

		/// <summary>
		/// Runs the as2.
		/// </summary>
		private void RunAs2()
		{ 
			try
			{
				AdminEntity admin = new AdminEntity(m_sEncEntity);
				ApplicationUnit appUnit = null;
				string sWorkingDirectory = string.Empty;

				if (listView.SelectedItems.Count > 0)
				{
					appUnit = (ApplicationUnit)listView.SelectedItems[0].Tag;
				}

				if (appUnit == null)
				{
					return;
				}

				ProcessStartInfo myProcess = new ProcessStartInfo(appUnit.Path);

				if (string.IsNullOrEmpty(admin.Domain) == false)
				{
					myProcess.Domain = admin.Domain;
				}
				
				sWorkingDirectory = Path.GetDirectoryName(appUnit.Path);

				myProcess.UseShellExecute = false;
				myProcess.LoadUserProfile = true;
				myProcess.UserName = admin.UserName;
				myProcess.Password = admin.PwdToSecureString();
				myProcess.Arguments = appUnit.Params;
				

				myProcess.WorkingDirectory = sWorkingDirectory;

				Process.Start(myProcess);

				if (checkBox_CloseWhenRun.Checked == true)
				{
					button_Exit_Click(null, null);
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "6645a4a8-bab8-4643-af3b-7312bf00e240");
			}
		}

		
		#region @cmnt skislyuk: [12 September 11, 13:47:47]   [110912_134747]
		///// <summary>
		///// Runs as.
		///// </summary>
		//private void RunAs()
		//{
		//    try
		//    {
		//        AdminEntity admin = new AdminEntity(m_sEncEntity);
		//        ApplicationUnit appUnit = null;

		//        if (listView.SelectedItems.Count > 0)
		//        {
		//            appUnit = (ApplicationUnit)listView.SelectedItems[0].Tag;
		//        }

		//        if (appUnit == null)
		//        {
		//            return;
		//        }

		//        VastAbyss.RunAsEX.StartProcess(admin.UserName
		//                                        , admin.Domain
		//                                        , admin.Password
		//                                        , appUnit.Path);

		//        if (checkBox_CloseWhenRun.Checked == true)
		//        {
		//            button_Exit_Click(null, null);
		//        }
		//    }
		//    catch (Exception exp)
		//    {
		//        Logger.WriteError(exp, "6645a4a8-bab8-4643-af3b-7312bf00e240");
		//    }
		//}
		#endregion @cmnt skislyuk: [12 September 11, 13:47:47]   [110912_134747]


		/// <summary>
		/// Determines whether this instance [can do action].
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance [can do action]; otherwise, <c>false</c>.
		/// </returns>
		private bool CanDoAction()
		{
			bool bRetCode = false;

			try
			{
				using (AdminSettingsForm adminForm = new AdminSettingsForm(true))
				{
					if (adminForm.ShowDialog(this) == DialogResult.OK)
					{
						bRetCode = true;
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "9b88c491-a9da-48d0-8d72-3a067e202974");
			}

			return bRetCode;
		}

		/// <summary>
		/// Saves the config.
		/// </summary>
		private void SaveConfig()
		{
			try
			{
				DataAccessConfig config = new DataAccessConfig();

				config.Entity = m_sEncEntity;
				config.CloseWhenRun = checkBox_CloseWhenRun.Checked;

				foreach (ListViewItem item in listView.Items)
				{
					if ((item.Tag != null) && (item.Tag is ApplicationUnit))
					{
						config.ApplicationsList.Add((ApplicationUnit)item.Tag);
					}
				}

				ConfigurationManager.WriteConfiguration(config);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "b885193d-9bcc-444a-bcff-859ac00a0103");
			}
		}

		/// <summary>
		/// Handles the Click event of the button_Exit control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button_Exit_Click(object sender, EventArgs e)
		{
			try
			{
				SaveConfig();
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "b36d3f48-9e8c-4258-8b7f-9031c84c3538");
			}
			finally
			{
				this.Close();
			}
		}

		/// <summary>
		/// Handles the Load event of the RunAsForm control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void RunAsForm_Load(object sender, EventArgs e)
		{
			if (Program.IsInRunTime == true)
			{
				DataAccessConfig config = new DataAccessConfig();

				config = (DataAccessConfig)ConfigurationManager.GetConfiguration((AppConfigBase)config);

				if ((config != null) && (config.ApplicationsList != null))
				{
					m_sEncEntity = config.Entity;

					foreach (ApplicationUnit appUnit in config.ApplicationsList)
					{
						AddItemToListView(appUnit);
					}

					if (string.IsNullOrEmpty(m_sEncEntity) == true)
					{
						button_RunAs.Enabled = false;
						button_Add.Enabled = false;
					}
				}
			}
		}
	}
}
