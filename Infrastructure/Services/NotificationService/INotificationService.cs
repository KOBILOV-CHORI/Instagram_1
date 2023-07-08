using Domain.Dtos.NotificationDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.NotificationService;

public interface INotificationService
{
    public Task<Responce<GetNotificationDto>> AddNotification(AddNotificationDto Notification);
    public Task<Responce<GetNotificationDto>> UpdateNotification(AddNotificationDto Notification);
    public Task<Responce<bool>> DeleteNotification(int id);
    public Task<Responce<GetNotificationDto>> GetNotificationById(int id);
    public Task<Responce<List<GetNotificationDto>>> GetNotifications();
}