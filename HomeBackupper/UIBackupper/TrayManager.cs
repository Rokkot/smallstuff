using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using WinTrayUI;

namespace Backupper
{
    public class TrayManager
    {
        public static string C_OPEN = "&Open";
        public static string C_Exit = "E$xit";
        public static string C_Settings = "&Settings";

        public TrayManager()
        {
            CustomApplicationContext.InitCustomApplicationContext(Assembly.GetExecutingAssembly().GetName().Name
                                                                                , Backupper.Properties.Resources.Backupper.ToBitmap()                                                                               , ContextMenuBuilder
                                                                                , OnOpen
                                                                                , OnDoubleClick
                                                                                , OnExit
                                                                                , C_OPEN);
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
            BackupperForm frm = new BackupperForm();
            frm.ShowDialog();
        }

        private void OnExit()
        {
            MessageBox.Show(C_Exit);
        }

        private void OnDoubleClick()
        {
            BackupperForm frm = new BackupperForm();
            frm.ShowDialog();
        }

        private void ContextMenuBuilder(List<ToolStripMenuItem> _listContextMenuItems)
        {
            if (_listContextMenuItems != null)
            {
                _listContextMenuItems.Add(CustomApplicationContext.CreateStripMenuItem(1, C_Settings, Item_Settings));
            }
        }

        private void Item_Settings(object sender, EventArgs e)
        {
            SettingsForm settignsfrm = new SettingsForm();
            settignsfrm.ShowDialog();
        }
    }
}
