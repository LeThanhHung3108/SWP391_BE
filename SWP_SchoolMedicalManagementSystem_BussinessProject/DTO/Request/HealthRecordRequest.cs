using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System.ComponentModel.DataAnnotations;

namespace SWP_SchoolMedicalManagementSystem_API.Models.Requests
{
    public class HealthRecordRequest
    {
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public string? Allergies { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? PastMedicalHistory { get; set; }
        public string? VisionLeft { get; set; }
        public string? VisionRight { get; set; }
        public string? HearingLeft { get; set; }
        public string? HearingRight { get; set; }
        public string? VaccinationHistory { get; set; }
        public string? OtherNotes { get; set; }
    }
}