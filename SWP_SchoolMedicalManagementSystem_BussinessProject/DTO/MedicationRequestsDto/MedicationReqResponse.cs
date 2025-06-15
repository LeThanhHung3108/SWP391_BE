using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Dto.UserDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.StudentDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.MedicationRequestsDto
{
    public class MedicationReqResponse
    {
        public Guid Id { get; set; }
        public string? MedicationName { get; set; }
        public int? Dosage { get; set; }
        public int? NumberOfDayToTake { get; set; }
        public string? Instructions { get; set; }
        public List<string>? ImagesMedicalInvoice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public RequestStatus Status { get; set; }
        public StudentResponse? Student { get; set; }  
        public UserResponseDto? MedicalStaff { get; set; }
    }
}
