using AutoMapper;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.UserNotifyDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserNotificationService(
            IUserNotificationRepository userNotificationRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _userNotificationRepository = userNotificationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        //1. Get all user notifications
        public async Task<List<UserNotificationResponse>> GetAllUserNotificationsAsync()
        {
            var userNotifications = await _userNotificationRepository.GetAllUserNotificationsAsync();
            if (userNotifications == null || !userNotifications.Any())
            {
                throw new KeyNotFoundException("No user notifications found.");
            }
            return _mapper.Map<List<UserNotificationResponse>>(userNotifications);
        }

        //2. Get user notification by ID
        public async Task<UserNotificationResponse?> GetUserNotificationByIdAsync(Guid userNotificationId)
        {
            var userNotification = await _userNotificationRepository.GetUserNotificationByIdAsync(userNotificationId);
            if (userNotification == null)
            {
                throw new KeyNotFoundException("User notification not found.");
            }
            return _mapper.Map<UserNotificationResponse>(userNotification);
        }

        //3. Get user notifications by user ID
        public async Task<List<UserNotificationResponse>> GetUserNotificationsByUserIdAsync(Guid userId)
        {
            var userNotifications = await _userNotificationRepository.GetUserNotificationsByUserIdAsync(userId);
            if (userNotifications == null || !userNotifications.Any())
            {
                throw new KeyNotFoundException("No user notifications found for this user.");
            }
            return _mapper.Map<List<UserNotificationResponse>>(userNotifications);
        }

        //4. Get user notifications by notification ID
        public async Task<List<UserNotificationResponse>> GetUserNotificationsByNotificationIdAsync(Guid notificationId)
        {
            var userNotifications = await _userNotificationRepository.GetUserNotificationsByNotificationIdAsync(notificationId);
            if (userNotifications == null || !userNotifications.Any())
            {
                throw new KeyNotFoundException("No user notifications found for this notification.");
            }
            return _mapper.Map<List<UserNotificationResponse>>(userNotifications);
        }

        //5. Create new user notification
        public async Task CreateUserNotificationAsync(UserNotificationRequest userNotificationRequest)
        {
            var userNotification = _mapper.Map<UserNotification>(userNotificationRequest);
            userNotification.CreateAt = DateTime.UtcNow;
            userNotification.CreatedBy = GetCurrentUsername();
            userNotification.IsRead = false; // Default value for IsRead
            
            await _userNotificationRepository.CreateUserNotificationAsync(userNotification);
        }

        //6. Update existing user notification
        public async Task UpdateUserNotificationAsync(Guid userNotificationId, UserNotificationRequest userNotificationRequest)
        {
            var existingUserNotification = await _userNotificationRepository.GetUserNotificationByIdAsync(userNotificationId);
            if (existingUserNotification == null)
                throw new KeyNotFoundException($"Notification with ID {userNotificationId} not found.");
            existingUserNotification.UpdatedBy = GetCurrentUsername();
            existingUserNotification.UpdateAt = DateTime.UtcNow;
            _mapper.Map(userNotificationRequest, existingUserNotification);
            await _userNotificationRepository.UpdateUserNotificationAsync(existingUserNotification);
        }
        //7. Delete user notification by ID
        public async Task DeleteUserNotificationAsync(Guid userNotificationId)
        {
            var userNotification = await _userNotificationRepository.GetUserNotificationByIdAsync(userNotificationId);
            if (userNotification == null)
                throw new KeyNotFoundException($"Notification with ID {userNotificationId} not found.");

            await _userNotificationRepository.DeleteUserNotificationAsync(userNotificationId);
        }

        //8. Get the current username from the HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }
    }
}
