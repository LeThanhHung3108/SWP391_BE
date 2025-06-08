using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_API.Models.Requests;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using AutoMapper;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HealthRecordController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IMapper _mapper;

        public HealthRecordController(IHealthRecordService healthRecordService, IMapper mapper)
        {
            _healthRecordService = healthRecordService ?? throw new ArgumentNullException(nameof(healthRecordService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthRecordResponse>>> GetAll()
        {
            try
            {
                var healthRecords = await _healthRecordService.GetAllAsync();
                var response = _mapper.Map<IEnumerable<HealthRecordResponse>>(healthRecords);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HealthRecordResponse>> GetById(Guid id)
        {
            try
            {
                var healthRecord = await _healthRecordService.GetByIdAsync(id);
                if (healthRecord == null)
                {
                    return NotFound($"Health record with ID {id} not found");
                }
                var response = _mapper.Map<HealthRecordResponse>(healthRecord);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<HealthRecordResponse>> GetByStudentId(Guid studentId)
        {
            try
            {
                var healthRecord = await _healthRecordService.GetByStudentIdAsync(studentId);
                if (healthRecord == null)
                {
                    return NotFound($"Health record for student ID {studentId} not found");
                }
                var response = _mapper.Map<HealthRecordResponse>(healthRecord);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HealthRecordResponse>> Create([FromBody] HealthRecordRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request data");
                }

                var createdRecord = await _healthRecordService.CreateAsync(request);
                var response = _mapper.Map<HealthRecordResponse>(createdRecord);
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HealthRecordResponse>> Update(Guid id, [FromBody] HealthRecordRequest request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request data");
                }

                if (!await _healthRecordService.ExistsAsync(id))
                {
                    return NotFound($"Health record with ID {id} not found");
                }

                var updatedRecord = await _healthRecordService.UpdateAsync(request);
                var response = _mapper.Map<HealthRecordResponse>(updatedRecord);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if (!await _healthRecordService.ExistsAsync(id))
                {
                    return NotFound($"Health record with ID {id} not found");
                }

                var result = await _healthRecordService.DeleteAsync(id);
                if (result)
                {
                    return NoContent();
                }
                return StatusCode(500, "Failed to delete health record");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
