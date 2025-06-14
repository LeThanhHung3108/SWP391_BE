using SchoolMedicalManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccCampaignDto
{
    public class VaccCampaignRequest
    {
        public string? CampaignName { get; set; }
        public string? VaccineType { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VaccCampaignStatus? Status { get; set; }
    }
}
