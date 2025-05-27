using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class HealthCheckupConsentForm : BaseEntity
    {
        public Guid CampaignId { get; set; }
        public HealthCheckupCampaign? HealthCheckupCampaign { get; set; }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public bool ConsentStatus { get; set; }
        public DateTime ConsentDate { get; set; }
        public string? ReasonForDecline { get; set; }
    }
}
