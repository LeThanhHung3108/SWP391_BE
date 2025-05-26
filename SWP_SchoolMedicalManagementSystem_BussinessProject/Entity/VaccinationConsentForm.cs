using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class VaccinationConsentForm
    {
        public Guid Id { get; set; }

        public Guid CampaignID { get; set; }

        public Guid StudentID { get; set; }

        public Guid ParentID { get; set; }

        public Boolean ConsentStatus { get; set; }

        public DateTime ConsentDate { get; set; }

        public string? ReasonForDecline { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
