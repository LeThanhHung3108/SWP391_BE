using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccScheduleDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IScheduleService
    {
        Task<List<ScheduleResponse>> GetAllSchedulesAsync();
        Task<ScheduleResponse?> GetScheduleByIdAsync(Guid scheduleId);
        Task<List<ScheduleResponse>> GetSchedulesByCampaignIdAsync(Guid campaignId);
        Task CreateScheduleAsync(ScheduleRequest schedule);
        Task UpdateScheduleAsync(Guid scheduleId, ScheduleRequest schedule);
        Task DeleteScheduleAsync(Guid scheduleId);
    }
}
