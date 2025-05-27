using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalConsultation : BaseEntity
    {
        public Guid ResultId { get; set; } 
        public HealthCheckupResult? Result {  get; set; }
        public Guid StudentId { get; set; } 
        public Student? Student { get; set; }
        public Guid ParentId { get; set; } 
        public User? Parent { get; set; }
        public Guid MedicalStaffId { get; set; } 
        public User? MedicalStaff { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? ConsultationNotes { get; set; }
        public ConsultantStatus Status { get; set; } 
    }
}
