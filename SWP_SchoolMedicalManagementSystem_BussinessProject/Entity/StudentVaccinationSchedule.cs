using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class StudentVaccinationSchedule : BaseEntity
    {
        public Guid CampaignID { get; set; }
        public VaccinationCampaign? VaccinationCampaign { get; set; }
        public Guid StudentID { get; set; }
        public Student? Student { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Location { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
    }
}
