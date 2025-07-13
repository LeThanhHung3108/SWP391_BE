namespace SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.NotifyDto
{
    public class AssignParentToNotificationDto
    {
        public Guid NotificationId { get; set; }
        public List<Guid> ParentIds { get; set; } = [];
    }
}
