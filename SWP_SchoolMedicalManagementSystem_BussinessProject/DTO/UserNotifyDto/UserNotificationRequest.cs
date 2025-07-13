using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;

namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.UserNotifyDto
{
    public class UserNotificationRequest
    {
        public Guid UserId { get; set; }
        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? SendDate { get; set; }
    }
}
