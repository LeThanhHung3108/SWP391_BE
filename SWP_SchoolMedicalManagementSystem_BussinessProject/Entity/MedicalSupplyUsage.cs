using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalSupplyUsage : BaseEntity
    {
        public Guid IncidentID { get; set; }
        public MedicalIncident? Incident { get; set; }
        public Guid SupplyID { get; set; }
        public MedicalSupplier? MedicalSupply {  get; set; }
        public int QuantityUsed { get; set; }
        public DateTime UsageDate { get; set; }
        public string? Notes { get; set; }   
        public Guid UsedByStaffID { get; set; }
        public User? MedicalStaff { get; set; }
    }
}
