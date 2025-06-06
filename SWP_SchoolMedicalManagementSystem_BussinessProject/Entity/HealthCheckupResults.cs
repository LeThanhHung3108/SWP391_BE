﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class HealthCheckupResults:BaseEntity
    {
        public Guid ScheduleId { get; set; } 
        public StudentHealthCheckupSchedule? HealthCheckupSchedule { get; set; }
        public DateTime CheckupDate { get; set; }
        public float? Height { get; set; } 
        public float? Weight { get; set; } 
        public string? VisionLeftResult { get; set; }
        public string? VisionRightResult { get; set; }
        public string? HearingLeftResult { get; set; }
        public string? HearingRightResult { get; set; }
        public float? BloodPressureSys { get; set; } 
        public float? BloodPressureDia { get; set; } 
        public float? HeartRate { get; set; } 
        public string? DentalCheckupResult { get; set; }
        public string? OtherResults { get; set; }
        public string? AbnormalSigns { get; set; }
        public string? Recommendations { get; set; }
        public bool ParentResultNotified { get; set; }
        public DateTime? ParentResultNotificationDate { get; set; } 
    }
}
