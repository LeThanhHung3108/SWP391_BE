using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccCampaignDto
{
    public class CampaignRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; } 
        public CampaignStatus? Status { get; set; }
        public CampaignType? Type { get; set; }
    }
}
