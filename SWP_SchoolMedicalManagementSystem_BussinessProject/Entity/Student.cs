using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Student : BaseEntity
    {
        public Guid ParentId { get; set; }
        public User? Parent {  get; set; }
        public HealthRecord? HealthRecord { get; set; }
        public string? StudentCode { get; set; }
        public string? FullName { get; set;} 
        public DateTime DateOfBirth { get; set;}
        public Gender Gender { get; set; }      
        public string? Class { get; set; } 
        public string? SchoolYear { get; set; } 
        public string? Image {  get; set; }
        public ICollection<StudentHealthCheckupSchedule>? HealthCheckupSchedules { get; set; }
        public ICollection<StudentVaccinationSchedule>? VaccinationSchedules { get; set; }
        public ICollection<MedicationRequests>? MedicationRequests { get; set; }
        public ICollection<HealthCheckupConsentForm>? CheckupConsentForms { get; set; }
        public ICollection<VaccinationConsentForm>? VaccinationConsentForms { get; set; }
        public ICollection<MedicalIncident>? MedicalIncidents { get; set; }
        public ICollection<MedicalConsultation>? MedicalConsultations { get; set; }
    }
}
