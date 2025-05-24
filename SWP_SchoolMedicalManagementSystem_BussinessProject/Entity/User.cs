using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class User
    {
        public int UserID { get; set; } 

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string UserRole { get; set; } = string.Empty;
        
        public DateTime CreateAt { get; set; }  

        public DateTime UpdateAt { get; set; }  
   

            





    }


}
