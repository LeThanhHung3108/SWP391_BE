using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Service
{
    public interface IStudentService
    {
        // Basic CRUD operations
        Task<IEnumerable<StudentResponse>> GetAllStudentsAsync();
        Task<StudentResponse?> GetStudentByIdAsync(Guid id);
        Task<StudentResponse> CreateStudentAsync(StudentRequest request, string createdBy);
        Task<StudentResponse> UpdateStudentAsync(Guid id, StudentRequest request, string updatedBy);
        Task<bool> DeleteStudentAsync(Guid id);

        // Specific student operations
        Task<IEnumerable<StudentResponse>> GetStudentsByParentIdAsync(Guid parentId);
        Task<IEnumerable<StudentResponse>> GetStudentsByClassAsync(string className);
        Task<IEnumerable<StudentResponse>> GetStudentsBySchoolYearAsync(string schoolYear);
        Task<StudentResponse?> GetStudentByStudentCodeAsync(string studentCode);
        Task<bool> StudentExistsAsync(Guid id);
        Task<bool> StudentCodeExistsAsync(string studentCode);
    }
}