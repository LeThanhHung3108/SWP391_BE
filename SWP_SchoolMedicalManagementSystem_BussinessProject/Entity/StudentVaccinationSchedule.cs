using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class StudentVaccinationSchedule
    {
        public int ScheduleID { get; set; }

        public int CampaignID { get; set; }

        public int StudentID { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string Location { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; }


        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
