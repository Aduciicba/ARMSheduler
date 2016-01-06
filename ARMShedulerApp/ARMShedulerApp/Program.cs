using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MutexManager;
using NLog;

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
            Logger logger = LogManager.GetCurrentClassLogger();

            if (!SingleInstance.Start()) { return; }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            

            try
            {
                applicationContext = new CustomApplicationContext();
                logger.Info("Запущено приложение");
                Application.Run(applicationContext);
            }
            catch (Exception ex)
            {                
                logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Необработанное исключение в работе программы",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SingleInstance.Stop();
        }

        
    }
}
