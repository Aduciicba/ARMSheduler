using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    class EventType
    {
        int _id_event_type;
        int _fid_event_type;
        string _name;

        public int id_event_type
        {
            get
            {
                return _id_event_type;
            }
            set
            {
                _id_event_type = value;
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

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
