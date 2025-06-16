
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface
{
    public interface IVaccScheduleRepository
    {
        Task<List<StudentVaccinationSchedule>> GetAllVaccSchedulesAsync();
        Task<StudentVaccinationSchedule> GetVaccScheduleByIdAsync(Guid vaccScheduleId);
        Task<List<StudentVaccinationSchedule>> GetVaccSchedulesByCampaignIdAsync(Guid vaccCampaignId);
        Task CreateVaccScheduleAsync(StudentVaccinationSchedule vaccSchedule);
        Task UpdateVaccScheduleAsync(StudentVaccinationSchedule vaccSchedule);
        Task DeleteVaccScheduleAsync(Guid vaccScheduleId);
    }
}