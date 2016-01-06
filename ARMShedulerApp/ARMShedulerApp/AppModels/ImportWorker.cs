using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    public class ImportWorker
    {
        Guid _ID;
        Guid _DeptID;
        DateTime? _StartWorkDate;
        DateTime? _FiredDate;
        string _Fam;
        string _Name;
        string _Otch;
        int? _Pol;
        string _TabNumber;
        Guid _localProfID;

        string _fileName;
        string _errors;

        public ImportWorker()
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

        
        public DateTime? StartWorkDate
        {
            get
            {
                return _StartWorkDate;
            }

            set
            {
                if (_StartWorkDate != value)
                {
                    _StartWorkDate = value;
                }
            }
        }
        public DateTime? FiredDate
        {
            get
            {
                return _FiredDate;
            }

            set
            {
                if (_FiredDate != value)
                {
                    _FiredDate = value;
                }
            }
        }

        public string Fam
        {
            get
            {
                return _Fam;
            }

            set
            {
                if (_Fam != value)
                {
                    _Fam = value;
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
        public string Otch
        {
            get
            {
                return _Otch;
            }

            set
            {
                if (_Otch != value)
                {
                    _Otch = value;
                }
            }
        }

        public int? Pol
        {
            get
            {
                return _Pol;
            }

            set
            {
                if (_Pol != value)
                {
                    _Pol = value;
                }
            }
        }

        public string TabNumber
        {
            get
            {
                return _TabNumber;
            }

            set
            {
                if (_TabNumber != value)
                {
                    _TabNumber = value;
                }
            }
        }

        public Guid localProfID
        {
            get
            {
                return _localProfID;
            }

            set
            {
                if (_localProfID != value)
                {
                    _localProfID = value;
                }
            }
        }

        public string fileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                }
            }
        }

        public string errors
        {
            get
            {
                return _errors;
            }

            set
            {
                if (_errors != value)
                {
                    _errors = value;
                }
            }
        }

    }
}
