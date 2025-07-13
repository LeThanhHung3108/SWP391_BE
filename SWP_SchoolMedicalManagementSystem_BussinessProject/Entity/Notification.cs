namespace SWP_SchoolMedicalManagementSystem_BussinessOject.Entity
{
    public class Notification : BaseEntity
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Type { get; set; }    
        public ICollection<UserNotification>? UserNotifications { get; set; }
    }
}
