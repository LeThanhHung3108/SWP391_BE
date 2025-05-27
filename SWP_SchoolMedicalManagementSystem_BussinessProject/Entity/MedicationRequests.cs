using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;
namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicationRequests : BaseEntity
    {       
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
        public string? Instructions { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public string? MedicalStaffNotes { get; set; }
        public RequestStatus Status { get;set; }
        public Guid MedicalStaffId { get; set; }
        public User? MedicalStaff { get; set; }
    }
}
