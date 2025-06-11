using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IVaccCampaignRepository
    {
        Task<IEnumerable<VaccinationCampaign>> GetAllVaccCampaignsAsync();
        Task<VaccinationCampaign?> GetVaccCampaignByIdAsync(Guid vaccCampaignId);
        Task<IEnumerable<VaccinationCampaign>> GetCampaignsByStatusAsync(VaccCampaignStatus vaccCampaigStatus);
        Task<IEnumerable<VaccinationCampaign>> GetActiveVaccCampaignsAsync();
        Task CreateCampaignAsync(VaccinationCampaign campaign);
        Task UpdateCampaignAsync(VaccinationCampaign campaign);
        Task DeleteCampaignAsync(Guid vaccCampaignId);
        Task<bool> AssignMedicalStaffAsync(Guid campaignId, Guid staffId);
        Task<bool> RemoveMedicalStaffAsync(Guid campaignId, Guid staffId);
        Task<IEnumerable<StudentVaccinationSchedule>> GetCampaignSchedulesAsync(Guid campaignId);
        Task<IEnumerable<VaccinationConsentForm>> GetCampaignConsentFormsAsync(Guid campaignId);
        Task<IEnumerable<VaccinationResults>> GetCampaignResultsAsync(Guid campaignId);
    }
}
