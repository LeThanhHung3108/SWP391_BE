using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class StudentHealthCheckupSchedule : BaseEntity
    {
        public Guid CampaignId { get; set; } 
        public HealthCheckupCampaign? HealthCheckupCampaign { get; set; }
        public Guid StudentId { get; set; } 
        public Student? Student { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public HealthScheduelStatus Status { get; set; } 
    }
}
