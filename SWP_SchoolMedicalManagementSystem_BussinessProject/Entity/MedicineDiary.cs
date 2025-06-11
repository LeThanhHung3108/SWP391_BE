using SchoolMedicalManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicineDiary : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }   
        public DateTime Date { get; set; }
        public MedicationStatus? Status { get; set; }
        public string? Description { get; set; }
    }
}
