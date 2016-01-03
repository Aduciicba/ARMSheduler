using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MutexManager;

namespace ARMShedulerApp
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start()) { return; }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var applicationContext = new CustomApplicationContext();
            Application.Run(applicationContext);
            
            //try
            //{
            //    var applicationContext = new CustomApplicationContext();
            //    Application.Run(applicationContext);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Program Terminated Unexpectedly",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            SingleInstance.Stop();
        }
        
    }
}
