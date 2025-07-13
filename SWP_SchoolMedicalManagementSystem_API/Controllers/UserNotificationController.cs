using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.UserNotifyDto;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserNotificationController : ControllerBase
    {
        private readonly IUserNotificationService _userNotificationService;

        public UserNotificationController(IUserNotificationService userNotificationService)
        {
            _userNotificationService = userNotificationService;
        }

        //1. Get all user notifications
        [HttpGet("get-all-user-notifications")]
        public async Task<IActionResult> GetAllUserNotifications()
        {
            var userNotifications = await _userNotificationService.GetAllUserNotificationsAsync();
            return Ok(userNotifications);
        }

        //2. Get user notification by ID
        [HttpGet("get-user-notification-by-id/{userNotificationId}")]
        public async Task<IActionResult> GetUserNotificationById(Guid userNotificationId)
        {
            var userNotification = await _userNotificationService.GetUserNotificationByIdAsync(userNotificationId);
            return Ok(userNotification);
        }

        //3. Get user notifications by user ID
        [HttpGet("get-user-notifications-by-user-id/{userId}")]
        public async Task<IActionResult> GetUserNotificationsByUserId(Guid userId)
        {
            var userNotifications = await _userNotificationService.GetUserNotificationsByUserIdAsync(userId);
            return Ok(userNotifications);
        }

        //4. Get user notifications by notification ID
        [HttpGet("get-user-notifications-by-notification-id/{notificationId}")]
        public async Task<IActionResult> GetUserNotificationsByNotificationId(Guid notificationId)
        {
            var userNotifications = await _userNotificationService.GetUserNotificationsByNotificationIdAsync(notificationId);
            return Ok(userNotifications);
        }

        //5. Create user notification
        [HttpPost("create-user-notification")]
        public async Task<IActionResult> CreateUserNotification([FromBody] UserNotificationRequest request)
        {
            await _userNotificationService.CreateUserNotificationAsync(request);
            return Ok("User notification created successfully.");
        }

        //6. Update user notification
        [HttpPut("update-user-notification/{userNotificationId}")]
        public async Task<IActionResult> UpdateUserNotification(Guid userNotificationId, [FromBody] UserNotificationRequest request)
        {
            await _userNotificationService.UpdateUserNotificationAsync(userNotificationId, request);
            return Ok("User notification updated successfully.");
        }

        //7. Delete user notification
        [HttpDelete("delete-user-notification/{userNotificationId}")]
        public async Task<IActionResult> DeleteUserNotification(Guid userNotificationId)
        {
            await _userNotificationService.DeleteUserNotificationAsync(userNotificationId);
            return Ok("User notification deleted successfully.");
        }
    }
} 