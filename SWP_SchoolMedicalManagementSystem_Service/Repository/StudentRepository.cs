using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDBContext _context;

        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.HealthRecord)
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.HealthRecord)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            student.CreateAt = DateTime.UtcNow;
            student.UpdateAt = DateTime.UtcNow;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            var existingStudent = await _context.Students.FindAsync(student.Id);
            if (existingStudent == null)
                throw new KeyNotFoundException($"Student with ID {student.Id} not found.");

            existingStudent.StudentCode = student.StudentCode;
            existingStudent.FullName = student.FullName;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Gender = student.Gender;
            existingStudent.Class = student.Class;
            existingStudent.SchoolYear = student.SchoolYear;
            existingStudent.Image = student.Image;
            existingStudent.UpdateAt = DateTime.UtcNow;
            existingStudent.UpdatedBy = student.UpdatedBy;

            await _context.SaveChangesAsync();
            return existingStudent;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetByParentIdAsync(Guid parentId)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.HealthRecord)
                .Where(s => s.ParentId == parentId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetByClassAsync(string className)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.HealthRecord)
                .Where(s => s.Class == className)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetBySchoolYearAsync(string schoolYear)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.HealthRecord)
                .Where(s => s.SchoolYear == schoolYear)
                .ToListAsync();
        }

        public async Task<Student?> GetByStudentCodeAsync(string studentCode)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.HealthRecord)
                .FirstOrDefaultAsync(s => s.StudentCode == studentCode);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Students.AnyAsync(s => s.Id == id);
        }

        public async Task<bool> ExistsByStudentCodeAsync(string studentCode)
        {
            return await _context.Students.AnyAsync(s => s.StudentCode == studentCode);
        }
    }
}