using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    class ImportShedulerEvent:ShedulerEvent
    {
        public ImportShedulerEvent(Event _event)
        {
            _sourceEvent = _event;
            splitWeekDays();
            calcNextStartTime(DateTime.Now.Date);
        }
        public override void startEvent(finishEventWork fe)
        {
            string result = "Ошибка";
            string err = "Ошибка";
            fe(result, err, sourceEvent);
            calcNextStartTime(DateTime.Now.Date.AddDays(1));
        }
    }
}
