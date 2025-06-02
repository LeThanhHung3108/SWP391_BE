using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
         
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(MapToResponse);
        }

        public async Task<StudentResponse?> GetStudentByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid student ID", nameof(id));

            var student = await _studentRepository.GetByIdAsync(id);
            return student != null ? MapToResponse(student) : null;
        }

        public async Task<StudentResponse> CreateStudentAsync(StudentRequest request, string createdBy)
        {
            ValidateStudentRequest(request);
            ValidateAuditUser(createdBy, "createdBy");

            if (string.IsNullOrWhiteSpace(request.StudentCode))
                throw new ArgumentException("Student code is required", nameof(request.StudentCode));

            if (await _studentRepository.ExistsByStudentCodeAsync(request.StudentCode))
                throw new InvalidOperationException($"Student with code {request.StudentCode} already exists.");

            var student = new Student
            {
                ParentId = request.ParentId,
                StudentCode = request.StudentCode.Trim(),
                FullName = request.FullName?.Trim(),
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Class = request.Class?.Trim(),
                SchoolYear = request.SchoolYear?.Trim(),
                Image = request.Image?.Trim(),
                CreatedBy = createdBy,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var createdStudent = await _studentRepository.CreateAsync(student);
            return MapToResponse(createdStudent);
        }

        public async Task<StudentResponse> UpdateStudentAsync(Guid id, StudentRequest request, string updatedBy)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid student ID", nameof(id));

            ValidateStudentRequest(request);
            ValidateAuditUser(updatedBy, "updatedBy");

            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
                throw new KeyNotFoundException($"Student with ID {id} not found.");

            if (string.IsNullOrWhiteSpace(request.StudentCode))
                throw new ArgumentException("Student code is required", nameof(request.StudentCode));

            if (request.StudentCode != existingStudent.StudentCode &&
                await _studentRepository.ExistsByStudentCodeAsync(request.StudentCode))
                throw new InvalidOperationException($"Student with code {request.StudentCode} already exists.");

            existingStudent.StudentCode = request.StudentCode.Trim();
            existingStudent.FullName = request.FullName?.Trim();
            existingStudent.DateOfBirth = request.DateOfBirth;
            existingStudent.Gender = request.Gender;
            existingStudent.Class = request.Class?.Trim();
            existingStudent.SchoolYear = request.SchoolYear?.Trim();
            existingStudent.Image = request.Image?.Trim();
            existingStudent.UpdatedBy = updatedBy;
            existingStudent.UpdateAt = DateTime.UtcNow;

            var updatedStudent = await _studentRepository.UpdateAsync(existingStudent);
            return MapToResponse(updatedStudent);
        }

        public async Task<bool> DeleteStudentAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid student ID", nameof(id));

            return await _studentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentResponse>> GetStudentsByParentIdAsync(Guid parentId)
        {
            if (parentId == Guid.Empty)
                throw new ArgumentException("Invalid parent ID", nameof(parentId));

            var students = await _studentRepository.GetByParentIdAsync(parentId);
            return students.Select(MapToResponse);
        }

        public async Task<IEnumerable<StudentResponse>> GetStudentsByClassAsync(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Class name is required", nameof(className));

            var students = await _studentRepository.GetByClassAsync(className.Trim());
            return students.Select(MapToResponse);
        }

        public async Task<IEnumerable<StudentResponse>> GetStudentsBySchoolYearAsync(string schoolYear)
        {
            if (string.IsNullOrWhiteSpace(schoolYear))
                throw new ArgumentException("School year is required", nameof(schoolYear));

            var students = await _studentRepository.GetBySchoolYearAsync(schoolYear.Trim());
            return students.Select(MapToResponse);
        }

        public async Task<StudentResponse?> GetStudentByStudentCodeAsync(string studentCode)
        {
            if (string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Student code is required", nameof(studentCode));

            var student = await _studentRepository.GetByStudentCodeAsync(studentCode.Trim());
            return student != null ? MapToResponse(student) : null;
        }

        public async Task<bool> StudentExistsAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid student ID", nameof(id));

            return await _studentRepository.ExistsAsync(id);
        }

        public async Task<bool> StudentCodeExistsAsync(string studentCode)
        {
            if (string.IsNullOrWhiteSpace(studentCode))
                throw new ArgumentException("Student code is required", nameof(studentCode));

            return await _studentRepository.ExistsByStudentCodeAsync(studentCode.Trim());
        }

        private static StudentResponse MapToResponse(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            return new StudentResponse
            {
                Id = student.Id,
                ParentId = student.ParentId,
                StudentCode = student.StudentCode,
                FullName = student.FullName,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Class = student.Class,
                SchoolYear = student.SchoolYear,
                Image = student.Image,
                CreateAt = student.CreateAt,
                UpdateAt = student.UpdateAt,
                CreatedBy = student.CreatedBy,
                UpdatedBy = student.UpdatedBy
            };
        }

        private static void ValidateStudentRequest(StudentRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.ParentId == Guid.Empty)
                throw new ArgumentException("Parent ID is required", nameof(request.ParentId));

            if (string.IsNullOrWhiteSpace(request.FullName))
                throw new ArgumentException("Full name is required", nameof(request.FullName));

            if (request.DateOfBirth == default)
                throw new ArgumentException("Date of birth is required", nameof(request.DateOfBirth));

            if (request.DateOfBirth > DateTime.UtcNow)
                throw new ArgumentException("Date of birth cannot be in the future", nameof(request.DateOfBirth));
        }

        private static void ValidateAuditUser(string user, string paramName)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("User information is required", paramName);
        }
    }
}