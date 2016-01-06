using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace ARMSchedulerApp
{
    public class ImportSchedulerEvent : SchedulerEvent
    {
        string mailTemplateName = @"\MailTemplates\ImportTemplate.html";

        List<string> _filesList;
        SQLiteHelper _sh;
        List<ImportWorker> _badWorkersList;

        Dictionary<string, int> _fileInfo;
        int _workersCount;
        int _importedWorkersCount;

        Dictionary<string, string> _localProfList;
        Dictionary<string, string> localProfList
        {
            get
            {
                if (_localProfList == null)
                {
                    _localProfList = new Dictionary<string, string>();
                    DataTable lp = _sh.Select("select * from LocalProf");
                    foreach(DataRow r in lp.Rows)
                    {
                        _localProfList.Add(r["Id"].ToString(), r["Name"].ToString());
                    }
                }
                return _localProfList;
            }
        }

        Dictionary<string, string> _deptList;
        Dictionary<string, string> deptList
        {
            get
            {
                if (_deptList == null)
                {
                    _deptList = new Dictionary<string, string>();
                    DataTable d = _sh.Select("select * from Dept");
                    foreach (DataRow r in d.Rows)
                    {
                        _deptList.Add(r["Id"].ToString(), r["Code"].ToString());
                    }
                }
                return _deptList;
            }
        }

        Dictionary<string, string> _workerList;
        Dictionary<string, string> workerList
        {
            get
            {
                if (_workerList == null)
                {
                    _workerList = new Dictionary<string, string>();
                    DataTable d = _sh.Select("select * from Worker");
                    foreach (DataRow r in d.Rows)
                    {
                        _workerList.Add(r["Id"].ToString(), r["TabNumber"].ToString());
                    }
                }
                return _workerList;
            }
        }
        public ImportSchedulerEvent(Event _event)
        {
            _sourceEvent = _event;
            splitWeekDays();
            calcNextStartTime(DateTime.Now.Date);
        }
        public override void startEvent(finishEventWork fe)
        {
            string result = "Выполнено";
            string err = "";
            calcNextStartTime(DateTime.Now.Date.AddDays(1));
            _filesList = new List<string>();
            _localProfList = null;
            _deptList = null;
            _workerList = null;
            _badWorkersList = new List<ImportWorker>();
            _fileInfo = new Dictionary<string, int>();
            _workersCount = 0;
            _importedWorkersCount = 0;
            try
            {
                getFilesList();
                if (_filesList.Count == 0)
                    err = "Не было найдено файлов для импорта";
                SQLiteConnection conn = new SQLiteConnection(String.Format("data source={0}", Properties.Settings.Default.KodeksDbPath));
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                _sh = new SQLiteHelper(cmd);
                foreach (var f in _filesList)
                {
                    importFile(f);
                }
                sendEmailNotify();
            }
            catch (Exception ex)
            {
                result = "Ошибка";
                err = ex.Message;
            }
            fe(result, err, sourceEvent);
        }

        public void Test()
        {
            string result = "Выполнено";
            string err = "";
            calcNextStartTime(DateTime.Now.Date.AddDays(1));
            _filesList = new List<string>();
            _localProfList = null;
            _deptList = null;
            _workerList = null;
            _badWorkersList = new List<ImportWorker>();
            _fileInfo = new Dictionary<string, int>();
            _workersCount = 0;
            _importedWorkersCount = 0;
            try
            {
                getFilesList();
                if (_filesList.Count == 0)
                    err = "Не было найдено файлов для импорта";
                SQLiteConnection conn = new SQLiteConnection(String.Format("data source={0}", Properties.Settings.Default.KodeksDbPath));
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                _sh = new SQLiteHelper(cmd);
                foreach (var f in _filesList)
                {
                    importFile(f);
                }
                sendEmailNotify();
            }
            catch (Exception ex)
            {
                result = "Ошибка";
                err = ex.Message;
            }
        }

        void getFilesList()
        {
            _filesList = Directory.EnumerateFiles(Properties.Settings.Default.ImportDirPath, Properties.Settings.Default.ImportFileMask).ToList();
        }

        /*
         * Структура:
         * 0. Номер по порядку
         * 1. Дата приема на работу
         * 2. Дата увольнения
         * 3. ФИО
         * 4. Подразделение
         * 5. Должность
         * 6. Табельный номер
         * 7. Пол
         * 8. Код подразделения
         */
        void importFile(string fileName)
        {
            List<ImportWorker> importWorkerList = new List<ImportWorker>();
            Dictionary<string, Guid> importProfList = new Dictionary<string, Guid>();

            List<string[]> workers = openCsv(fileName);
            _fileInfo.Add(fileName, workers.Count);
            _workersCount += workers.Count;
            foreach(var warr in workers)
            {
                ImportWorker impw = new ImportWorker();
                impw.fileName = fileName;
                impw.TabNumber = warr[6].Trim();
                if (impw.TabNumber == "")
                {
                    impw.errors += "Табельный номер не должен быть пустым" + Environment.NewLine;
                }
                if (workerList.ContainsValue(impw.TabNumber))
                {
                    impw.ID = Guid.Parse(workerList.First(w => w.Value == impw.TabNumber).Key);
                }
                string deptCode = warr[8].Trim();
                if (deptList.ContainsValue(deptCode))
                {
                    impw.DeptID = Guid.Parse(deptList.First(w => w.Value == deptCode).Key); 
                }
                else
                {
                    impw.errors += "Ошибка сопоставления подразделения" + Environment.NewLine;
                }
                string FIO = warr[3].Trim();
                if (FIO.Count(x => x == ' ') < 2)
                {
                    impw.errors += "Ошибка разбора ФИО: строка содержит менее двух пробелов" + Environment.NewLine;
                }
                else
                {
                    string[] fio = FIO.Split(' ');
                    impw.Fam = fio[0];
                    impw.Name = fio[1];
                    impw.Otch = fio[2];
                }
                string sex = warr[7].Trim();
                switch (sex)
                {
                    case "Мужской": impw.Pol = 0; break;
                    case "Женский": impw.Pol = 1; break;
                    case "М": impw.Pol = 0; break;
                    case "Ж": impw.Pol = 1; break;
                    default: impw.errors += "Некорректно указан пол работника" + Environment.NewLine; break;
                }
                string tmpDate = warr[1].Trim() == "-" ? "" : warr[1].Trim();
                if (tmpDate != "")
                {
                    try
                    {
                        impw.StartWorkDate = Convert.ToDateTime(tmpDate);
                    }
                    catch
                    {
                        impw.errors += "Ошибка в дате приема на работу" + Environment.NewLine;
                    }
                }
                tmpDate = warr[2].Trim() == "-" ? "" : warr[2].Trim();
                if (tmpDate != "")
                {
                    try
                    {
                        impw.FiredDate = Convert.ToDateTime(tmpDate);
                    }
                    catch
                    {
                        impw.errors += "Ошибка в дате увольнения" + Environment.NewLine; ;
                    }
                }
                string prof = warr[5].Trim();
                if (localProfList.ContainsValue(prof))
                {
                    impw.localProfID =  Guid.Parse(localProfList.First(w => w.Value == prof).Key);
                }
                else
                {
                    if (importProfList.ContainsKey(prof))
                    {
                        impw.localProfID = importProfList[prof];
                    }
                    else
                    {
                        if (impw.errors == "" || impw.errors == null)
                        {
                            Guid profId = Guid.NewGuid();
                            importProfList.Add(prof, profId);
                            impw.localProfID = profId;
                        }
                    }
                }
                importWorkerList.Add(impw);
            }
            importLocalProfs(importProfList);
            importWorkers(importWorkerList.Where(w => w.errors == "" || w.errors == null).ToList());
            _badWorkersList.AddRange(importWorkerList.Where(w => w.errors != "" && w.errors != null));
            foreach(var p in importProfList)
            {
                localProfList.Add(p.Value.ToString(), p.Key);
            }
            deleteFile(fileName);
        }

        List<string[]> openCsv(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            List<string[]> lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(';');
                lines.Add(Line);
                Row++;
                Console.WriteLine(Row);
            }
            sr.Close();
            return lines;
        }

        void importLocalProfs(Dictionary<string, Guid> profList)
        {
            const string insertProf = @"insert into LocalProf(ID, Name) Values('{0}', '{1}');";

            if (profList.Count == 0)
                return;
            string command = "";
            foreach(var r in profList)
            {
                command += String.Format(insertProf, r.Value, r.Key) + Environment.NewLine;
            }
            _sh.BeginTransaction();
            _sh.Execute(command);
            _sh.Commit();

        }

        void importWorkers(List<ImportWorker> workerList)
        {
            const string insertWorker = @"insert into Worker(ID, DeptID, StartWorkDate, FiredDate, Fam, Name, Otch, Pol, TabNumber) 
                                          values(@ID, @DeptID, @StartDate, @FiredDate, @Fam, @Name, @Otch, @Pol, @Tab)";
            const string updateWorker = @"update Worker 
                                          set DeptID = @DeptID
                                            , StartWorkDate = @StartDate
                                            , FiredDate = @FiredDate
                                            , Fam = @Fam
                                            , Name = @Name
                                            , Otch = @Otch
                                            , Pol = @Pol
                                            , TabNumber = @Tab
                                          where ID = @ID";

            if (workerList.Count == 0)
                return;

            _importedWorkersCount += workerList.Count;
            string command = "";
            foreach (var w in workerList)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("@DeptID", w.DeptID.ToString());
                param.Add("@StartDate", w.StartWorkDate);
                param.Add("@FiredDate", w.FiredDate);
                param.Add("@Fam", w.Fam);
                param.Add("@Name", w.Name);
                param.Add("@Otch", w.Otch);
                param.Add("@Pol", w.Pol);
                param.Add("@Tab", w.TabNumber);
                if (w.ID == Guid.Empty)
                {
                    w.ID = Guid.NewGuid();                    
                    command = insertWorker;
                }
                else
                {
                    command = updateWorker;
                }
                param.Add("@ID", w.ID.ToString());
                _sh.BeginTransaction();
                _sh.Execute(command, param);
                _sh.Commit();
            }
            command = "";
            const string insertWorkerProf = @"insert into WorkerLocalProf(ID, WorkerID, LocalProfID, IsMain)
                                              values('{0}', '{1}', '{2}', '{3}');";
            foreach (var w in workerList)
            {
                command += String.Format(insertWorkerProf, Guid.NewGuid(), w.ID, w.localProfID, 1) + Environment.NewLine;
            }
            _sh.BeginTransaction();
            _sh.Execute(command);
            _sh.Commit();
        }

        void deleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch
            {

            }

        }

        void sendEmailNotify()
        {
            MailSender ms = new MailSender();
            string body = ms.getTemplate(Application.StartupPath + mailTemplateName);
            body = body.Replace("%rep_date%", DateTime.Now.ToShortDateString());
            body = body.Replace("%files%", getFilesInfoHtml());
            body = body.Replace("%workers%", getBadWorkersHtml());
            string subject = String.Format("Результаты импорта АРМ ОТ ({0})", DateTime.Now.ToShortDateString());
            foreach (var mail in _sourceEvent.emailList)
            {
                ms.SendMessage(mail.email, subject, body);
            }
        }

        string getFilesInfoHtml()
        {
            const string row = @"<tr><td>{0}</td><td>{1}</td></tr>";
            const string table = @"<p><table border=""1"" cellspacing=""0""><tr><th>Файл</th><th>Количество работников для импорта</th></tr>{0}</table></p>";

            string res = "";
            foreach(var r in _fileInfo)
            {
                res += String.Format(row, r.Key, r.Value);
            }
            res = String.Format(table, res);
            return res;
        }

        string getBadWorkersHtml()
        {
            const string row = @"<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>";
            const string table = @"<p><table border=""1"" cellspacing=""0""><tr><th>Табельный номер</th><th>Фамилия</th><th>Ошибки</th></tr>{0}</table></p>";

            string res = "";
            foreach (var r in _fileInfo)
            {
                string localres = "";
                string fileres = "";
                var workers = _badWorkersList.Where(w => w.fileName == r.Key).ToList();
                if (workers.Count > 0)
                {
                    fileres = String.Format("<p><h5>{0}</h5></p>", r.Key) + Environment.NewLine;
                    foreach(var w in workers)
                    {
                        localres += String.Format(row, w.TabNumber, w.Fam, w.errors);
                    }

                }
                localres = String.Format(table, localres);
                res += fileres + Environment.NewLine + localres;
            }
            
            return res;
        }
    }
}
