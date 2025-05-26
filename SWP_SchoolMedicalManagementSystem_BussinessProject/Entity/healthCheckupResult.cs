using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class HealthCheckupResult : BaseEntity
    {
        public Guid ScheduleID { get; set; } 
        public StudentHealthCheckupSchedule? HealthCheckupSchedule { get; set; }
        public DateTime CheckupDate { get; set; }
        public Guid MedicalStaffID { get; set; } 
        public User? MedicalStaf {  get; set; }
        public decimal? Height { get; set; } 
        public decimal? Weight { get; set; } 
        public string? VisionLeftResult { get; set; }
        public string? VisionRightResult { get; set; }
        public string? HearingLeftResult { get; set; }
        public string? HearingRightResult { get; set; }
        public int? BloodPressureSys { get; set; } 
        public int? BloodPressureDia { get; set; } 
        public int? HeartRate { get; set; } 
        public string? DentalCheckupResult { get; set; }
        public string? OtherResults { get; set; }
        public string? AbnormalSigns { get; set; }
        public string? Recommendations { get; set; }
        public bool ParentResultNotified { get; set; }
        public DateTime? ParentResultNotificationDate { get; set; } 
    }
}
