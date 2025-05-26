using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public  class VaccinationResult
    {
        public Guid Id { get; set; }

        public Guid ScheduleID { get; set; }

        public DateTime VaccinationDate { get; set; }

        public Guid MedicalStaffID { get; set; }

        public string? DosageGiven {  get; set; }

        public string? SideEffects {  get; set; }

        public string? Notes { get; set; }


        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
