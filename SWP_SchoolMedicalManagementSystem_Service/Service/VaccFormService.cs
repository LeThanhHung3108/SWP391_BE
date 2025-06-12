using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class VaccFormService : IVaccFormService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVaccFormRepository _vaccFormRepository;
        private readonly IMapper _mapper;

        public VaccFormService(
            IHttpContextAccessor httpContextAccessor,
            IVaccFormRepository vaccFormRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _vaccFormRepository = vaccFormRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VaccFormResponse>> GetAllVaccFormsAsync()
        {
            var vaccForms = await _vaccFormRepository.GetAllVaccFormsAsync();
            return _mapper.Map<IEnumerable<VaccFormResponse>>(vaccForms);
        }

        public async Task<VaccFormResponse> GetVaccFormByIdAsync(Guid vaccFormId)
        {
            var vaccForm = await _vaccFormRepository.GetVaccFormByIdAsync(vaccFormId);
            if (vaccForm == null)
                throw new KeyNotFoundException($"Vaccination consent form with ID {vaccFormId} not found.");
            return _mapper.Map<VaccFormResponse>(vaccForm);
        }

        public async Task<IEnumerable<VaccFormResponse>> GetVaccFormsByCampaignIdAsync(Guid vaccCampaignId)
        {
            var vaccForms = await _vaccFormRepository.GetVaccFormsByCampaignIdAsync(vaccCampaignId);
            return _mapper.Map<IEnumerable<VaccFormResponse>>(vaccForms);
        }

        public async Task<IEnumerable<VaccFormResponse>> GetVaccFormsByStudentIdAsync(Guid studentId)
        {
            var vaccForms = await _vaccFormRepository.GetVaccFormsByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<VaccFormResponse>>(vaccForms);
        }

        public async Task CreateVaccFormAsync(VaccFormRequest vaccForm)
        {
            var newVaccForm = _mapper.Map<VaccinationConsentForm>(vaccForm);
            newVaccForm.CreatedBy = GetCurrentUsername();
            newVaccForm.CreateAt = DateTime.UtcNow;
            await _vaccFormRepository.CreateVaccFormAsync(newVaccForm);
        }

        public async Task UpdateVaccFormAsync(Guid vaccFormId, VaccFormRequest vaccForm)
        {
            var existingVaccForm = await _vaccFormRepository.GetVaccFormByIdAsync(vaccFormId);
            if (existingVaccForm == null)
                throw new KeyNotFoundException($"Vaccination consent form with ID {vaccFormId} not found.");
            _mapper.Map(vaccForm, existingVaccForm);
            existingVaccForm.UpdatedBy = GetCurrentUsername();
            existingVaccForm.UpdateAt = DateTime.UtcNow;
            await _vaccFormRepository.UpdateVaccFormAsync(existingVaccForm);
        }

        public async Task DeleteVaccFormAsync(Guid vaccFormId)
        {
            var existingVaccForm = await _vaccFormRepository.GetVaccFormByIdAsync(vaccFormId);
            if (existingVaccForm == null)
                throw new KeyNotFoundException($"Vaccination consent form with ID {vaccFormId} not found.");
            await _vaccFormRepository.DeleteVaccFormAsync(vaccFormId);
        }

        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }
    }
}
