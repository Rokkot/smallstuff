using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinTrayUI;

namespace SKFlickrSyncUI
{
    class AppContextManager
    {
        public AppContextManager()
        {
            CustomApplicationContext.InitCustomApplicationContext("SKFlickrSyncUI"
                                                                    , SKFlickrSyncUI.Properties.Resources.Flickr_1
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
            FlickrSyncMonitorForm frm = new FlickrSyncMonitorForm();
            frm.ShowDialog();
        }

        private void OnExit()
        {
            MessageBox.Show("Exit");
        }

        private void OnDoubleClick()
        {
            FlickrSyncMonitorForm frm = new FlickrSyncMonitorForm();
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
