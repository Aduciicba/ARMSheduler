using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

using Simple.Data;
using Simple.OData;
using Simple.OData.Client;

namespace ARMShedulerApp
{
    public delegate void refreshUI();
    public partial class fmMain : Form
    {
        string firstShownTabName = "tpMain";
        ShedulerEventManager sem;
        refreshUI _refreshUI;
        
        public fmMain(string TabName)
        {
            InitializeComponent();
            firstShownTabName = TabName;
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/stack.ico");
            _refreshUI = refresh;
            loadControls();
            startScheduler();
                     
        }

        void loadControls()
        {
            deFrom.DateTime = DateTime.Now.AddDays(-14);
            deTo.DateTime = DateTime.Now;
            refreshLog();
            SelectTabPage(firstShownTabName);   
        }

        public void SelectTabPage(string TabName)
        {
            tcMain.SelectedTabPage = tcMain.TabPages.Single(t => t.Name == TabName);
        }

        void startScheduler()
        {
            sem = new ShedulerEventManager(_refreshUI);
            sem.startScheduler();
        }

        void refreshLog()
        {
            var db = CustomApplicationContext.db;

            dynamic EventAlias;
            dynamic EventTypesAlias;

            var loglist = db.EventLogs.Find(db.EventLogs.Event_time >= deFrom.DateTime && db.EventLogs.Event_time < deTo.DateTime)
                            .Join(db.Events.As("EventInfo"), out EventAlias)
                            .On(db.EventLogs.Fid_event == EventAlias.Id_event)
                            .Join(db.EventTypes.As("EventType"), out EventTypesAlias)
                            .On(EventAlias.Fid_event_type == EventTypesAlias.Id_event_type)
                                        //.With(EventAlias)
                                        //.With(eventtypes)
                            .Select(
                                     EventTypesAlias.Name.As("Event_type_name")       
                                   , db.EventLogs.Event_time                                   
                                   , db.EventLogs.Event_state
                                   , db.EventLogs.Event_errors
                                   )
    ;


            gcEventsLog.DataSource = (loglist.ToList<EventLog>() as List<EventLog>).OrderByDescending(x => x.event_time);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {



        }

        void refresh()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(_refreshUI);
                return;
            }
            refreshLog();
        }

        #region Общие настройки

        void LoadSettings()
        {
            beImportDirPath.Text = Properties.Settings.Default.ImportDirPath;
            beArmDbPath.Text = Properties.Settings.Default.KodeksDbPath;
            teEmail.Text = Properties.Settings.Default.Email;
            teMailLogin.Text = Properties.Settings.Default.EmailLogin;
            teMailPassword.Text = Properties.Settings.Default.EmailPassword;
            teMailServer.Text = Properties.Settings.Default.SmtpServer;
            teMailServerPort.Text = Properties.Settings.Default.SmtpPort;
        }
        private void btnTestMail_Click(object sender, EventArgs e)
        {
            if (ValidateSettings())
            {
                MailSender ms = new MailSender(
                                                teEmail.Text.Trim()
                                              , Int32.Parse(teMailServerPort.Text.Trim())
                                              , teMailServer.Text.Trim()
                                              , teMailLogin.Text.Trim()
                                              , teMailPassword.Text.Trim());
                string err_msg = ms.SendTestMessage();
                if (err_msg == "")
                {
                    MessageBox.Show("Проверка пройдена, настройки введены корректно", "Уведомление", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Не удалось отпарвить сообщение: " + err_msg, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        bool ValidateSettings()
        {
            if (teEmail.Text.Trim() == "")
            {
                MessageBox.Show("Адрес электронной почты не должен быть пустым", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (teMailLogin.Text.Trim() == "")
            {
                MessageBox.Show("Имя пользователя не должно быть пустым", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (teMailPassword.Text.Trim() == "")
            {
                MessageBox.Show("Пароль не должен быть пустым", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (teMailServer.Text.Trim() == "")
            {
                MessageBox.Show("Адрес сервера исходящей почты не должен быть пустым", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (teMailServerPort.Text.Trim() == "")
            {
                MessageBox.Show("Номер порта почтового сервера не должен быть пустым", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                int res = 0;
                if (!Int32.TryParse(teMailServerPort.Text.Trim(), out res))
                {
                    MessageBox.Show("Номер порта почтового сервера должен быть числом", "Ошибка", MessageBoxButtons.OK);
                    return false;
                }

            }
            return true;
        }

        private void beImportDirPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (fbdImportDir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                beImportDirPath.Text = fbdImportDir.SelectedPath;
            }
        }

        private void beArmDbPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ofdDbPath.Multiselect = false;

            if (ofdDbPath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                beArmDbPath.Text = ofdDbPath.FileName;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ImportDirPath = beImportDirPath.Text;
            Properties.Settings.Default.KodeksDbPath = beArmDbPath.Text;
            Properties.Settings.Default.Email = teEmail.Text.Trim();
            Properties.Settings.Default.EmailLogin = teMailLogin.Text.Trim();
            Properties.Settings.Default.EmailPassword = teMailPassword.Text.Trim();
            Properties.Settings.Default.SmtpServer = teMailServer.Text.Trim();
            Properties.Settings.Default.SmtpPort = teMailServerPort.Text.Trim();
            Properties.Settings.Default.Save();
        }
        #endregion


        private void tcMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "tpSettings")
            {
                LoadSettings();
            }
        }
    }

}
