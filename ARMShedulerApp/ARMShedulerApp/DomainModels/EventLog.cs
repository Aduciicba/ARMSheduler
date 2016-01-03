using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    public partial class EventLog
    {
        string _event_type_name;

        public string event_type_name
        {
            get
            {
                return _event_type_name;
            }
            set
            {
                _event_type_name = value;
            }
        }

        Event _self_event;

        public Event self_event
        {
            get
            {
                return _self_event;
            }
            set
            {
                _self_event = value;
            }
        }
    }

}
