using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthRecordController : Controller
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        //1. Get All Health Records
        [HttpGet("get-all-healtRecords")]
        public async Task<IActionResult> GetAllHealthRecord()
        {
            var healthRecords = await _healthRecordService.GetAllHealthRecordAsync();
            return Ok(healthRecords);
        }


        //2. Get Health Record by ID
        [HttpGet("get-healthRecord-by-id/{healthRecordId}")]
        public async Task<IActionResult> GetHealthRecordById(Guid healthRecordId)
        {
            var healthRecord = await _healthRecordService.GetHealthRecordByIdAsync(healthRecordId);
            return Ok(healthRecord);

        }

        //3. Get Health Record by Student ID
        [HttpGet("get-healthRecord-by-studentId/{studentId}")]
        public async Task<IActionResult> GetByStudentId(Guid studentId)
        {
            var healthRecord = await _healthRecordService.GetHealthRecordByStudentIdAsync(studentId);
            return Ok(healthRecord);
            
        }

        //4. Create Health Record
        [HttpPost("create-healthRecord")]
        public async Task<IActionResult> CreateHealthRecord([FromBody] HealthRecordRequest request)
        {
            await _healthRecordService.CreateHealthRecordAsync(request);
            return Ok("HealthRecord created successfully.");
        }

        //5. Update Health Record
        [HttpPut("update-healthRecord/{healthRecordId}")]
        public async Task<IActionResult> UpdateHealthRecord(Guid healthRecordId, [FromBody] HealthRecordRequest request)
        {
                if (request == null)
                {
                    return BadRequest("Invalid request data");
                }

                await _healthRecordService.UpdateHealthRecordAsync(healthRecordId, request);
                return Ok("HealthRecord updated successfully.");
        }

        //6. Delete Health Record
        [HttpDelete("delete-healthRecord/{healthRecordId}")]
        public async Task<IActionResult> DeleteHealthRecord(Guid healthRecordId)
        {          
           await _healthRecordService.DeleteHealthRecordAsync(healthRecordId);
           return Ok("HealthRecord deleted successfuly.");
        }
    }
}
