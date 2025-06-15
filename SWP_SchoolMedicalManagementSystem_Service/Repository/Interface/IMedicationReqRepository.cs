
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IMedicationReqRepository
    {
        Task<IEnumerable<MedicationRequests>> GetAllMedicationRequests();
        Task<MedicationRequests?> GetMedicationRequestById(Guid medicalReqId);
        Task<IEnumerable<MedicationRequests>> GetMedicationRequestsByStudentId(Guid studentId);
        Task<IEnumerable<MedicationRequests>> GetMedicationRequestsByStatus(RequestStatus status);
        Task CreateMedicationRequest(MedicationRequests medicationReq);
        Task UpdateMedicationRequest(MedicationRequests medicationReq);
        Task DeleteMedicationRequest(Guid medicalReqId);
    }
}
