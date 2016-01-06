using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    public partial class EventEmail
    {
        int _id_event_email;
        int _fid_event;
        string _email;

        public int id_event_email
        {
            get
            {
                return _id_event_email;
            }
            set
            {
                _id_event_email = value;
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

        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

    }
}
