using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class MedicalIncident
    {
        public int IncidentID { get; set; }

        public int StudentID { get; set; }

        public string IncidentType { get; set; }

        public DateTime IncidentDate { get; set; }

        public string Description { get; set; } 
        
        public string ActionsTaken { get; set; }

        public int MedicalStaffID { get; set; }

        public string Outcome { get; set; }

        public string Status { get; set; }

        public Boolean ParentNotified { get; set; }

        public DateTime ParentNotificationDate { get;set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }


    }
}
