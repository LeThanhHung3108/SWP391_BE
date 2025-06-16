
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IMedicationReqRepository
    {
        Task<List<MedicationRequests>> GetAllMedicationRequests();
        Task<MedicationRequests?> GetMedicationRequestById(Guid medicalReqId);
        Task<List<MedicationRequests>> GetMedicationRequestsByStudentId(Guid studentId);
        Task<List<MedicationRequests>> GetMedicationRequestsByStatus(RequestStatus status);
        Task CreateMedicationRequest(MedicationRequests medicationReq);
        Task UpdateMedicationRequest(MedicationRequests medicationReq);
        Task DeleteMedicationRequest(Guid medicalReqId);
    }
}
