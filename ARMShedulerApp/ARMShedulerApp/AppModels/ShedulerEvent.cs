using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    abstract class ShedulerEvent
    {
        public DateTime nextStartTime;
        public Event sourceEvent;
        protected int[] eventWeekDays = new int[7];
        public abstract void startEvent(finishEventWork fe);
        protected void splitWeekDays()
        {
            int i = 0;
            foreach (char c in sourceEvent.start_week_days)
            {
                eventWeekDays[i] = Int32.Parse(c.ToString());
                i++;
            }
        }
        public void calcNextStartTime(DateTime startCalcDate)
        {
            DateTime nextDate = startCalcDate;

            int weekDay = (int)nextDate.DayOfWeek;
            while (eventWeekDays[weekDay] == 0)
            {
                nextDate = nextDate.AddDays(1);
                weekDay = (int)nextDate.DayOfWeek;
            }
            nextDate = nextDate + sourceEvent.start_time.TimeOfDay;
            nextStartTime = nextDate;
        }
    }
}
