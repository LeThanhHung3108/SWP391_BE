using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class VaccinationCampaign : BaseEntity
    {
        public string? CampaignName { get; set; } 
        public string? VaccineType { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VaccCampaignStatus? Status { get; set; }
        public ICollection<User>? MedicalStaffs { get; set; }
        public ICollection<StudentVaccinationSchedule>? Schedules { get; set; }
    }
}
            