using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTrayUI;

namespace TrayUIFrameworkTest
{
	public class ManagerClass
	{

		public ManagerClass()
		{
			CustomApplicationContext.InitCustomApplicationContext("asdasdad"
																				, TrayUIFrameworkTest.Properties.Resources.Flickr_1
																				, ContextMenuBuilder
																				, OnOpen
																				, OnDoubleClick
																				, OnExit
																				, "&Open App");
		}

		public CustomApplicationContext AppContext
		{
			get
			{
				return CustomApplicationContext.Instance;
			}
		}

		private void OnOpen()
		{
			Form1 frm = new Form1();
			frm.ShowDialog();
		}

		private void OnExit()
		{
			MessageBox.Show("Exit");
		}

		private void OnDoubleClick()
		{
			Form1 frm = new Form1();
			frm.ShowDialog();
		}

		private void ContextMenuBuilder(List<ToolStripMenuItem> _listContextMenuItems)
		{
			if (_listContextMenuItems != null)
			{
				_listContextMenuItems.Add(CustomApplicationContext.CreateStripMenuItem(1, "Show &Details", Item_Click));
			}
		}

		private void Item_Click(object sender, EventArgs e)
		{

		}
	}
}
