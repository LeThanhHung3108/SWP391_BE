using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(Guid studentId);
        Task<Student?> GetStudentByStudentCodeAsync(string studentCode);
        Task<IEnumerable<Student>> GetStudentsByParentIdAsync(Guid parentId);
        Task<IEnumerable<Student>> GetStudentsByClassAsync(string className);
        Task<IEnumerable<Student>> GetStudentsBySchoolYearAsync(string schoolYear);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid studentId);
    }
}