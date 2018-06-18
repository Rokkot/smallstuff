using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backupper
{
    public partial class BackupperForm : Form
    {
        public BackupperForm()
        {
            InitializeComponent();
        }

        private void BackupperForm_Load(object sender, EventArgs e)
        {

        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog(this);
        }
    }
}
