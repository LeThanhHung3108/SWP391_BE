namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.UserNotifyDto
{
    public class UserNotificationResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid NotificationId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? SendDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
