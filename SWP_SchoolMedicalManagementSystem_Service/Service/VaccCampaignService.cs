using AutoMapper;
using Microsoft.AspNetCore.Http;
using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class VaccCampaignService : IVaccCampaignService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVaccCampaignRepository _vaccCampaignRepository;
        private readonly IMapper _mapper;

        public VaccCampaignService(IHttpContextAccessor httpContextAccessor, IVaccCampaignRepository vaccCampaignRepository, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _vaccCampaignRepository = vaccCampaignRepository;
            _mapper = mapper;

        }

        //1. Get all vaccination campaigns
        public async Task<IEnumerable<VaccCampaignResponse>> GetAllVaccCampaignsAsync()
        {
            var campaigns = await _vaccCampaignRepository.GetAllVaccCampaignsAsync();
            if (campaigns == null || !campaigns.Any())
                throw new KeyNotFoundException("No vaccination campaigns found.");
            return _mapper.Map<IEnumerable<VaccCampaignResponse>>(campaigns);
        }

        //2. Get vaccination campaign by ID
        public async Task<VaccCampaignResponse?> GetVaccCampaignByIdAsync(Guid vaccCampaignId)
        {
            var campaign = await _vaccCampaignRepository.GetVaccCampaignByIdAsync(vaccCampaignId);
            if (campaign == null)
                throw new KeyNotFoundException($"Vaccination campaign with ID {vaccCampaignId} not found.");
            return _mapper.Map<VaccCampaignResponse>(campaign);
        }

        //3. Get vaccination campaigns by status
        public async Task<IEnumerable<VaccCampaignResponse>> GetCampaignsByStatusAsync(VaccCampaignStatus vaccCampaigStatus)
        {
            var campaigns = await _vaccCampaignRepository.GetCampaignsByStatusAsync(vaccCampaigStatus);
            if (campaigns == null || !campaigns.Any())
                throw new KeyNotFoundException($"No vaccination campaigns found with status {vaccCampaigStatus}.");
            return _mapper.Map<IEnumerable<VaccCampaignResponse>>(campaigns);
        }

        //4. Create a new vaccination campaign
        public async Task CreateCampaignAsync(VaccCampaignRequest campaign)
        {
            try
            {
                var newCampaign = _mapper.Map<VaccinationCampaign>(campaign);
                newCampaign.CreatedBy = GetCurrentUsername();
                newCampaign.CreateAt = DateTime.UtcNow;
                await _vaccCampaignRepository.CreateCampaignAsync(newCampaign);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the vaccination campaign.", ex);
            }
        }

        //5. Update an existing vaccination campaign
        public async Task UpdateCampaignAsync(Guid vaccCampaignId, VaccCampaignRequest campaign)
        {
            var existingCampaign = await _vaccCampaignRepository.GetVaccCampaignByIdAsync(vaccCampaignId);
            if (existingCampaign == null)
                throw new KeyNotFoundException($"Vaccination campaign with ID {vaccCampaignId} not found.");

            existingCampaign.UpdatedBy = GetCurrentUsername();
            existingCampaign.UpdateAt = DateTime.UtcNow;
            _mapper.Map(campaign, existingCampaign);
            await _vaccCampaignRepository.UpdateCampaignAsync(existingCampaign);
        }

        //6. Delete a vaccination campaign
        public async Task DeleteCampaignAsync(Guid vaccCampaignId)
        {
            var existingCampaign = await _vaccCampaignRepository.GetVaccCampaignByIdAsync(vaccCampaignId);
            if (existingCampaign == null)
                throw new KeyNotFoundException($"Vaccination campaign with ID {vaccCampaignId} not found.");

            await _vaccCampaignRepository.DeleteCampaignAsync(vaccCampaignId);
        }

        //7. Get current username from HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }
    }
}