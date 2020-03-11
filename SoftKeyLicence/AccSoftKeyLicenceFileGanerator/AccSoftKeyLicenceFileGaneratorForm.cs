using System;
using System.Windows.Forms;
using SoftKeyUtils;

namespace AccSoftKeyLicenceFileGanerator
{
	public partial class AccSoftKeyLicenceFileGaneratorForm : Form
	{
		public AccSoftKeyLicenceFileGaneratorForm()
		{
			InitializeComponent();
		}

		private void buttonGO_Click(object sender, EventArgs e)
		{
			try
			{
				if (textBoxRegistrationID.Text == string.Empty)
				{
					textBoxRegistrationID.Focus();
					return;
				}

				using (SoftLicence licence = new SoftLicence())
				{
					licence.GenerateLicenceFile(textBoxRegistrationID.Text, GetFilePath());
				}
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "e138b2c1-cc3e-4ed6-b3d7-eb8b959198c3");
			}
		}

		private string GetFilePath()
		{
			try
			{
				using (FolderBrowserDialog browse = new FolderBrowserDialog())
				{
					browse.ShowNewFolderButton = true;
					browse.Description = "Save Computer Metrics into:";

					if (browse.ShowDialog(this) == DialogResult.OK)
					{
						return browse.SelectedPath;
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "4f7d8aa9-aded-44a3-9269-e6a9c808e1aa");
			}


			return string.Empty;
		}
	}
}
