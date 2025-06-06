using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IHealthRecordService
    {
        Task<HealthRecord?> GetByIdAsync(Guid id);
        Task<HealthRecord?> GetByStudentIdAsync(Guid studentId);
        Task<IEnumerable<HealthRecord>> GetAllAsync();
        Task<HealthRecord> CreateAsync(HealthRecordRequest healthRecord);
        Task<HealthRecord> UpdateAsync(HealthRecordRequest healthRecord);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
    }
}
