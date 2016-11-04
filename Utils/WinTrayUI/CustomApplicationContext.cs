using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;
using Utils;
using System.Collections.Generic;

namespace WinTrayUI
{
	public delegate void DoubleClickDelegate();
	public delegate void OpenDelegate();
	public delegate void OnExitAppDelegate();
	public delegate void ContextMenuBuilderDelegate(List<ToolStripMenuItem> _listContextMenuItems);

	#region Example and usage of the CustomApplicationContext with ManagerClass 
	/*
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
	*/
	#endregion

	public sealed class CustomApplicationContext : ApplicationContext
	{
		private static CustomApplicationContext instance = null;

		private System.ComponentModel.IContainer components;
		private NotifyIcon notifyIcon = null;

		private Bitmap m_bmpIconFileName = null;
		private string m_DefaultTooltip = string.Empty;
		private string m_sOpenMenueItemDisplayText = string.Empty;
		private ContextMenuBuilderDelegate m_ContextMenuBuilderDelegate = null;
		private OpenDelegate m_OpenDelegate = null;
		private DoubleClickDelegate m_DoubleClickDelegate = null;
		private OnExitAppDelegate m_OnExitAppDelegate = null;

		public static CustomApplicationContext Instance
		{
			get
			{
				if (instance == null)
				{
					throw new Exception("The CustomApplicationContext in not initialized. Please call InitCustomApplicationContext(...) first.");
				}

				return instance;
			}
		}

		public static void InitCustomApplicationContext(string _DefaultTooltip
															, Bitmap _bmpIconFileName
															, ContextMenuBuilderDelegate _ContextMenuBuilderDelegate
															, OpenDelegate _OpenDelegate
															, DoubleClickDelegate _DoubleClickDelegate
															, OnExitAppDelegate _OnExitAppDelegate
															, string _sOpenMenueItemDisplayText)
		{

			try
			{
				instance = new CustomApplicationContext(_DefaultTooltip
																, _bmpIconFileName
																, _ContextMenuBuilderDelegate
																, _OpenDelegate
																, _DoubleClickDelegate
																, _OnExitAppDelegate
																, _sOpenMenueItemDisplayText);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "99fa623c-2fd1-40dd-93ba-752d1d69c857");
			}

		}

		private CustomApplicationContext(string _DefaultTooltip
															, Bitmap _bmpIconFileName
															, ContextMenuBuilderDelegate _ContextMenuBuilderDelegate
															, OpenDelegate _OpenDelegate
															, DoubleClickDelegate _DoubleClickDelegate
															, OnExitAppDelegate _OnExitAppDelegate
															, string _sOpenMenueItemDisplayText)
		{
			m_bmpIconFileName = _bmpIconFileName;
			m_DefaultTooltip = _DefaultTooltip;
			m_ContextMenuBuilderDelegate = _ContextMenuBuilderDelegate;
			m_OpenDelegate = _OpenDelegate;
			m_DoubleClickDelegate = _DoubleClickDelegate;
			m_OnExitAppDelegate = _OnExitAppDelegate;
			m_sOpenMenueItemDisplayText = _sOpenMenueItemDisplayText;

			InitializeContext();
		}

		private void InitializeContext()
		{
			try
			{
				components = new System.ComponentModel.Container();
				notifyIcon = new NotifyIcon(components);
				notifyIcon.ContextMenuStrip = new ContextMenuStrip();
				notifyIcon.Icon = Icon.FromHandle(m_bmpIconFileName.GetHicon());
				notifyIcon.Text = m_DefaultTooltip;
				notifyIcon.Visible = true;
				notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
				notifyIcon.DoubleClick += notifyIcon_DoubleClick;
				notifyIcon.MouseUp += notifyIcon_MouseUp;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "c7b35e76-1962-4bf4-ba88-e0cb33e384e5");
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}

		private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
		{

			try
			{
				e.Cancel = false;
				List<ToolStripMenuItem> listContextMenuItems = new List<ToolStripMenuItem>();

				if (m_ContextMenuBuilderDelegate != null)
				{
					m_ContextMenuBuilderDelegate(listContextMenuItems);
				}

				notifyIcon.ContextMenuStrip.Items.Clear();
				notifyIcon.ContextMenuStrip.Items.Add(CreateStripMenuItem(1, "&Open", OnOpenClick));

				notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

				if ((listContextMenuItems != null) && (listContextMenuItems.Count > 0))
				{
					notifyIcon.ContextMenuStrip.Items.AddRange(listContextMenuItems.ToArray());
				}

				notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
				notifyIcon.ContextMenuStrip.Items.Add(CreateStripMenuItem(2, "E&xit", OnExit));
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "a60e309d-9721-4c0d-aa72-d744d93bb2c3");
			}

		}

		public static ToolStripMenuItem CreateStripMenuItem(int _iCommandID
																						, string displayText)
		{
			return CreateStripMenuItem(_iCommandID, displayText, null, string.Empty, null);
		}

		public static ToolStripMenuItem CreateStripMenuItem(int _iCommandID
																						, string displayText
																						, EventHandler _OnClickMenueItemHandler)
		{
			return CreateStripMenuItem(_iCommandID, displayText, null, string.Empty, _OnClickMenueItemHandler);
		}

		public static ToolStripMenuItem CreateStripMenuItem( int _iCommandID
																				, string displayText
																				, Image _Image
																				, string _ToolTipText
																				, EventHandler _OnClickMenueItemHandler)
		{
			try
			{
				ToolStripMenuItem item = new ToolStripMenuItem(displayText);

				item.Click += _OnClickMenueItemHandler;
				item.Image = _Image;
				item.Tag = _iCommandID;

				item.ToolTipText = (string.IsNullOrWhiteSpace(_ToolTipText)) ? displayText : _ToolTipText;

				return item;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "7a8945a2-9a77-4398-a388-c0e2e66006fa");
			}

			return null;
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (m_DoubleClickDelegate != null)
				{
					m_DoubleClickDelegate();
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "ce200180-2d8e-4d10-8aad-421b7bc323b2");
			}
		}

		private void OnOpenClick(object sender, EventArgs e)
		{
			if (m_OpenDelegate != null)
			{
				m_OpenDelegate();
			}
		}

		private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
		{
			try
			{
				if (e.Button == MouseButtons.Left)
				{
					MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
					mi.Invoke(notifyIcon, null);
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "4309858e-8078-43fa-905a-053f2556ae87");
			}
		}

		private void OnExit(object sender, EventArgs e)
		{
			bool bExit = true;

			try
			{
				if (m_OnExitAppDelegate != null)
				{
					m_OnExitAppDelegate();
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "3011537d-6797-41b9-9518-09ad802f29cf");
			}
			finally
			{
				if (bExit == true)
				{
					ExitThread();
				}
			}
		}

		protected override void ExitThreadCore()
		{
			try
			{
				notifyIcon.Visible = false;
				base.ExitThreadCore();
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "c060c326-462b-4f7c-8cb1-519e6bf40b92");
			}
		}
	}
}
