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
    public async Task<IActionResult> AddNotification(AddNotificationDto notification)
    {
        var result = await _service.AddNotification(notification);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateNotification")]
    public async Task<IActionResult> UpdateNotification(AddNotificationDto notification)
    {
        var result = await _service.UpdateNotification(notification);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteNotification")]
    public async Task<IActionResult> DeleteNotification(int id)
    {
        var result = await _service.DeleteNotification(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetNotificationById")]
    public async Task<IActionResult> GetNotificationById(int id)
    {
        var result = await _service.GetNotificationById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetNotifications")]
    public async Task<IActionResult> GetNotifications()
    {
        var result = await _service.GetNotifications();
        return StatusCode((int)result.StatusCode, result);
    }
}