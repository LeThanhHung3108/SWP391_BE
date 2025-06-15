using SchoolMedicalManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccScheduleDto
{
    public class VaccScheduleResponse
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public HealthScheduelStatus Status { get; set; }
    }
}
