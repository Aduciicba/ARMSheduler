using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARMSchedulerApp
{
    public class ImportWorker
    {
        public Guid ID { get; set; }
        public Guid DeptID { get; set; }
        public DateTime? StartWorkDate { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Fam { get; set; }
        public string Name { get; set; }
        public string Otch { get; set; }
        public int? Pol { get; set; }
        public string TabNumber { get; set; }
        public Guid LocalProfID { get; set; }
        public string SNILS { get; set; }
        public Guid? UtClassID { get; set; }

        public string FileName;
        public string Errors;

        public ImportWorker()
        {
        }

    }
}
