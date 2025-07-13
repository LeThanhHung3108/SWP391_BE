using Microsoft.EntityFrameworkCore;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Context;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_SchoolMedicalManagementSystem_Service.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDBContext _context;
        public NotificationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        //1. Get all notifications
        public Task<List<Notification>> GetAllNotificationsAsync()
        {
            return _context.Notifications
                .Include(n => n.UserNotifications)
                .ToListAsync();
        }

        //2. Get notification by ID
        public Task<Notification?> GetNotificationByIdAsync(Guid notificationId)
        {
            return _context.Notifications
                .Include(n => n.UserNotifications)
                .FirstOrDefaultAsync(n => n.Id == notificationId);
        }

        //3. Create notification
        public async Task CreateNotificationAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        //4. Update notification
        public async Task UpdateNotificationAsync(Notification notification)
        {
            _context.Entry(notification).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //5. Delete notification
        public async Task DeleteNotificationAsync(Guid notificationId)
        {
            var notification = await GetNotificationByIdAsync(notificationId);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }
    }
}
