using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.UserNotifyDto;
namespace SWP_SchoolMedicalManagementSystem_Service.Service.Interface
{
    public interface IUserNotificationService
    {
        Task<List<UserNotificationResponse>> GetAllUserNotificationsAsync();
        Task<UserNotificationResponse?> GetUserNotificationByIdAsync(Guid userNotificationId);
        Task<List<UserNotificationResponse>> GetUserNotificationsByUserIdAsync(Guid userId);
        Task<List<UserNotificationResponse>> GetUserNotificationsByNotificationIdAsync(Guid notificationId);
        Task CreateUserNotificationAsync(UserNotificationRequest userNotification);
        Task UpdateUserNotificationAsync(Guid userNotificationId, UserNotificationRequest userNotification);
        Task DeleteUserNotificationAsync(Guid userNotificationId);
    }
}
