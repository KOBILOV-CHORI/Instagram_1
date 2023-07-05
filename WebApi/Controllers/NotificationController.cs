using Domain.Dtos.NotificationDtos;
using Infrastructure.Services.NotificationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly NotificationService _service;

    public NotificationController(NotificationService service)
    {
        _service = service;
    }
    [HttpPost("AddNotification")]
    public async Task<GetNotificationDto> AddNotification(AddNotificationDto notification)
    {
        return await _service.AddNotification(notification);
    }
    [HttpPut("UpdateNotification")]
    public async Task<GetNotificationDto> UpdateNotification(AddNotificationDto notification)
    {
        return await _service.UpdateNotification(notification);
    }
    [HttpDelete("DeleteNotification")]
    public async Task<bool> DeleteNotification(int id)
    {
        return await _service.DeleteNotification(id);
    }
    [HttpGet("GetNotificationById")]
    public async Task<GetNotificationDto> GetNotificationById(int id)
    {
        return await _service.GetNotificationById(id);
    }
    [HttpGet("GetNotifications")]
    public async Task<List<GetNotificationDto>> GetNotifications()
    {
        return await _service.GetNotifications();
    }
}