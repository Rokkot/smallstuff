using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Backupper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                TrayManager obj = new TrayManager();

                SKMain.Main_WinTrayApp(obj.AppContext, "asdasdad", true);
            }
            catch (Exception exp)
            {
                Logger.DisplayError(exp.Message);
            }

        }
    }
}
