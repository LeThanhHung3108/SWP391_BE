using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request
{
    public class VaccScheduleRequest
    {
        public Guid? CampaignId { get; set; }
        public Guid? StudentId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public HealthScheduelStatus Status { get; set; }
    }
}
