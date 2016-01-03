﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ARMShedulerApp
{
    public delegate void startEventWork(finishEventWork fe);
    public delegate void finishEventWork(
                                          string state
                                        , string errMessage
                                        , Event  ev
                                        );
    class ShedulerEventManager
    {

        List<ShedulerEvent> _eventList = new List<ShedulerEvent>();
        Thread _checkThread;
        bool _needRefreshEvents = false;
        refreshUI _refresh;

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

        public ShedulerEventManager(refreshUI _rui)
        {
            _refresh = _rui;
            loadEvents();
        }

        void loadEvents()
        {
            _eventList.Clear();
            var events = CustomApplicationContext.db.Events.All(/*CustomApplicationContext.db.Events.Is_active = 1*/);
            foreach (var ev in events)
            {
                ShedulerEvent shEvent;
                Event evnt = ev;
                if (evnt.fid_event_type == 1)
                {
                    shEvent = new ImportShedulerEvent(evnt);
                }
                else
                {
                    shEvent = new MailShedulerEvent(evnt);
                }
                _eventList.Add(shEvent);
            }
            
        }

        public void startScheduler()
        {
            _checkThread = new Thread(checkEvents);
            _checkThread.Start();
        }

        public void stopScheduler()
        {
            _checkThread.Abort();
        }

        void checkEvents()
        {
            if (needRefreshEvents)
            {
                loadEvents();
            }
            while (true)
            {
                foreach(ShedulerEvent she in _eventList)
                {
                    if (she.nextStartTime <= DateTime.Now)
                    {
                        startEventWork se = she.startEvent;
                        finishEventWork f = finishedEvent;
                        se.BeginInvoke(f, null, null);
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
            _refresh();
        }

    }
}