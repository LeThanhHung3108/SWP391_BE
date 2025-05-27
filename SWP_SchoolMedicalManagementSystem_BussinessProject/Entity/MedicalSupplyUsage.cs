using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalSupplyUsage
    {
        public Guid IncidentId { get; set; }
        public MedicalIncident? Incident { get; set; }
        public Guid SupplyId { get; set; }
        public MedicalSupplier? MedicalSupply {  get; set; }
        public int QuantityUsed { get; set; }
        public DateTime UsageDate { get; set; }
        public string? Notes { get; set; }   
    }
}
