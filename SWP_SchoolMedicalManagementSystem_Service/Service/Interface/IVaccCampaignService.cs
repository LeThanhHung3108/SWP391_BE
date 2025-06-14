using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccCampaignDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IVaccCampaignService
    {
        Task<IEnumerable<VaccCampaignResponse>> GetAllVaccCampaignsAsync();
        Task<VaccCampaignResponse?> GetVaccCampaignByIdAsync(Guid vaccCampaignId);
        Task<IEnumerable<VaccCampaignResponse>> GetCampaignsByStatusAsync(VaccCampaignStatus vaccCampaigStatus);
        Task CreateCampaignAsync(VaccCampaignRequest campaign);
        Task UpdateCampaignAsync(Guid vaccCampaignId, VaccCampaignRequest campaign);
        Task DeleteCampaignAsync(Guid vaccCampaignId);
    }
}
