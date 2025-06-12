using Microsoft.AspNetCore.Mvc;
using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Request;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccCampaignController : Controller
    {
        private readonly IVaccCampaignService _vaccCampaignService;

        public VaccCampaignController(IVaccCampaignService vaccCampaignService)
        {
            _vaccCampaignService = vaccCampaignService;
        }

        //1. Get all vaccination campaigns
        [HttpGet("get-all-vacc-campaigns")]
        public async Task<IActionResult> GetVaccCampaigns()
        {
            var campaigns = await _vaccCampaignService.GetAllVaccCampaignsAsync();
            return Ok(campaigns);
        }

        //2. Get vaccination campaign by ID
        [HttpGet("get-vacc-campaign-by-id/{vaccCampaignId}")]
        public async Task<IActionResult> GetVaccCampaignById(Guid vaccCampaignId)
        {
            var vaccCampaign = await _vaccCampaignService.GetVaccCampaignByIdAsync(vaccCampaignId);
            if (vaccCampaign == null)
            {
                return NotFound($"Vaccination campaign with ID {vaccCampaignId} not found.");
            }
            return Ok(vaccCampaign);
        }

        //3. Get vaccination campaigns by status
        [HttpGet("get-vacc-campaigns-by-status/{status}")]
        public async Task<IActionResult> GetVaccCampaignsByStatus(VaccCampaignStatus status)
        {
            var vaccCampaign = await _vaccCampaignService.GetCampaignsByStatusAsync(status);
            if (vaccCampaign == null || !vaccCampaign.Any())
            {
                return NotFound($"No vaccination campaigns found with status {status}.");
            }
            return Ok(vaccCampaign);
        }

        //4. Create a new vaccination campaign
        [HttpPost("create-vacc-campaign")]
        public async Task<IActionResult> CreateVaccCampaign([FromBody] VaccCampaignRequest request)
        {
            if (request == null)
            {
                return BadRequest("Campaign data is required.");
            }

            await _vaccCampaignService.CreateCampaignAsync(request);
            return Ok("Vaccination campaign created successfully.");
        }

        //5. Update an existing vaccination campaign
        [HttpPut("update-vacc-campaign/{vaccCampaignId}")]
        public async Task<IActionResult> UpdateVaccCampaign(Guid vaccCampaignId, [FromBody] VaccCampaignRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid update request.");
            }

            await _vaccCampaignService.UpdateCampaignAsync(vaccCampaignId, request);
            return Ok("Vaccination campaign updated successfully.");
        }

        //6. Delete a vaccination campaign
        [HttpDelete("delete-vacc-campaign/{vaccCampaignId}")]
        public async Task<IActionResult> DeleteVaccCampaign(Guid vaccCampaignId)
        {
            await _vaccCampaignService.DeleteCampaignAsync(vaccCampaignId);
            return Ok("Vaccination campaign deleted successfully.");
        }
    }
}
