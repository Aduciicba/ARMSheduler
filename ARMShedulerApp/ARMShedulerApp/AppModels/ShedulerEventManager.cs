using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NLog;

namespace ARMSchedulerApp
{
    public delegate void startEventWork(finishEventWork fe);
    public delegate void finishEventWork(
                                          string state
                                        , string errMessage
                                        , Event  ev
                                        );
    public class SchedulerEventManager
    {

        List<SchedulerEvent> _eventList = new List<SchedulerEvent>();
        Thread _checkThread;
        bool _needRefreshEvents = false;
        refreshUI _refresh;

        MailSchedulerEvent _baseMailEvent;
        ImportSchedulerEvent _baseImportEvent;

        Logger logger = LogManager.GetCurrentClassLogger();

        public bool needRefreshEvents
        {
            get
            {
                return _needRefreshEvents;
            }
            set
            {
                _needRefreshEvents = value;
            }
        }

        public MailSchedulerEvent baseMailEvent
        {
            get
            {
                return _baseMailEvent;
            }
            set
            {
                _baseMailEvent = value;
            }
        }

        public ImportSchedulerEvent baseImportEvent
        {
            get
            {
                return _baseImportEvent;
            }
            set
            {
                _baseImportEvent = value;
            }
        }

        public SchedulerEventManager(refreshUI _rui)
        {
            _refresh = _rui;
            loadEvents();
        }

        void loadEvents()
        {
            _eventList.Clear();
            var events = CustomApplicationContext.db.Events.All();
            List<EventEmail> emailList = CustomApplicationContext.db.EventEmails.All().ToList<EventEmail>();
            foreach (var ev in events)
            {
                SchedulerEvent shEvent;
                Event evnt = ev;
                evnt.emailList = emailList.Where(x => x.fid_event == evnt.id_event).ToList();
                if (evnt.fid_event_type == 1)
                {
                    shEvent = new ImportSchedulerEvent(evnt);
                }
                else
                {
                    shEvent = new MailSchedulerEvent(evnt);
                }
                
                _eventList.Add(shEvent);
            }
            _baseMailEvent = (_eventList.First(e => e.sourceEvent.fid_event_type == 2) as MailSchedulerEvent);
            _baseImportEvent = (_eventList.First(e => e.sourceEvent.fid_event_type == 1) as ImportSchedulerEvent);
            logger.Info("Создан планировщик");
        }

        public void refreshEmails(int id_event)
        {
            List<EventEmail> emailList = CustomApplicationContext.db.EventEmails.FindAll(CustomApplicationContext.db.EventEmails.Fid_event == id_event).ToList<EventEmail>();
            _eventList.First(x => x.sourceEvent.id_event == id_event).sourceEvent.emailList = emailList;
        }

        public void startScheduler()
        {
            _checkThread = new Thread(checkEvents);
            _checkThread.Start();
            logger.Info("Запущен планировщик");
        }

        public void stopScheduler()
        {
            _checkThread.Abort();
            logger.Info("Остановлен планировщик");
        }

        void checkEvents()
        {
            if (needRefreshEvents)
            {
                loadEvents();
            }
            while (true)
            {
                foreach(SchedulerEvent she in _eventList)
                {
                    if (she.nextStartTime <= DateTime.Now)
                    {
                        startEventWork se = she.startEvent;
                        finishEventWork f = finishedEvent;
                        se.BeginInvoke(f, null, null);
                        logger.Info(String.Format("Запущено событие с типом {0}", she.sourceEvent.fid_event_type));
                    }
                }
                Thread.Sleep(60000);
            }
        }

        void finishedEvent(string state, string errMessage, Event e)
        {
            var el = CustomApplicationContext.db.EventLogs.Insert(
                                                                   Event_time: DateTime.Now
                                                                 , Fid_event: e.id_event
                                                                 , Event_state: state
                                                                 , Event_errors: errMessage
                                                                 );
            logger.Info(String.Format("Завершено событие с типом {0} результатом {1}", e.fid_event_type, state));
            _refresh();
        }

    }
}
