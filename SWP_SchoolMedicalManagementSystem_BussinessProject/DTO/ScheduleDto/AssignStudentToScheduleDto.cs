using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.ScheduleDto
{
    public class AssignStudentToScheduleDto
    {
        public Guid ScheduleId { get; set; }
        public List<Guid> StudentIds { get; set; } = [];
    }
}
