using System;
using System.ComponentModel.DataAnnotations;
namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class UserNotification : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }    
        public Guid NotificationId { get; set; }
        public Notification? Notification { get; set; }        
        public bool IsRead { get; set; } = false;
        public DateTime? SendDate { get; set; }
    }
} 