using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly ApplicationDBContext _context;

        public UserNotificationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //1. Get all user notifications
        public async Task<List<UserNotification>> GetAllUserNotificationsAsync()
        {
            return await _context.UserNotifications
                .Include(un => un.User)
                .Include(un => un.Notification)
                .ToListAsync();
        }

        //2. Get user notification by ID
        public async Task<UserNotification?> GetUserNotificationByIdAsync(Guid userNotificationId)
        {
            return await _context.UserNotifications
                .Include(un => un.User)
                .Include(un => un.Notification)
                .FirstOrDefaultAsync(un => un.Id == userNotificationId);
        }

        //3. Get user notifications by user ID
        public async Task<List<UserNotification>> GetUserNotificationsByUserIdAsync(Guid userId)
        {
            return await _context.UserNotifications
                .Include(un => un.User)
                .Include(un => un.Notification)
                .Where(un => un.UserId == userId)
                .ToListAsync();
        }

        //4. Get user notifications by notification ID
        public async Task<List<UserNotification>> GetUserNotificationsByNotificationIdAsync(Guid notificationId)
        {
            return await _context.UserNotifications
                .Include(un => un.User)
                .Include(un => un.Notification)
                .Where(un => un.NotificationId == notificationId)
                .ToListAsync();
        }

        //5. Create new user notification
        public async Task CreateUserNotificationAsync(UserNotification userNotification)
        {
            await _context.UserNotifications.AddAsync(userNotification);
            await _context.SaveChangesAsync();
        }

        //6. Update user notification
        public async Task UpdateUserNotificationAsync(UserNotification userNotification)
        {
            _context.UserNotifications.Update(userNotification);
            await _context.SaveChangesAsync();
        }

        //7. Delete user notification
        public async Task DeleteUserNotificationAsync(Guid userNotificationId)
        {
            var userNotification = await GetUserNotificationByIdAsync(userNotificationId);
            if (userNotification != null)
            {
                _context.UserNotifications.Remove(userNotification);
                await _context.SaveChangesAsync();
            }
        }
    }
}
