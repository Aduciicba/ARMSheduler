using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    public partial class Event 
    {
        List<EventEmail> _emailList = new List<EventEmail>();

        public List<EventEmail> emailList
        {
            get
            {
                return _emailList;
            }

            set
            {
                _emailList = value;
            }
        }

        
    }
}
