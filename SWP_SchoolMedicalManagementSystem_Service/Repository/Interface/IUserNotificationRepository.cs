using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using System;
using System.Collections.Generic;
namespace SWP_SchoolMedicalManagementSystem_Service.Repository.Interface
{
    public interface IUserNotificationRepository
    {
        Task<List<UserNotification>> GetAllUserNotificationsAsync();
        Task<UserNotification?> GetUserNotificationByIdAsync(Guid userNotificationId);
        Task<List<UserNotification>> GetUserNotificationsByUserIdAsync(Guid userId);
        Task<List<UserNotification>> GetUserNotificationsByNotificationIdAsync(Guid notificationId);
        Task CreateUserNotificationAsync(UserNotification userNotification);
        Task UpdateUserNotificationAsync(UserNotification userNotification);
        Task DeleteUserNotificationAsync(Guid userNotificationId);
    }
}
