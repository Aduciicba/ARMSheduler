using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    class DbVersion
    {
        int _version;
        int _build;
        DateTime _last_update_time;

        public int version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }

        public int build
        {
            get
            {
                return _build;
            }
            set
            {
                _build = value;
            }
        }

        public DateTime last_update_time
        {
            get
            {
                return _last_update_time;
            }
            set
            {
                _last_update_time = value;
            }
        }
    }
}
