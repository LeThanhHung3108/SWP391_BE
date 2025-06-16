using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccFormDto;


namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IVaccFormService
    {
        Task<List<VaccFormResponse>> GetAllVaccFormsAsync();
        Task<VaccFormResponse> GetVaccFormByIdAsync(Guid vaccFormId);
        Task<List<VaccFormResponse>> GetVaccFormsByCampaignIdAsync(Guid vaccCampaignId);
        Task<List<VaccFormResponse>> GetVaccFormsByStudentIdAsync(Guid studentId);
        Task CreateVaccFormAsync(VaccFormRequest vaccForm);
        Task UpdateVaccFormAsync(Guid vaccFormId, VaccFormRequest vaccForm);
        Task DeleteVaccFormAsync(Guid vaccFormId);
    }
}
