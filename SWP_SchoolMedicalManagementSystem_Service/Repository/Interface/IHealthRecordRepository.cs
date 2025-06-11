using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IHealthRecordRepository
    {
        Task<IEnumerable<HealthRecord>> GetAllHealthRecordAsync();
        Task<HealthRecord?> GetHealthRecordByIdAsync(Guid healthRecordId);
        Task<HealthRecord?> GetHealthRecordByStudentIdAsync(Guid studentId);
        Task CreateHealthRecordAsync(HealthRecord healthRecord);
        Task UpdateHealthRecordAsync(HealthRecord healthRecord);
        Task DeleteHealthRecordAsync(Guid HealthRecordId);
    }
}
    
