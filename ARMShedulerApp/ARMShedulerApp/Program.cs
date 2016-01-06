using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MutexManager;

namespace ARMSchedulerApp
{
    static class Program
    {
        public static CustomApplicationContext applicationContext;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start()) { return; }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            

            try
            {
                applicationContext = new CustomApplicationContext();
                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Необработанное исключение в работе программы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SingleInstance.Stop();
        }

        
    }
}
