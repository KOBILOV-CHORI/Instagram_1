using AutoMapper;
using Domain.Dtos.NotificationDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.NotificationService;

public class NotificationService : INotificationService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public NotificationService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetNotificationDto> AddNotification(AddNotificationDto notification)
    {
        var model = _mapper.Map<Notification>(notification);
        await _context.Notifications.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetNotificationDto>(model);
        return result;
    }

    public async Task<GetNotificationDto> UpdateNotification(AddNotificationDto notification)
    {
        var find = await _context.Notifications.FindAsync(notification.Id);
        _mapper.Map(notification, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetNotificationDto>(find);
        return result;
    }

    public async Task<bool> DeleteNotification(int id)
    {
        var find = await _context.Notifications.FindAsync(id);
        if (find == null) return false;
        _context.Notifications.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetNotificationDto> GetNotificationById(int id)
    {
        var find = await _context.Notifications.FindAsync(id);
        if (find == null) return new GetNotificationDto();
        var result = _mapper.Map<GetNotificationDto>(find);
        return result;
    }

    public async Task<List<GetNotificationDto>> GetNotifications()
    {
        var model = _context.Notifications.ToList();
        var result = _mapper.Map<List<GetNotificationDto>>(model);
        return result;
    }
}