using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_Repository.Repository.Interface
{
    public interface IVaccFormRepository
    {
        Task<List<VaccinationConsentForm>> GetAllVaccFormsAsync();
        Task<VaccinationConsentForm> GetVaccFormByIdAsync(Guid vaccFormId);
        Task<List<VaccinationConsentForm>> GetVaccFormsByCampaignIdAsync(Guid vaccCampaignId);
        Task<List<VaccinationConsentForm>> GetVaccFormsByStudentIdAsync(Guid studentId);
        Task CreateVaccFormAsync(VaccinationConsentForm vaccForm);
        Task UpdateVaccFormAsync(VaccinationConsentForm vaccForm);
        Task DeleteVaccFormAsync(Guid vaccFormId);
    }
}