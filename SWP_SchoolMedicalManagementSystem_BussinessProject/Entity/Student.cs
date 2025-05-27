using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMedicalManagementSystem.Enum;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Student : BaseEntity
    {
        public Guid ParentId { get; set; }
        public User? Parent {  get; set; }
        public string? StudentCode { get; set; }
        public string? FullName { get; set;} 
        public DateTime DateOfBirth { get; set;}
        public Gender Gender { get; set; }      
        public string? Class { get; set; } 
        public string? SchoolYear { get; set; } 
    }
}
