using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.NotifyDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.ScheduleDto;
using SWP_SchoolMedicalManagementSystem_Service.Service;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        //1. Get all notifications
        [HttpGet("get-all-notifications")]
        public async Task<IActionResult> GetAllNotifications()
        {
             var notifications = await _notificationService.GetAllNotificationsAsync();
             return Ok(notifications);
        }

        //2. Get notification by ID
        [HttpGet("get-notification-by-id/{notificationId}")]
        public async Task<IActionResult> GetNotificationById(Guid notificationId)
        {
             var notification = await _notificationService.GetNotificationByIdAsync(notificationId);
             return Ok(notification);
        }

        //3. Create notifications
        [HttpPost("create-notification")]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationRequest request)
        {
            await _notificationService.CreateNotificationAsync(request);
            return Ok("Notification created successfully.");
        }

        //4. Update notification
        [HttpPut("update-notification/{notificationId}")]
        public async Task<IActionResult> UpdateNotification(Guid notificationId, [FromBody] NotificationRequest request)
        {
            await _notificationService.UpdateNotificationAsync(notificationId, request);
            return Ok("Notification updated successfully.");
        }

        //5. Delete notification
        [HttpDelete("delete-notification/{notificationId}")]
        public async Task<IActionResult> DeleteNotification(Guid notificationId)
        {
            await _notificationService.DeleteNotificationAsync(notificationId);
            return Ok("Notification deleted successfully.");
        }
    }
}
