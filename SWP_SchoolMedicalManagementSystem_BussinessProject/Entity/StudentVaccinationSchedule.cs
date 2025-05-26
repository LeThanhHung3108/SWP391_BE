using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class StudentVaccinationSchedule
    {
        public Guid Id { get; set; }

        public Guid CampaignID { get; set; }

        public Guid StudentID { get; set; }

        public DateTime ScheduledDate { get; set; }

        public string? Location { get; set; }

        public string? Notes { get; set; }

        public string? Status { get; set; }


        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
