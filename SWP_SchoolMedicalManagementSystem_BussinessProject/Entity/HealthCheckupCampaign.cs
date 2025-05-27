using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public  class HealthCheckupCampaign : BaseEntity
    {
        public string? CampaignName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public HealthCampaignStatus Status { get; set; }
        public ICollection<User>? MedicalStaffs { get; set; } 
        public ICollection<StudentHealthCheckupSchedule>? Schedules { get; set; }
    }
}
