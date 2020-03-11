using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SoftKeyUtils;

namespace ComputerMetricsCollector
{
	public partial class ComputerMetricsCollectorForm : Form
	{
		public ComputerMetricsCollectorForm()
		{
			InitializeComponent();

			progressBar.UseCustomText = false;
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			try
			{
				string sFilePath = string.Empty;

				progressBar.Value = 1;
				progressBar.Minimum = 1;
				progressBar.Step = 1;

				progressBar.DisplayStyle = ProgressBarDisplayText.Both;

				EnableControls(false);

				progressBar.Visible = false;

				if (radioButtonMachineID.Checked == true)
				{
					sFilePath = GetFilePath("_MachineID");

					File.Delete(sFilePath);

					File.AppendAllText(sFilePath, GetComputerUniqueID());
				}

				if (radioButtonLargeSubSet.Checked == true)
				{
					sFilePath = GetFilePath("_LargeSubSet");
					progressBar.Maximum = Enum.GetNames(typeof(ComputerInfoKeys)).Length;

					if (sFilePath != string.Empty)
					{
						File.Delete(sFilePath);
						CollectSubSetInfo(sFilePath);
					}
				}

				if (radioButtonAllInfo.Checked == true)
				{
					sFilePath = GetFilePath("_AllInfo");
					progressBar.Maximum = Enum.GetNames(typeof(ComputerInfoKeysFull)).Length;

					if (sFilePath != string.Empty)
					{
						File.Delete(sFilePath);
						CollectAllInfo(sFilePath);
					}
				}

				if (sFilePath != string.Empty)
				{
					Process.Start(sFilePath);
				}
			}
			catch (Exception exp)
			{
                Logger.WriteErrorLogOnly(exp, "d57d3dd0-6b37-49d6-af33-5f99cc987377");
				MessageBox.Show(exp.Message);
			}
			finally
			{
				EnableControls(true);
			}
		}

		private void EnableControls(bool _bEnable)
		{
			try
			{
				progressBar.Visible = !_bEnable;
				buttonStart.Enabled = _bEnable;
				radioButtonAllInfo.Enabled = _bEnable;
				radioButtonLargeSubSet.Enabled = _bEnable;
				radioButtonMachineID.Enabled = _bEnable;
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "92bd33bd-d8c8-4afa-b4b2-e8f855688581");
			}

		}

		private string GetFilePath(string _sSuffixs)
		{

			try
			{
				using (FolderBrowserDialog browse = new FolderBrowserDialog())
				{
					browse.ShowNewFolderButton = true;
					browse.Description = "Save Computer Metrics into:";

					if (browse.ShowDialog(this) == DialogResult.OK)
					{
						return Path.Combine(browse.SelectedPath
														, string.Format("{0}{1}.txt"
																		, Environment.MachineName
																		, _sSuffixs));
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "c759f066-83dc-4953-8028-6d3b5418daf6");
			}


			return string.Empty; 
		}

		private void CollectSubSetInfo(string _sFilePath)
		{

			try
			{
				string sInfo = string.Empty;
				progressBar.Visible = true;

				foreach (ComputerInfoKeys eVal in Enum.GetValues(typeof(ComputerInfoKeys)))
				{
					progressBar.CustomText = eVal.ToString().Replace("Win32_", "");
					progressBar.PerformStep();

					if (ComputerMetrics.GetOneKeyInfo(eVal.ToString(), out sInfo) == true)
					{
						File.AppendAllText(_sFilePath, sInfo);
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "6be88bde-ab49-44b9-b8da-3e5650bbb95f");
			}

		}

		private void CollectAllInfo(string _sFilePath)
		{

			try
			{
				string sInfo = string.Empty;
				progressBar.Visible = true;

				foreach (ComputerInfoKeysFull eVal in Enum.GetValues(typeof(ComputerInfoKeysFull)))
				{
					progressBar.CustomText = eVal.ToString().Replace("Win32_", "");
					progressBar.PerformStep();

					if (ComputerMetrics.GetOneKeyInfo(eVal.ToString(), out sInfo) == true)
					{
						File.AppendAllText(_sFilePath, sInfo);
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "99aabef5-82d9-4034-ab3e-07d4bf44c839");
			}

		}

		public string GetComputerUniqueID()
		{

			try
			{
				progressBar.Maximum = 6;
				progressBar.Visible = true;

				StringBuilder sb = new StringBuilder();

				sb.AppendLine("MachineName_" + Environment.MachineName);

				progressBar.CustomText = "CPU ID";
				progressBar.PerformStep();
				sb.Append(ComputerMetrics.CPUID());

				progressBar.CustomText = "BIOS ID";
				progressBar.PerformStep();
				sb.Append(ComputerMetrics.BIOSID());

				progressBar.CustomText = "Disk ID";
				progressBar.PerformStep();
				sb.Append(ComputerMetrics.DiskID());

				progressBar.CustomText = "BaseBoard ID";
				progressBar.PerformStep();
				sb.Append(ComputerMetrics.BaseID());

				progressBar.CustomText = "VideoController ID";
				progressBar.PerformStep();
				sb.Append(ComputerMetrics.VideoID());

				progressBar.CustomText = "NetworkAdapterConfiguration ID";
				progressBar.PerformStep();
				sb.Append(ComputerMetrics.MACID());

				return sb.ToString();
			}
			catch (Exception exp)
			{
				Logger.WriteErrorLogOnly(exp, "c3f3dc42-36e6-4892-8834-4bdc6bdb1d1d");
			}

			return string.Empty;
		}
	}
}
