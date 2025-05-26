using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Student : BaseEntity
    {
        public Guid ParentID { get; set; }
        public User? Parent {  get; set; }
        public string? StudentCode { get; set; }
        public string? FullName { get; set;} 
        public DateTime DateOfBirth { get; set;}
        public string? Gender { get; set; }      
        public string? Class { get; set; } 
        public string? SchoolYear { get; set; } 
    }
}
