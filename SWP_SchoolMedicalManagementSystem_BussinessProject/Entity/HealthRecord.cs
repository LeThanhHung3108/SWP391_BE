using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class HealthRecord
    {
        public int HealthRecordID { get; set; }
        public int StudentID { get; set; } 
        public string Allergies { get; set; } 
        public string ChronicDiseases { get; set; }
        public string PastMedicalHistory { get; set; }
        public string VisionLeft { get; set; }
        public string VisionRight { get; set; }
        public string HearingLeft { get; set; }
        public string HearingRight { get; set; }
        public string VaccinationHistory { get; set; }
        public string OtherNotes { get; set; }
        public int LastUpdatedByParentID { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
