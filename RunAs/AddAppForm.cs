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
	public partial class AddAppForm : Form
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AddAppForm"/> class.
		/// </summary>
		public AddAppForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Handles the Click event of the button_Browse control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button_Browse_Click(object sender, EventArgs e)
		{
			try
			{
				using (OpenFileDialog dlg = new OpenFileDialog())
				{
					dlg.Multiselect = false;

					if (dlg.ShowDialog(this) == DialogResult.OK)
					{
						textBox_AppNamePath.Text = dlg.FileName;
						textBox_Label.Text = dlg.SafeFileName;
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "4c176858-f846-431b-9175-f36a75ff234f");
			}
		}

		/// <summary>
		/// Gets the application unit.
		/// </summary>
		/// <value>The application unit.</value>
		public ApplicationUnit ApplicationUnit
		{
			get
			{
				ApplicationUnit unit = null;

				try
				{
					int iIndex = 0;

					if ((string.IsNullOrEmpty(textBox_AppNamePath.Text) == false)
						&& (string.IsNullOrEmpty(textBox_Label.Text) == false))
					{
						List<string> lCmdLine = null;

						if (textBox_AppNamePath.Text.Contains('\"') == true)
						{
							lCmdLine = new List<string>(textBox_AppNamePath.Text.Split('\"'));

							while (iIndex < lCmdLine.Count)
							{
								if (lCmdLine[iIndex] == string.Empty)
								{
									lCmdLine.RemoveAt(iIndex);
								}
								else
								{
									iIndex++;
								}
							}

							unit = new ApplicationUnit();

							if (lCmdLine.Count > 0)
							{
								unit.Path = lCmdLine[0];
							}

							if (lCmdLine.Count > 1)
							{
								unit.Params = lCmdLine[1];
							}

							unit.Label = textBox_Label.Text;
						}
						else
						{
							lCmdLine = new List<string>(textBox_AppNamePath.Text.Split(' '));

							while (iIndex < lCmdLine.Count)
							{
								if (lCmdLine[iIndex] == string.Empty)
								{
									lCmdLine.RemoveAt(iIndex);
								}
								else
								{
									iIndex++;
								}
							}

							if (lCmdLine != null)
							{
								unit = new ApplicationUnit();

								if (lCmdLine.Count > 0)
								{
									unit.Path = lCmdLine[0];
								}

								string sParam = string.Empty;

								if (lCmdLine.Count > 1)
								{
									for (int i = 1; i < lCmdLine.Count; i++)
									{
										sParam += string.Format("{0} ", lCmdLine[i]);
									}

									unit.Params = sParam;
								}

								unit.Label = textBox_Label.Text;
							}
						}

						return unit;
					}
				}
				catch (Exception exp)
				{
					Logger.WriteError(exp, "bf988a39-3608-4b0d-85a8-b5d309d99ce4");
				}

				return unit;
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
				if ((string.IsNullOrEmpty(textBox_AppNamePath.Text) == false)
					&& (string.IsNullOrEmpty(textBox_Label.Text) == false))
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					if (string.IsNullOrEmpty(textBox_AppNamePath.Text) == true)
					{
						MessageBox.Show("Please provide a full application path.");
						textBox_AppNamePath.Focus();
					}

					if (string.IsNullOrEmpty(textBox_Label.Text) == true)
					{
						MessageBox.Show("Please provide an application label.");
						textBox_Label.Focus();
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "3e451f5d-7077-462f-b2bb-04ebe30408b7");
			}

		}
	}
}
