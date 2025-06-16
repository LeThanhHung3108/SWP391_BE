using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.StudentDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Service
{
    public class StudentService : IStudentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IHttpContextAccessor httpContextAccessor, IStudentRepository studentRepository, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        //1. Get all students
        public async Task<List<StudentResponse>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            if(students == null || !students.Any())
                throw new KeyNotFoundException("No students found.");
            return _mapper.Map<List<StudentResponse>>(students);
        }

        //2. Get student by ID
        public async Task<StudentResponse?> GetStudentByIdAsync(Guid studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if(student == null)
                throw new KeyNotFoundException($"Student with ID {studentId} not found.");
            return _mapper?.Map<StudentResponse>(student);
        }

        //3. Get student by student code
        public async Task<StudentResponse?> GetStudentByStudentCodeAsync(string studentCode)
        {
            if (string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Student code is required", nameof(studentCode));

            var student = await _studentRepository.GetStudentByStudentCodeAsync(studentCode.Trim());
            return _mapper.Map<StudentResponse>(student);
        }

        //4. Get students by parent ID
        public async Task<List<StudentResponse>> GetStudentsByParentIdAsync(Guid parentId)
        {
            var students = await _studentRepository.GetStudentsByParentIdAsync(parentId);
            if (students == null || !students.Any())
                throw new KeyNotFoundException($"No students found for parent ID {parentId}.");
            return _mapper.Map<List<StudentResponse>>(students);
        }

        //5. Get students by class
        public async Task<List<StudentResponse>> GetStudentsByClassAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Class name is required", nameof(className));

            var students = await _studentRepository.GetStudentsByClassAsync(className.Trim());
            if (students == null || !students.Any())
                throw new KeyNotFoundException($"No students found for class {className}.");
            return _mapper.Map<List<StudentResponse>>(students);
        }

        //6. Get students by school year
        public async Task<List<StudentResponse>> GetStudentsBySchoolYearAsync(string schoolYear)
        {
            if (string.IsNullOrWhiteSpace(schoolYear))
                throw new ArgumentException("School year is required", nameof(schoolYear));

            var students = await _studentRepository.GetStudentsBySchoolYearAsync(schoolYear.Trim());
            if (students == null || !students.Any())
                throw new KeyNotFoundException($"No students found for school year {schoolYear}.");
            return _mapper.Map<List<StudentResponse>>(students);
        }

        //7. Create student
        public async Task CreateStudentAsync(StudentRequest student)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(student.StudentCode))
                    throw new ArgumentException("Student code is required");
                if (string.IsNullOrWhiteSpace(student.FullName))
                    throw new ArgumentException("Full name is required");
                if (student.DateOfBirth == default)
                    throw new ArgumentException("Date of birth is required");
                if (string.IsNullOrWhiteSpace(student.Class))
                    throw new ArgumentException("Class is required");
                if (string.IsNullOrWhiteSpace(student.SchoolYear))
                    throw new ArgumentException("School year is required");

                // Check if student code already exists
                var existingStudent = await _studentRepository.GetStudentByStudentCodeAsync(student.StudentCode);
                if (existingStudent != null)
                    throw new InvalidOperationException($"Student with code {student.StudentCode} already exists");

                var newStudent = _mapper.Map<Student>(student);
                newStudent.Id = Guid.NewGuid(); // Ensure new ID is generated
                newStudent.CreatedBy = GetCurrentUsername();
                newStudent.CreateAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                newStudent.UpdateAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                // Ensure DateOfBirth is in UTC
                newStudent.DateOfBirth = DateTime.SpecifyKind(student.DateOfBirth.ToUniversalTime(), DateTimeKind.Utc);

                await _studentRepository.CreateStudentAsync(newStudent);
            }
            catch (DbUpdateException ex)
            {
                // Handle database-specific errors
                if (ex.InnerException != null)
                {
                    throw new Exception($"Database error: {ex.InnerException.Message}", ex);
                }
                throw new Exception("Error saving student to database", ex);
            }
            catch (Exception ex)
            {
                // Log the inner exception for more details
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw new Exception($"Error creating student: {ex.Message}", ex);
            }
        }

        //8. Update student
        public async Task UpdateStudentAsync(Guid studentId, StudentRequest student)
        {
            var existingStudent = await _studentRepository.GetStudentByIdAsync(studentId);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"Student with ID {studentId} not found.");
            }

            existingStudent.UpdatedBy = GetCurrentUsername();
            existingStudent.UpdateAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            _mapper.Map(student, existingStudent);
            // Ensure DateOfBirth is in UTC
            existingStudent.DateOfBirth = DateTime.SpecifyKind(student.DateOfBirth.ToUniversalTime(), DateTimeKind.Utc);
            await _studentRepository.UpdateStudentAsync(existingStudent);
        }

        //9. Delete student
        public async Task DeleteStudentAsync(Guid studentId)
        {
            //var userRole = GetUserRole();
            //if (!userRole.Equals("Parent"))
            //{
            //    throw new Exception("User is not a parent.");
            //}
            var existingStudent = await _studentRepository.GetStudentByIdAsync(studentId);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException($"Student with ID {studentId} not found.");
            }
            await _studentRepository.DeleteStudentAsync(studentId);
        }

        //10. Get current username from HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }

        private string GetUserRole()
        {
             return _httpContextAccessor.HttpContext?.User.FindFirst("role")?.Value ?? "Unknown Role";
        }
    }
}