using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccScheduleDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IVaccScheduleService
    {
        Task<List<VaccScheduleResponse>> GetAllVaccSchedulesAsync();
        Task<VaccScheduleResponse?> GetVaccScheduleByIdAsync(Guid vaccScheduleId);
        Task<List<VaccScheduleResponse>> GetVaccSchedulesByCampaignIdAsync(Guid vaccCampaignId);
        Task CreateVaccScheduleAsync(VaccScheduleRequest request);
        Task UpdateVaccScheduleAsync(Guid vaccScheduleId, VaccScheduleRequest request);
        Task DeleteVaccScheduleAsync(Guid vaccScheduleId);
    }
}
