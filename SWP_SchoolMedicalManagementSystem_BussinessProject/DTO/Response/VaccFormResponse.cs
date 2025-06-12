using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response
{
    public class VaccFormResponse
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public Guid StudentId { get; set; }
        public bool ConsentStatus { get; set; }
        public DateTime ConsentDate { get; set; }
        public string? ReasonForDecline { get; set; }
    }
}
