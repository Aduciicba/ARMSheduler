using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    public partial class Event
    {
        int _id_event;
        int _fid_event_type;
        string _start_week_days;
        DateTime _start_time;

        public int id_event
        {
            get
            {
                return _id_event;
            }
            set
            {
                _id_event = value;
            }
        }

        public int fid_event_type
        {
            get
            {
                return _fid_event_type;
            }
            set
            {
                _fid_event_type = value;
            }
        }

        public string start_week_days
        {
            get
            {
                return _start_week_days;
            }
            set
            {
                _start_week_days = value;
            }
        }

        public DateTime start_time
        {
            get
            {
                return _start_time;
            }
            set
            {
                _start_time = value;
            }
        }
    }
}
