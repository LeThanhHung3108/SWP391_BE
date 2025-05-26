using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public  class HealthCheckupCampaign : BaseEntity
    {
        public string? CampaignName { get; set; }
        public string? Description { get; set; }
        public string? CheckupItems { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid MedicalStaffID { get; set; }
        public User MedicalStaff { get; set; }
        public string? Status { get; set; }
    }
}
