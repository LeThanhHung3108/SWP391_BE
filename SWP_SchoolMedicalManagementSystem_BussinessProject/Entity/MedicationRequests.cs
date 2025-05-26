using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicationRequests : BaseEntity
    {       
        public Guid StudentID { get; set; }
        public Student? Student { get; set; }
        public Guid ParentID { get; set; }
        public User? Parent { get; set; }
        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
        public string? Instructions { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string? MedicalStaffNotes { get; set; }
        public string? Status { get;set; }
        public Guid MedicalStaffID { get; set; }
        public User MedicalStaff { get; set; }
    }
}
