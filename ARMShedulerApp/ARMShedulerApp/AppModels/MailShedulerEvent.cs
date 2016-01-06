using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace ARMSchedulerApp
{
    public class MailSchedulerEvent : SchedulerEvent
    {
        string mailTemplateName = @"\MailTemplates\NoticeTemplate.html";
        Logger logger = LogManager.GetCurrentClassLogger();

        public MailSchedulerEvent(Event _event)
        {
            _sourceEvent = _event;
            splitWeekDays();
            DateTime dt;
            if ((DateTime.Now.Date + _sourceEvent.start_time.TimeOfDay) > DateTime.Now)
                dt = DateTime.Now.Date;
            else
                dt = DateTime.Now.Date.AddDays(1);
            calcNextStartTime(dt);
        }

        public override void startEvent(finishEventWork fe)
        {
            string result = "Выполнено";
            string err = "";
            calcNextStartTime(DateTime.Now.Date.AddDays(1));
            try
            {
                SQLiteConnection conn = new SQLiteConnection(String.Format("data source={0}", Properties.Settings.Default.KodeksDbPath));
                conn.Open();
                MailSender ms = new MailSender();
                string body = ms.getTemplate(Application.StartupPath + mailTemplateName);
                body = body.Replace("%rep_date%", DateTime.Now.ToShortDateString());
                Dictionary<string, int> data = getMoData(conn);                
                body = body.Replace("%mo%", getLiList(data));
                data = getPzData(conn);
                body = body.Replace("%pz%", getLiList(data));
                data = getIotData(conn);
                body = body.Replace("%iot%", getLiList(data));
                data = getSizData(conn);
                body = body.Replace("%siz%", getLiList(data));
                data = getCompensationData(conn);
                body = body.Replace("%compens%", getLiList(data));
                data = getWorkerData(conn);
                body = body.Replace("%worker%", getLiList(data));                
                string subject = String.Format("Автоматическое уведомление от АРМ ОТ ({0})", DateTime.Now.ToShortDateString());
                foreach (var mail in _sourceEvent.emailList)
                {
                    ms.SendMessage(mail.email, subject, body);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                logger.Error(String.Format("ошибка при отправке почты: {0}", ex.Message));
                result = "Ошибка";
                err = ex.Message;
            }
            fe(result, err, sourceEvent);
        }

        public void TestEvent()
        {
            SQLiteConnection conn = new SQLiteConnection(String.Format("data source={0}", Properties.Settings.Default.DBPath));
                conn.Open();
                MailSender ms = new MailSender();
                Dictionary<string, int> data = getMoData(conn);
                string body = ms.getTemplate(Application.StartupPath + mailTemplateName);
                body = body.Replace("%rep_date%", DateTime.Now.ToShortDateString());
                body = body.Replace("%mo%", getLiList(data));
                
                ms.SendMessage("aduciicba@gmail.com", "Тест", body);
                conn.Close();
        }

        public Dictionary<string, int> getMoData(SQLiteConnection conn)
        {
            Dictionary<string, int> mo = new Dictionary<string, int>();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(ARMQueries.noPlanedMoCount);
                DataRow row = dt.Rows[0];
                mo.Add(
                        "Не запланирован МО(требуется по профессии)"
                      , Convert.IsDBNull(row["noPlannedMoCount"]) ? 0 : Int32.Parse(row["noPlannedMoCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.expiredDateMoCount);
                row = dt.Rows[0];              
                mo.Add(
                        "Закончилось действие предыдущего медосмотра (требуется по профессии)"
                      , Convert.IsDBNull(row["expiredDateMoCount"]) ? 0 : Int32.Parse(row["expiredDateMoCount"].ToString())
                      );
                mo.Add(
                        "Заканчивается действие предыдущего медосмотра (требуется по профессии)"
                      , Convert.IsDBNull(row["closeExpiredDateMoCount"]) ? 0 : Int32.Parse(row["closeExpiredDateMoCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.closePlanDateMoCount);
                row = dt.Rows[0];
                mo.Add(
                        "Просрочен срок проведения медосмотра"
                      , Convert.IsDBNull(row["expiredPlanMoCount"]) ? 0 : Int32.Parse(row["expiredPlanMoCount"].ToString())
                      );
                mo.Add(
                        "Подходит дата проведения медосмотра"
                      , Convert.IsDBNull(row["closePlanMoCount"]) ? 0 : Int32.Parse(row["closePlanMoCount"].ToString())
                      );
            }

            return mo;
        }

        public Dictionary<string, int> getPzData(SQLiteConnection conn)
        {
            Dictionary<string, int> pz = new Dictionary<string, int>();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(ARMQueries.noPlanedPzCount);
                DataRow row = dt.Rows[0];
                pz.Add(
                        "Не запланирована проверка знаний (требуется по профессии)"
                      , Convert.IsDBNull(row["noPlannedPzCount"]) ? 0 : Int32.Parse(row["noPlannedPzCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.expiredDatePzCount);
                row = dt.Rows[0];
                pz.Add(
                        "Закончилось действие предыдущей проверки знаний (требуется по профессии)"
                      , Convert.IsDBNull(row["expiredDatePzCount"]) ? 0 : Int32.Parse(row["expiredDatePzCount"].ToString())
                      );
                pz.Add(
                        "Заканчивается действие предыдущей проверки знаний (требуется по профессии)"
                      , Convert.IsDBNull(row["closeExpiredDatePzCount"]) ? 0 : Int32.Parse(row["closeExpiredDatePzCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.closePlanDatePzCount);
                row = dt.Rows[0];
                pz.Add(
                        "Просрочен срок проведения проверки знаний"
                      , Convert.IsDBNull(row["expiredPlanPzCount"]) ? 0 : Int32.Parse(row["expiredPlanPzCount"].ToString())
                      );
                pz.Add(
                        "Подходит дата проведения проверки знаний"
                      , Convert.IsDBNull(row["closePlanPzCount"]) ? 0 : Int32.Parse(row["closePlanPzCount"].ToString())
                      );
            }

            return pz;
        }

        public Dictionary<string, int> getIotData(SQLiteConnection conn)
        {
            Dictionary<string, int> pz = new Dictionary<string, int>();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(ARMQueries.noPlanedIotCount);
                DataRow row = dt.Rows[0];
                pz.Add(
                        "Не запланирована проверка знаний (требуется по профессии)"
                      , Convert.IsDBNull(row["noPlannedPzCount"]) ? 0 : Int32.Parse(row["noPlannedPzCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.expiredDateIotCount);
                row = dt.Rows[0];
                pz.Add(
                        "Закончилось действие предыдущей проверки знаний (требуется по профессии)"
                      , Convert.IsDBNull(row["expiredDatePzCount"]) ? 0 : Int32.Parse(row["expiredDatePzCount"].ToString())
                      );
                pz.Add(
                        "Заканчивается действие предыдущей проверки знаний (требуется по профессии)"
                      , Convert.IsDBNull(row["closeExpiredDatePzCount"]) ? 0 : Int32.Parse(row["closeExpiredDatePzCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.closePlanDateIotCount);
                row = dt.Rows[0];
                pz.Add(
                        "Просрочен срок проведения проверки знаний"
                      , Convert.IsDBNull(row["expiredPlanPzCount"]) ? 0 : Int32.Parse(row["expiredPlanPzCount"].ToString())
                      );
                pz.Add(
                        "Подходит дата проведения проверки знаний"
                      , Convert.IsDBNull(row["closePlanPzCount"]) ? 0 : Int32.Parse(row["closePlanPzCount"].ToString())
                      );
            }

            return pz;
        }

        public Dictionary<string, int> getSizData(SQLiteConnection conn)
        {
            Dictionary<string, int> pz = new Dictionary<string, int>();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(ARMQueries.sizCard);
                DataRow row = dt.Rows[0];
                pz.Add(
                        "Не создана личная карточка учета СИЗ для работника (требуется по профессии)"
                      , Convert.IsDBNull(row["needSizLCardCount"]) ? 0 : Int32.Parse(row["needSizLCardCount"].ToString())
                      );
                pz.Add(
                        "Не заполнена лицевая сторона личной карточки учета СИЗ для работника"
                      , Convert.IsDBNull(row["noFillFrontSideCount"]) ? 0 : Int32.Parse(row["noFillFrontSideCount"].ToString())
                      );
                pz.Add(
                        "Не выданы СИЗ работнику согласно лицевой стороне ЛК"
                      , Convert.IsDBNull(row["noFillBackSideCount"]) ? 0 : Int32.Parse(row["noFillBackSideCount"].ToString())
                      );
                dt = sh.Select(ARMQueries.smivCard);
                row = dt.Rows[0];
                pz.Add(
                        "Не создана личная карточка учета смывающих для работника (требуется по профессии)"
                      , Convert.IsDBNull(row["needSizLCardCount"]) ? 0 : Int32.Parse(row["needSizLCardCount"].ToString())
                      );
                pz.Add(
                        "Не заполнена лицевая сторона личной карточки учета смывающих для работника"
                      , Convert.IsDBNull(row["noFillFrontSideCount"]) ? 0 : Int32.Parse(row["noFillFrontSideCount"].ToString())
                      );
                pz.Add(
                        "Не выданы смывающие работнику согласно лицевой стороне ЛК смывающих"
                      , Convert.IsDBNull(row["noFillBackSideCount"]) ? 0 : Int32.Parse(row["noFillBackSideCount"].ToString())
                      );
            }

            return pz;
        }

        public Dictionary<string, int> getCompensationData(SQLiteConnection conn)
        {
            Dictionary<string, int> pz = new Dictionary<string, int>();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(ARMQueries.doplWorker);
                DataRow row = dt.Rows[0];
                pz.Add(
                        "Не указаны компенсации работнику (требуется по профессии)"
                      , Convert.IsDBNull(row["needDoplCount"]) ? 0 : Int32.Parse(row["needDoplCount"].ToString())
                      );
            }

            return pz;
        }

        public Dictionary<string, int> getWorkerData(SQLiteConnection conn)
        {
            Dictionary<string, int> pz = new Dictionary<string, int>();
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.Connection = conn;
                SQLiteHelper sh = new SQLiteHelper(cmd);
                DataTable dt = sh.Select(ARMQueries.workersAtt);
                DataRow row = dt.Rows[0];
                pz.Add(
                        "Не указаны условия труда на рабочем месте работника"
                      , Convert.IsDBNull(row["needUtClassCount"]) ? 0 : Int32.Parse(row["needUtClassCount"].ToString())
                      );
                pz.Add(
                        "Заканчивается срок действия результатов аттестации по УТ"
                      , Convert.IsDBNull(row["closeExpiredAttDateCount"]) ? 0 : Int32.Parse(row["closeExpiredAttDateCount"].ToString())
                      );
                pz.Add(
                        "Просрочен срок действия результатов аттестации по УТ"
                      , Convert.IsDBNull(row["expiredAttDateCount"]) ? 0 : Int32.Parse(row["expiredAttDateCount"].ToString())
                      );
            }

            return pz;
        }

        string getLiList(Dictionary<string, int> dict)
        {
            string li = "<li>{0}: {1}</li>";
            string res = "";
            foreach (var r in dict)
            {
                res += String.Format(li, r.Key, r.Value) + Environment.NewLine;
            }
            return res;
        }

        

    }
}
