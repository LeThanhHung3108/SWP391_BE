using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalConsultation
    {
        public int ConsultationID { get; set; }
        public int? ResultID { get; set; } 
        public int StudentID { get; set; } 
        public int ParentID { get; set; } 
        public int MedicalStaffID { get; set; } 
        public DateTime ScheduledDate { get; set; }
        public string ConsultationNotes { get; set; }
        public string Status { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
