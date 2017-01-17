using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    public class ImportLocalProf
    {
        Guid _ID;
        Guid _DeptID;
        string _Name;


        public ImportLocalProf()
        {
        }

        public Guid ID
        {
            get
            {
                return _ID;
            }

            set
            {
                if (_ID != value)
                {
                    _ID = value;
                }
            }
        }

        public Guid DeptID
        {
            get
            {
                return _DeptID;
            }

            set
            {
                if (_DeptID != value)
                {
                    _DeptID = value;
                }
            }
        }


        
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                if (_Name != value)
                {
                    _Name = value;
                }
            }
        }
        

    }
}
