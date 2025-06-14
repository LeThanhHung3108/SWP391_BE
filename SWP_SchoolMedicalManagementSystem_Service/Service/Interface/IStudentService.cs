using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.StudentDto;


namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Service
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponse>> GetAllStudentsAsync();
        Task<StudentResponse?> GetStudentByIdAsync(Guid studentId);
        Task<StudentResponse?> GetStudentByStudentCodeAsync(string studentCode);
        Task<IEnumerable<StudentResponse>> GetStudentsByParentIdAsync(Guid parentId);
        Task<IEnumerable<StudentResponse>> GetStudentsByClassAsync(string className);
        Task<IEnumerable<StudentResponse>> GetStudentsBySchoolYearAsync(string schoolYear);
        Task CreateStudentAsync(StudentRequest student);
        Task UpdateStudentAsync(Guid studentId, StudentRequest student);
        Task DeleteStudentAsync(Guid studentId);
    }
}