using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;


namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IVaccFormService
    {
        Task<IEnumerable<VaccFormResponse>> GetAllVaccFormsAsync();
        Task<VaccFormResponse> GetVaccFormByIdAsync(Guid vaccFormId);
        Task<IEnumerable<VaccFormResponse>> GetVaccFormsByCampaignIdAsync(Guid vaccCampaignId);
        Task<IEnumerable<VaccFormResponse>> GetVaccFormsByStudentIdAsync(Guid studentId);
        Task CreateVaccFormAsync(VaccFormRequest vaccForm);
        Task UpdateVaccFormAsync(Guid vaccFormId, VaccFormRequest vaccForm);
        Task DeleteVaccFormAsync(Guid vaccFormId);
    }
}
