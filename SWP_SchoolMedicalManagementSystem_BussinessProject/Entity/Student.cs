using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Student
    {
        public int StudentID { get; set; }
        public int ParentID { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string FullName { get; set;} = string.Empty;
        public DateTime DateOfBirth { get; set;}

        public string Gender { get; set; } = string.Empty;       
        public string Class { get; set; } = string.Empty;

        public string SchoolYear { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
