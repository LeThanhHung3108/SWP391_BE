using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Implementation
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly ApplicationDBContext _context;

        public HealthRecordRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<HealthRecord?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.HealthRecords
                    .Include(hr => hr.Student) // Include related student data if needed
                    .FirstOrDefaultAsync(hr => hr.Id == id);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception($"Error retrieving health record with ID {id}", ex);
            }
        }

        public async Task<HealthRecord?> GetByStudentIdAsync(Guid studentId)
        {
            try
            {
                return await _context.HealthRecords
                    .Include(hr => hr.Student)
                    .FirstOrDefaultAsync(hr => hr.StudentId == studentId);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception($"Error retrieving health record for student ID {studentId}", ex);
            }
        }

        public async Task<IEnumerable<HealthRecord>> GetAllAsync()
        {
            try
            {
                return await _context.HealthRecords
                    .Include(hr => hr.Student)
                    .OrderBy(hr => hr.CreateAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception("Error retrieving all health records", ex);
            }
        }

        public async Task<HealthRecord> CreateAsync(HealthRecord healthRecord)
        {
            if (healthRecord == null)
                throw new ArgumentNullException(nameof(healthRecord));

            try
            {
                // Set creation timestamp if not already set
                if (healthRecord.CreateAt == default)
                    healthRecord.CreateAt = DateTime.UtcNow;

                // Generate new ID if not set
                if (healthRecord.Id == Guid.Empty)
                    healthRecord.Id = Guid.NewGuid();

                await _context.HealthRecords.AddAsync(healthRecord);
                await _context.SaveChangesAsync();

                return healthRecord;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception("Error creating health record", ex);
            }
        }

        public async Task<HealthRecord> UpdateAsync(HealthRecord healthRecord)
        {
            if (healthRecord == null)
                throw new ArgumentNullException(nameof(healthRecord));

            try
            {
                var existingRecord = await _context.HealthRecords.FindAsync(healthRecord.Id);
                if (existingRecord == null)
                    throw new InvalidOperationException($"Health record with ID {healthRecord.Id} not found");

                // Update properties
                _context.Entry(existingRecord).CurrentValues.SetValues(healthRecord);

                // Set update timestamp
                existingRecord.UpdateAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return existingRecord;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception($"Error updating health record with ID {healthRecord.Id}", ex);
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var healthRecord = await _context.HealthRecords.FindAsync(id);
                if (healthRecord == null)
                    return false;

                _context.HealthRecords.Remove(healthRecord);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception($"Error deleting health record with ID {id}", ex);
            }
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            try
            {
                return await _context.HealthRecords.AnyAsync(hr => hr.Id == id);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new Exception($"Error checking existence of health record with ID {id}", ex);
            }
        }
    }
}