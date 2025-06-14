using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.MedicationRequestsDto;

namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IMedicalRequestService
    {
        Task<IEnumerable<MedicationReqResponse>> GetAllMedicationRequests();
        Task<MedicationReqResponse?> GetMedicationRequestById(Guid medicalReqId);
        Task<IEnumerable<MedicationReqResponse>> GetMedicationRequestsByStudentId(Guid studentId);
        Task<IEnumerable<MedicationReqResponse>> GetMedicationRequestsByStatus(RequestStatus status);
        Task CreateMedicationRequest(MedicationReqRequest request);
        Task UpdateMedicationRequest(Guid medicalReqId, MedicationReqRequest request);
        Task DeleteMedicationRequest(Guid medicalReqId);
    }
} 