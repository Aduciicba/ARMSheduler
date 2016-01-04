using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    class MailShedulerEvent: ShedulerEvent
    {       

        public MailShedulerEvent(Event _event)
        {
            _sourceEvent = _event;
            splitWeekDays();
            calcNextStartTime(DateTime.Now.Date);
        }

        public override void startEvent(finishEventWork fe)
        {
            string result = "Выполнено";
            string err = "";
            fe(result, err, sourceEvent);
            calcNextStartTime(DateTime.Now.Date.AddDays(1));
        }

    }
}
