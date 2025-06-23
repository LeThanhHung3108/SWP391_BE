using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.StudentDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.ScheduleDetailDto
{
    public class ScheduleDetailResponse
    {
        public StudentResponse? Student { get; set; }
        public VaccinationResult? VaccinationResult { get; set; }
        public HealthCheckupResult? HealthCheckupResult { get; set; }
        public DateTime VaccinationDate { get; set; }
    }
}
