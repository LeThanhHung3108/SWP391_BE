using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicationRequests
    {
        public Guid Id {  get; set; }
        
        public Guid StudentID { get; set; }

        public Guid ParentID { get; set; }

        public string? MedicationName { get; set; }

        public string? Dosage { get; set; }

        public string? Instructions { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int Quantity { get; set; }

        public string? MedicalStaffNotes { get; set; }


        public string? Status { get;set; }

        public Guid StaffID { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }




    }
}
