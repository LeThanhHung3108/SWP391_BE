using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalConsultation : BaseEntity
    {
        public Guid ResultID { get; set; } 
        public HealthCheckupResult? Result {  get; set; }
        public Guid StudentID { get; set; } 
        public Student? Student { get; set; }
        public Guid ParentID { get; set; } 
        public User? Parent { get; set; }
        public Guid MedicalStaffID { get; set; } 
        public User? MedicalStaff { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? ConsultationNotes { get; set; }
        public string? Status { get; set; } 
    }
}
