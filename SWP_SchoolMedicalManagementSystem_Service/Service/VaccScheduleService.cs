using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class VaccScheduleService : IVaccScheduleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVaccScheduleRepository _vaccScheduleRepository;
        private readonly IMapper _mapper;

        public VaccScheduleService(
            IHttpContextAccessor httpContextAccessor,
            IVaccScheduleRepository vaccScheduleRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _vaccScheduleRepository = vaccScheduleRepository;
            _mapper = mapper;
        }

        //1. Get all vaccination schedules
        public async Task<IEnumerable<VaccScheduleResponse>> GetAllVaccSchedulesAsync()
        {
            var vaccSchedules = await _vaccScheduleRepository.GetAllVaccSchedulesAsync();
            if (vaccSchedules == null || !vaccSchedules.Any())
                throw new KeyNotFoundException("No vaccination schedules found.");
            return _mapper.Map<IEnumerable<VaccScheduleResponse>>(vaccSchedules);
        }

        //2. Get vaccination schedule by ID
        public async Task<VaccScheduleResponse?> GetVaccScheduleByIdAsync(Guid vaccScheduleId)
        {
            var vaccSchedules = await _vaccScheduleRepository.GetVaccScheduleByIdAsync(vaccScheduleId);
            if (vaccSchedules == null)
                throw new KeyNotFoundException($"Vaccination schedule with ID {vaccScheduleId} not found.");
            return _mapper.Map<VaccScheduleResponse>(vaccSchedules);
        }

        //3. Get vaccination schedules by campaign ID
        public async Task<IEnumerable<VaccScheduleResponse>> GetVaccSchedulesByCampaignIdAsync(Guid vaccCampaignId)
        {
            var vaccSchedules = await _vaccScheduleRepository.GetVaccSchedulesByCampaignIdAsync(vaccCampaignId);
            if (vaccSchedules == null || !vaccSchedules.Any())
                throw new KeyNotFoundException($"No vaccination schedules found for campaign ID {vaccCampaignId}.");
            return _mapper.Map<IEnumerable<VaccScheduleResponse>>(vaccSchedules);
        }

        //4. Create a new vaccination schedule
        public async Task CreateVaccScheduleAsync(VaccScheduleRequest request)
        {
            try
            {
                var newvaccSchedule = _mapper.Map<StudentVaccinationSchedule>(request);
                newvaccSchedule.CreatedBy = GetCurrentUsername();
                newvaccSchedule.CreateAt = DateTime.UtcNow;
                await _vaccScheduleRepository.CreateVaccScheduleAsync(newvaccSchedule);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the vaccination schedule.", ex);
            }
        }

        //5. Update an existing vaccination schedule
        public async Task UpdateVaccScheduleAsync(Guid vaccScheduleId, VaccScheduleRequest request)
        {
            var existingSchedule = await _vaccScheduleRepository.GetVaccScheduleByIdAsync(vaccScheduleId);
            if (existingSchedule == null)
                throw new KeyNotFoundException($"Vaccination schedule with ID {vaccScheduleId} not found.");

            existingSchedule.UpdatedBy = GetCurrentUsername();
            existingSchedule.UpdateAt = DateTime.UtcNow;
            _mapper.Map(request, existingSchedule);
            await _vaccScheduleRepository.UpdateVaccScheduleAsync(existingSchedule);
        }

        //6. Delete a vaccination schedule
        public async Task DeleteVaccScheduleAsync(Guid vaccScheduleId)
        {
            var existingSchedule = await _vaccScheduleRepository.GetVaccScheduleByIdAsync(vaccScheduleId);
            if (existingSchedule == null)
                throw new KeyNotFoundException($"Vaccination schedule with ID {vaccScheduleId} not found.");

            await _vaccScheduleRepository.DeleteVaccScheduleAsync(vaccScheduleId);
        }

        //7. Get current username from HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }
    }
}
