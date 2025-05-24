using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalSupplyUsage
    {
        public int UsageID { get; set; }

        public int IncidentID { get; set; }

        public int SupplyID { get; set; }

        public int QuantityUsed { get; set; }

        public DateTime UsageDate { get; set; }

        public string Notes { get; set; }   

        public int UsedByStaffID { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
