using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class HealthCheckupConsentForm
    {
        public int ConsetnFormID { get; set; }

        public int CampaignID { get; set; }

        public int StudentID { get; set; }

        public int ParentID { get; set; }

        public Boolean ConsentStatus { get; set; }

        public DateTime ConsentDate { get; set; }

        public string ReasonForDecline { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
