using SchoolMedicalManagementSystem.Enum;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.Response
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string? StudentCode { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Class { get; set; }
        public string? SchoolYear { get; set; }
        public string? Image { get; set; }
        
    }
} 