using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMShedulerApp
{
    public partial class EventEmail
    {
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
