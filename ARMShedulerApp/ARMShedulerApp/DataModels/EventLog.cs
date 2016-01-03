using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    public partial class EventLog
    {
        int _id_event_log;
        DateTime _event_time;
        int _fid_event;
        string _event_state;
        string _event_errors;

        public int id_event_log
        {
            get
            {
                return _id_event_log;
            }
            set
            {
                _id_event_log = value;
            }
        }

        public DateTime event_time
        {
            get
            {
                return _event_time;
            }
            set
            {
                _event_time = value;
            }
        }

        public int fid_event
        {
            get
            {
                return _fid_event;
            }
            set
            {
                _fid_event = value;
            }
        }

        public string event_state
        {
            get
            {
                return _event_state;
            }
            set
            {
                _event_state = value;
            }
        }

        public string event_errors
        {
            get
            {
                return _event_errors;
            }
            set
            {
                _event_errors = value;
            }
        }

    }
}
