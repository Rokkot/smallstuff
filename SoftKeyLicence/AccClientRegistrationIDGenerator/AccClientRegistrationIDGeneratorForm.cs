using System;
using System.Windows.Forms;
using SoftKeyUtils;

namespace AccClientRegistrationIDGenerator
{
	public partial class AccClientRegistrationIDGeneratorForm : Form
	{
		public AccClientRegistrationIDGeneratorForm()
		{
			InitializeComponent();

			EnableControls(true);
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			try
			{
				progressBar.PerformStep();
				progressBar.Minimum = 1;
				progressBar.Step = 1;

				EnableControls(false);

				progressBar.Maximum = 6;
				progressBar.Visible = true;

				textEdit.Text = ComputerMetrics.GetComputerUniqueID(PerformProgressBarStep);
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "2b8f6ffe-3229-4692-a3a7-e8b128f38c27");
			}
			finally
			{
				EnableControls(true);
			}
		}

		public void PerformProgressBarStep()
		{
			try
			{
				progressBar.PerformStep();
			}
			catch (Exception exp)
			{
                Logger.WriteErrorLogOnly(exp, "b21a1554-6914-43c8-b8cd-93ebbfd17ec0");
			}
		}

		private void EnableControls(bool _bEnable)
		{
			progressBar.Visible = !_bEnable;
			buttonStart.Enabled = _bEnable;
			textEdit.Visible = _bEnable;
			labelControl1.Visible = _bEnable;
		}
	}
}
