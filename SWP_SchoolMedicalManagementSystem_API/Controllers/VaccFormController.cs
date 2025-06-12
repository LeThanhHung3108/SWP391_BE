using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccFormController : Controller
    {
        private readonly IVaccFormService _vaccFormService;

        public VaccFormController(IVaccFormService vaccFormService)
        {
            _vaccFormService = vaccFormService;
        }

        [HttpGet("get-all-vacc-forms")]
        public async Task<ActionResult<IEnumerable<VaccFormResponse>>> GetAllVaccForms()
        {
            var vaccForms = await _vaccFormService.GetAllVaccFormsAsync();
            return Ok(vaccForms);
        }

        [HttpGet("get-vacc-form-by-id/{vaccFormId}")]
        public async Task<ActionResult<VaccFormResponse>> GetVaccFormById(Guid vaccFormId)
        {
             var vaccForm = await _vaccFormService.GetVaccFormByIdAsync(vaccFormId);
             return Ok(vaccForm);
        }

        [HttpGet("get-vacc-forms-by-campaign-id/{vaccCampaignId}")]
        public async Task<ActionResult<IEnumerable<VaccFormResponse>>> GetVaccFormsByCampaign(Guid vaccCampaignId)
        {
            var vaccForms = await _vaccFormService.GetVaccFormsByCampaignIdAsync(vaccCampaignId);
            return Ok(vaccForms);
        }

        [HttpGet("get-vacc-forms-by-student-id/{studentId}")]
        public async Task<ActionResult<IEnumerable<VaccFormResponse>>> GetVaccFormsByStudent(Guid studentId)
        {
            var vaccForms = await _vaccFormService.GetVaccFormsByStudentIdAsync(studentId);
            return Ok(vaccForms);
        }

        [HttpPost("create-vacc-form")]
        public async Task<ActionResult> CreateVaccForm([FromBody] VaccFormRequest request)
        {
             await _vaccFormService.CreateVaccFormAsync(request);
             return Ok("Vaccination consent form created successfully");

        }

        [HttpPut("update-vacc-form/{vaccFormId}")]
        public async Task<ActionResult> UpdateVaccForm(Guid vaccFormId, [FromBody] VaccFormRequest request)
        {
             await _vaccFormService.UpdateVaccFormAsync(vaccFormId, request);
             return Ok("Vaccination consent form updated successfully");
        }

        [HttpDelete("delete-vacc-form/{vaccFormId}")]
        public async Task<ActionResult> DeleteVaccForm(Guid vaccFormId)
        {
             await _vaccFormService.DeleteVaccFormAsync(vaccFormId);
             return Ok("Vaccination consent form deleted successfully");

        }
    }
}
