using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;
using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.MedicationRequestsDto;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class MedicalRequestService : IMedicalRequestService
    {
        private readonly IMedicationReqRepository _medicationReqRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MedicalRequestService(
            IMedicationReqRepository medicationReqRepository,
            IStudentRepository studentRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _medicationReqRepository = medicationReqRepository;  
            _studentRepository = studentRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        

        //1. Get all medication requests
        public async Task<IEnumerable<MedicationReqResponse>> GetAllMedicationRequests()
        {
            var medicationRequests = await _medicationReqRepository.GetAllMedicationRequests();
            if (medicationRequests == null || !medicationRequests.Any())
                throw new KeyNotFoundException("No medication requests found.");
            return _mapper.Map<IEnumerable<MedicationReqResponse>>(medicationRequests);
        }

        //2. Get medication request by ID
        public async Task<MedicationReqResponse?> GetMedicationRequestById(Guid medicalReqId)
        {
            var medicationRequest = await _medicationReqRepository.GetMedicationRequestById(medicalReqId);
            if (medicationRequest == null)
                throw new KeyNotFoundException($"Medication request with ID {medicalReqId} not found.");
            return _mapper.Map<MedicationReqResponse>(medicationRequest);
        }

        //3. Get medication requests by Student ID
        public async Task<IEnumerable<MedicationReqResponse>> GetMedicationRequestsByStudentId(Guid studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
                throw new KeyNotFoundException($"Student with ID {studentId} not found.");

            var medicationRequests = await _medicationReqRepository.GetMedicationRequestsByStudentId(studentId);
            if (medicationRequests == null || !medicationRequests.Any())
                throw new KeyNotFoundException($"No medication requests found for student ID {studentId}.");
            return _mapper.Map<IEnumerable<MedicationReqResponse>>(medicationRequests);
        }

        //4. Get medication requests by status
        public async Task<IEnumerable<MedicationReqResponse>> GetMedicationRequestsByStatus(RequestStatus status)
        {
            var medicationRequests = await _medicationReqRepository.GetMedicationRequestsByStatus(status);
            if (medicationRequests == null || !medicationRequests.Any())
                throw new KeyNotFoundException($"No medication requests found with status {status}.");
            return _mapper.Map<IEnumerable<MedicationReqResponse>>(medicationRequests);
        }

        //5. Create a new medication request
        public async Task CreateMedicationRequest(MedicationReqRequest request)
        {
            var student = await _studentRepository.GetStudentByIdAsync(request.StudentId);
            if (student == null)
                throw new KeyNotFoundException($"Student with ID {request.StudentId} not found.");
            try
            {
                var medicationRequest = _mapper.Map<MedicationRequests>(request);
                medicationRequest.Status = RequestStatus.Pending;
                medicationRequest.CreatedBy = GetCurrentUsername();
                medicationRequest.CreateAt = DateTime.UtcNow;

                await _medicationReqRepository.CreateMedicationRequest(medicationRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating medication request", ex);
            }
        }
        //6. Update an existing medication request
        public async Task UpdateMedicationRequest(Guid medicalReqId, MedicationReqRequest request)
        {
            var existingRequest = await _medicationReqRepository.GetMedicationRequestById(medicalReqId);
            if (existingRequest == null)
                throw new KeyNotFoundException($"Medication request with ID {medicalReqId} not found.");

            var student = await _studentRepository.GetStudentByIdAsync(request.StudentId);
            if (student == null)
                throw new KeyNotFoundException($"Student with ID {request.StudentId} not found.");

            _mapper.Map(request, existingRequest);
            existingRequest.UpdatedBy = GetCurrentUsername();
            existingRequest.UpdateAt = DateTime.UtcNow;

            await _medicationReqRepository.UpdateMedicationRequest(existingRequest);
        }

        //7. Delete a medication request
        public async Task DeleteMedicationRequest(Guid medicalReqId)
        {
            var medicationRequest = await _medicationReqRepository.GetMedicationRequestById(medicalReqId);
            if (medicationRequest == null)
                throw new KeyNotFoundException($"Medication request with ID {medicalReqId} not found.");

            await _medicationReqRepository.DeleteMedicationRequest(medicalReqId);
        }

        //8. Get the current username from the HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }
    }
}
