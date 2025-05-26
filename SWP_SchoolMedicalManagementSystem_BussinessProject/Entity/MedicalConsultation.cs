using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalConsultation
    {
        public Guid Id { get; set; }
        public Guid ResultID { get; set; } 
        public Guid StudentID { get; set; } 
        public Guid ParentID { get; set; } 
        public Guid MedicalStaffID { get; set; } 
        public DateTime ScheduledDate { get; set; }
        public string? ConsultationNotes { get; set; }
        public string? Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
