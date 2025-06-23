using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccScheduleDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(
            IHttpContextAccessor httpContextAccessor,
            IScheduleRepository scheduleRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        //1. Get all schedules
        public async Task<List<ScheduleResponse>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllSchedulesAsync();
            if (schedules == null || !schedules.Any())
                throw new KeyNotFoundException("No schedules found.");
            return _mapper.Map<List<ScheduleResponse>>(schedules);
        }

        //2. Get schedule by ID
        public async Task<ScheduleResponse?> GetScheduleByIdAsync(Guid scheduleId)
        {
            var schedules = await _scheduleRepository.GetScheduleByIdAsync(scheduleId);
            if (schedules == null)
                throw new KeyNotFoundException($"Schedule with ID {scheduleId} not found.");
            return _mapper.Map<ScheduleResponse>(schedules);
        }

        //3. Get schedules by campaign ID
        public async Task<List<ScheduleResponse>> GetSchedulesByCampaignIdAsync(Guid campaignId)
        {
            var schedules = await _scheduleRepository.GetSchedulesByCampaignIdAsync(campaignId);
            if (schedules == null || !schedules.Any())
                throw new KeyNotFoundException($"No schedules found for campaign ID {campaignId}.");
            return _mapper.Map<List<ScheduleResponse>>(schedules);
        }

        //4. Create a new schedule
        public async Task CreateScheduleAsync(ScheduleRequest request)
        {
            try
            {
                var newSchedule = _mapper.Map<Schedule>(request);
                newSchedule.CreatedBy = GetCurrentUsername();
                newSchedule.CreateAt = DateTime.UtcNow;
                await _scheduleRepository.CreateScheduleAsync(newSchedule);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the schedule.", ex);
            }
        }

        //5. Update an existing schedule
        public async Task UpdateScheduleAsync(Guid scheduleId, ScheduleRequest request)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByIdAsync(scheduleId);
            if (existingSchedule == null)
                throw new KeyNotFoundException($"Schedule with ID {scheduleId} not found.");

            existingSchedule.UpdatedBy = GetCurrentUsername();
            existingSchedule.UpdateAt = DateTime.UtcNow;
            _mapper.Map(request, existingSchedule);
            await _scheduleRepository.UpdateScheduleAsync(existingSchedule);
        }

        //6. Delete a schedule
        public async Task DeleteScheduleAsync(Guid scheduleId)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByIdAsync(scheduleId);
            if (existingSchedule == null)
                throw new KeyNotFoundException($"Schedule with ID {scheduleId} not found.");

            await _scheduleRepository.DeleteScheduleAsync(scheduleId);
        }

        //7. Get current username from HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }
    }
}
