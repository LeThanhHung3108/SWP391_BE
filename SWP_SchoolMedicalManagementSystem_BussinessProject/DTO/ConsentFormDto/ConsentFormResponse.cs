using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.VaccFormDto
{
    public class ConsentFormResponse
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public string? CampaignName { get; set; }
        public Guid StudentId { get; set; }
        public string? StudentName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ConsentDate { get; set; }
        public string? ReasonForDecline { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
