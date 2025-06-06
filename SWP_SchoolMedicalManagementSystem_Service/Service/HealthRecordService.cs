using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository _healthRecordRepository;
        private readonly IMapper _mapper;

        public HealthRecordService(IHealthRecordRepository healthRecordRepository, IMapper mapper)
        {
            _healthRecordRepository = healthRecordRepository ?? throw new ArgumentNullException(nameof(healthRecordRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<HealthRecord?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid ID", nameof(id));

            return await _healthRecordRepository.GetByIdAsync(id);
        }

        public async Task<HealthRecord?> GetByStudentIdAsync(Guid studentId)
        {
            if (studentId == Guid.Empty)
                throw new ArgumentException("Invalid student ID", nameof(studentId));

            return await _healthRecordRepository.GetByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<HealthRecord>> GetAllAsync()
        {
            return await _healthRecordRepository.GetAllAsync();
        }

        public async Task<HealthRecord> CreateAsync(HealthRecordRequest healthRecord)
        {
            if (healthRecord == null)
                throw new ArgumentNullException(nameof(healthRecord));

            if (healthRecord.StudentId == Guid.Empty)
                throw new ArgumentException("Student ID is required", nameof(healthRecord.StudentId));

            var entity = _mapper.Map<HealthRecord>(healthRecord);
            return await _healthRecordRepository.CreateAsync(entity);
        }

        public async Task<HealthRecord> UpdateAsync(HealthRecordRequest healthRecord)
        {
            if (healthRecord == null)
                throw new ArgumentNullException(nameof(healthRecord));

            if (healthRecord.StudentId == Guid.Empty)
                throw new ArgumentException("Student ID is required", nameof(healthRecord.StudentId));

            var existingRecord = await _healthRecordRepository.GetByStudentIdAsync(healthRecord.StudentId);
            if (existingRecord == null)
                throw new InvalidOperationException($"Health record for student ID {healthRecord.StudentId} not found");

            _mapper.Map(healthRecord, existingRecord);
            return await _healthRecordRepository.UpdateAsync(existingRecord);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid ID", nameof(id));

            return await _healthRecordRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid ID", nameof(id));

            return await _healthRecordRepository.ExistsAsync(id);
        }
    }
}
