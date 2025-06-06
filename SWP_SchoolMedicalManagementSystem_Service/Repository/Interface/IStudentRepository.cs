using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IStudentRepository
    {
        // Basic CRUD operations
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<bool> DeleteAsync(Guid id);

        // Specific student operations
        Task<IEnumerable<Student>> GetByParentIdAsync(Guid parentId);
        Task<IEnumerable<Student>> GetByClassAsync(string className);
        Task<IEnumerable<Student>> GetBySchoolYearAsync(string schoolYear);
        Task<Student?> GetByStudentCodeAsync(string studentCode);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsByStudentCodeAsync(string studentCode);
    }
}