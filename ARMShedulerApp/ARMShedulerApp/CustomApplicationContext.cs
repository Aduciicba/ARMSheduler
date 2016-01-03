﻿using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
//using System.Windows.Forms.Integration;
using System.Reflection;
using System.IO;
using Simple.Data;
using Simple.OData;
using Simple.OData.Client;

namespace ARMShedulerApp
{

    public class CustomApplicationContext : ApplicationContext
    {
        private static readonly string IconFileName = "Images/stack.ico";
        private static readonly string DefaultTooltip = "Настройка импорта и отправки уведомлений для Кодекс АРМ";

        public static dynamic db;

		public CustomApplicationContext() 
		{
			InitializeContext();

            if (!OpenDbConnection())
            {
                ExitThread();
            }

            notifyIcon.ContextMenuStrip.Items.Clear();
            notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("&Открыть..", showMainItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("&Настройки..", showSettingsItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(ToolStripMenuItemWithHandler("&Выход", exitItem_Click));
            ShowMainForm(); 
		}

        bool OpenDbConnection()
        {
            if (Properties.Settings.Default.DBPath == "")
            {
                Properties.Settings.Default.DBPath = Application.StartupPath + @"\db\scheduler.sqlite";
                Properties.Settings.Default.Save();
            }

            if (!File.Exists(Properties.Settings.Default.DBPath))
            {
                MessageBox.Show("Не найден файл бпзы данных программы"
                               , "Ошибка"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Error);
                Properties.Settings.Default.DBPath = "";
                Properties.Settings.Default.Save();
                return false;
            }

            try
            {
                db = Database.OpenFile(Properties.Settings.Default.DBPath);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show( "Не удалось открыть подключение к БД: " + ex.Message
                               , "Ошибка"
                               , MessageBoxButtons.OK
                               , MessageBoxIcon.Error);
                return false;
            }
        }

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
        }

       # region support methods

        public ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            if (eventHandler != null) { item.Click += eventHandler; }
            return item;
        }

        # endregion support methods


        # region the forms

        private Form mainForm;

        private void ShowMainForm(string TabName = "tpMain")
        {
            if (mainForm == null)
            {
                mainForm = new fmMain(TabName);
                mainForm.Closed += mainForm_Closed; 
                mainForm.Show();                
            }
            else 
            { 
                mainForm.Activate();
            }
            
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e) 
        { 
            ShowMainForm();    
        }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
        }


        private void showMainItem_Click(object sender, EventArgs e) 
        { 
            ShowMainForm(); 
        }

        private void showSettingsItem_Click(object sender, EventArgs e)
        {
            ShowMainForm("tpSettings");
        }

        private void mainForm_Closed(object sender, EventArgs e)        
        {
            mainForm = null;
        }

        # endregion the forms

        # region generic code 

        private System.ComponentModel.IContainer components;	// a list of components to dispose when the context is disposed
        private NotifyIcon notifyIcon;				            // the icon that sits in the system tray

        private void InitializeContext()
        {
            components = new System.ComponentModel.Container();
            notifyIcon = new NotifyIcon(components)
                             {
                                 ContextMenuStrip = new ContextMenuStrip(),
                                 Icon = new Icon(IconFileName),
                                 Text = DefaultTooltip,
                                 Visible = true
                             };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            notifyIcon.MouseUp += notifyIcon_MouseUp;
        }

		protected override void Dispose( bool disposing )
		{
			if( disposing && components != null) { components.Dispose(); }
		}

        private void exitItem_Click(object sender, EventArgs e) 
		{
            if (
                MessageBox.Show("Вы действительно хотите закрыть программу? Исполнение событий по расписанию будет остановлено."
                               , "Подтверждение"
                               , MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ExitThread();
            }
		}

        protected override void ExitThreadCore()
        {
            if (mainForm != null) { mainForm.Close(); }

            notifyIcon.Visible = false; 
            base.ExitThreadCore();
        }

        # endregion generic code

    }
}