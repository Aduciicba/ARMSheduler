using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ARMSchedulerApp
{
    public abstract class SchedulerEvent : INotifyPropertyChanged
    {
        protected bool _hasUnsavedChanges;
        protected DateTime _nextStartTime;
        protected Event _sourceEvent;
        protected int[] _eventWeekDays = new int[7];
        public abstract void startEvent(finishEventWork fe);

        public DateTime nextStartTime
        {
            get
            {
                return _nextStartTime;
            }
        }

        public Event sourceEvent
        {
            get
            {
                return _sourceEvent;
            }
        }

        public bool hasUnsavedChanges
        {
            get
            {
                return _hasUnsavedChanges;
            }
        }
        public int eventWeekDays
        {
            get
            {
                return Convert.ToInt32(sourceEvent.start_week_days, 2);
            }
            set
            {
                string weekdays = Convert.ToString(value, 2);
                weekdays = "0000000".Substring(1, 7 - weekdays.Length) + weekdays;
                sourceEvent.start_week_days = weekdays;
                splitWeekDays();
                DateTime dt;
                if ((DateTime.Now.Date + _sourceEvent.start_time.TimeOfDay) > DateTime.Now)
                    dt = DateTime.Now.Date;
                else
                    dt = DateTime.Now.Date.AddDays(1);
                calcNextStartTime(dt);
                _hasUnsavedChanges = true;
            }
        }

        public DevExpress.XtraScheduler.WeekDays eventWeekDaysXtra
        {
            get
            {
                return (DevExpress.XtraScheduler.WeekDays)Convert.ToInt32(sourceEvent.start_week_days, 2);
            }
            set
            {
                string weekdays = Convert.ToString((int)value, 2);
                weekdays = "0000000".Substring(1, 7 - weekdays.Length) + weekdays;
                sourceEvent.start_week_days = weekdays;
                splitWeekDays();
                DateTime dt;
                if ((DateTime.Now.Date +_sourceEvent.start_time.TimeOfDay) > DateTime.Now)
                    dt = DateTime.Now.Date;
                else
                    dt = DateTime.Now.Date.AddDays(1);
                calcNextStartTime(dt);
                _hasUnsavedChanges = true;
            }
        }

        public List<EventEmail> emailList
        {
            get
            {
                return _sourceEvent.emailList;
            }
            set
            {
                _sourceEvent.emailList = value;
                OnPropertyChanged("emailList");
            }
        }

        public DateTime eventTime
        {
            get
            {
                return sourceEvent.start_time;
            }

            set
            {
                sourceEvent.start_time = value;
                DateTime dt;
                if ((DateTime.Now.Date + _sourceEvent.start_time.TimeOfDay) > DateTime.Now)
                    dt = DateTime.Now.Date;
                else
                    dt = DateTime.Now.Date.AddDays(1);
                calcNextStartTime(dt);
                _hasUnsavedChanges = true;
            }
        }

        public void calcNextStartTime(DateTime startCalcDate)
        {
            if (_eventWeekDays.Count(x => x == 1) == 0)
            {
                _nextStartTime = DateTime.Now.AddDays(1000);
                return;
            }

            DateTime nextDate = startCalcDate;

            int weekDay = (int)nextDate.DayOfWeek;
            while (_eventWeekDays[weekDay] == 0)
            {
                nextDate = nextDate.AddDays(1);
                weekDay = (int)nextDate.DayOfWeek;
            }
            nextDate = nextDate + sourceEvent.start_time.TimeOfDay;
            _nextStartTime = nextDate;
        }

        protected void splitWeekDays()
        {
            int i = 6;
            foreach (char c in sourceEvent.start_week_days)
            {
                _eventWeekDays[i] = Int32.Parse(c.ToString());
                i--;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Insert, Update, Delete

        public void Save()
        {
            if (hasUnsavedChanges)
            {
                CustomApplicationContext.db.Events.Update(sourceEvent);
                _hasUnsavedChanges = false;
            }
        }

        #endregion

    }
}
