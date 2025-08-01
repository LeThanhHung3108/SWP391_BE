﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using SWP_SchoolMedicalManagementSystem_BussinessOject.DTO.NotifyDto;
using SWP_SchoolMedicalManagementSystem_BussinessOject.Entity;
using SWP_SchoolMedicalManagementSystem_Service.Repository.Interface;
using SWP_SchoolMedicalManagementSystem_Service.Service.Interface;

namespace SWP_SchoolMedicalManagementSystem_Service.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMedicalIncidentRepository _medicalIncidentRepository;

        public NotificationService(INotificationRepository notificationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ICampaignRepository campaignRepository, IMedicalIncidentRepository medicalIncidentRepository)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _campaignRepository = campaignRepository;
            _medicalIncidentRepository = medicalIncidentRepository;
        }

        //1. Get all notifications
        public async Task<List<NotificationResponse>> GetAllNotificationsAsync()
        {
            var notifications = await _notificationRepository.GetAllNotificationsAsync();
            if (notifications == null || !notifications.Any())
                throw new KeyNotFoundException("No notifications found.");
            return _mapper.Map<List<NotificationResponse>>(notifications);
        }

        //2. Get notification by ID
        public async Task<NotificationResponse> GetNotificationByIdAsync(Guid notificationId)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(notificationId);
            if (notification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationId} not found.");
            return _mapper.Map<NotificationResponse>(notification);
        }

        //3. Create a new notification
        public async Task CreateNotificationAsync(NotificationRequest notification)
        {
            try
            {
                string body = string.Empty;
                string title = string.Empty;
                string returnUrl = string.Empty;

                var listUsers = new List<User>();
                if (notification.CampaignId != null)
                {
                    var campaign = await _campaignRepository.GetCampaignByIdAsync((Guid)notification.CampaignId);
                    if (campaign == null)
                        throw new KeyNotFoundException($"Campaign with ID {notification.CampaignId} not found.");

                    title = $"Thông báo mới về chiến dịch: {campaign.Name}";
                    body = $"Bạn có thông báo mới về chiến dịch:{campaign.Name}";
                    returnUrl = $"http://localhost:3000/vaccination/campaign/{campaign.Id}";
                    listUsers = campaign.Schedules.SelectMany(s => s.ScheduleDetails.Select(sd => sd.Student.Parent)).Distinct().ToList();
                }
                
                if(notification.IncidentId != null)
                {
                    var incident = await _medicalIncidentRepository.GetIncidentByIdAsync((Guid)notification.IncidentId);
                    if (incident == null)
                        throw new KeyNotFoundException($"Incident with ID {notification.IncidentId} not found.");

                    title = "Bạn có thông báo mới về sự cố y tế";
                    body = $"Học sinh với tên {incident.Student.FullName} đang có một sự cố y tế vào lúc {incident.CreateAt}";
                    returnUrl = "http://localhost:3000/medical-events";
                    listUsers.Add(incident?.Student?.Parent);
                }

                var newNotification = _mapper.Map<Notification>(notification);
                newNotification.Title = title ?? "Thông báo mới";
                newNotification.Content = body;
                newNotification.ReturnUrl = returnUrl;
                newNotification.Users = listUsers;
                newNotification.CreatedBy = GetCurrentUsername();
                newNotification.CreateAt = DateTime.UtcNow;

                await _notificationRepository.CreateNotificationAsync(newNotification);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while creating the notification.", ex);
            }
        }

        //4. Update an existing notification
        public async Task UpdateNotificationAsync(Guid notificationId, NotificationRequest notification)
        {
            var existingNotification = await _notificationRepository.GetNotificationByIdAsync(notificationId);
            if (existingNotification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationId} not found.");
            existingNotification.UpdatedBy = GetCurrentUsername();
            existingNotification.UpdateAt = DateTime.UtcNow;
            _mapper.Map(notification, existingNotification);
            await _notificationRepository.UpdateNotificationAsync(existingNotification);
        }

        //5. Delete a notification
        public async Task DeleteNotificationAsync(Guid notificationId)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(notificationId);
            if (notification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationId} not found.");         
            await _notificationRepository.DeleteNotificationAsync(notificationId);
        }

        //6. Get current username from HTTP context
        private string GetCurrentUsername()
        {
            return _httpContextAccessor.HttpContext?.User.FindFirst("username")?.Value ?? "Unknown User";
        }

        //7. Get notifications by user ID
        public async Task<List<NotificationResponse>> GetNotificationsByUserIdAsync(Guid userId)
        {
            var notifications = await _notificationRepository.GetNotificationsByUserIdAsync(userId);
            if (notifications == null || !notifications.Any())
                throw new KeyNotFoundException($"No notifications found for user with ID {userId}.");
            return _mapper.Map<List<NotificationResponse>>(notifications);
        }
    }
}
