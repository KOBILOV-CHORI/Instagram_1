using Domain.Dtos.NotificationDtos;

namespace Infrastructure.Services.NotificationService;

public interface INotificationService
{
    public Task<GetNotificationDto> AddNotification(AddNotificationDto Notification);
    public Task<GetNotificationDto> UpdateNotification(AddNotificationDto Notification);
    public Task<bool> DeleteNotification(int id);
    public Task<GetNotificationDto> GetNotificationById(int id);
    public Task<List<GetNotificationDto>> GetNotifications();
}