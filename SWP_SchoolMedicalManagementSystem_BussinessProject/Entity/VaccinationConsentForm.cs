using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class VaccinationConsentForm : BaseEntity
    {
        public Guid CampaignId { get; set; }
        public VaccinationCampaign? VaccinationCampaign { get; set; }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
        public Guid ParentId { get; set; }
        public User? Parent { get; set; }
        public bool ConsentStatus { get; set; }
        public DateTime ConsentDate { get; set; }
        public string? ReasonForDecline { get; set; }
    }
}
