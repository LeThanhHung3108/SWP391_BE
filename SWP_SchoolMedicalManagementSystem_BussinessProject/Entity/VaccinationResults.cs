using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public  class VaccinationResults : BaseEntity
    {
        public Guid ScheduleId { get; set; }
        public StudentVaccinationSchedule? VaccinationSchedule { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string? DosageGiven {  get; set; }
        public string? SideEffects {  get; set; }
        public string? Notes { get; set; }
    }
}
