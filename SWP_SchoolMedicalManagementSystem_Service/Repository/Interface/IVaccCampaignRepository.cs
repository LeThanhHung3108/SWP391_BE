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
        Task CreateCampaignAsync(VaccinationCampaign campaign);
        Task UpdateCampaignAsync(VaccinationCampaign campaign);
        Task DeleteCampaignAsync(Guid vaccCampaignId);
    }
}
