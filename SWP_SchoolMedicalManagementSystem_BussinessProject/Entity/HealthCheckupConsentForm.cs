using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class HealthCheckupConsentForm : BaseEntity
    {
        public Guid CampaignID { get; set; }
        public HealthCheckupCampaign? HealthCheckupCampaign { get; set; }
        public Guid StudentID { get; set; }
        public Student? Student { get; set; }
        public Guid ParentID { get; set; }
        public User? Parent { get; set; }
        public Boolean ConsentStatus { get; set; }
        public DateTime ConsentDate { get; set; }
        public string? ReasonForDecline { get; set; }
    }
}
