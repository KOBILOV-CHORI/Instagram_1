using System.Net;
using AutoMapper;
using Domain.Dtos.HashtagDtos;
using Domain.Dtos.NotificationDtos;
using Domain.Entities;
using Domain.Wrapper;
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

    public async Task<Responce<GetNotificationDto>> AddNotification(AddNotificationDto notification)
    {
        try
        {
            var model = _mapper.Map<Notification>(notification);
            await _context.Notifications.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetNotificationDto>(model);
            return new Responce<GetNotificationDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetNotificationDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetNotificationDto>> UpdateNotification(AddNotificationDto notification)
    {
        try
        {
            var find = await _context.Notifications.FindAsync(notification.Id);
            _mapper.Map(notification, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetNotificationDto>(find);
            return new Responce<GetNotificationDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetNotificationDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteNotification(int id)
    {
        try
        {
            var find = await _context.Notifications.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Notifications.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetNotificationDto>> GetNotificationById(int id)
    {
        try
        {
        var find = await _context.Notifications.FindAsync(id);
        if (find == null) return new Responce<GetNotificationDto>(new GetNotificationDto());
        var result = _mapper.Map<GetNotificationDto>(find);
        return new Responce<GetNotificationDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetNotificationDto>(HttpStatusCode.InternalServerError, e.Message);
        }

    }

    public async Task<Responce<List<GetNotificationDto>>> GetNotifications()
    {
        try
        {
        var model = _context.Notifications.ToList();
        var result = _mapper.Map<List<GetNotificationDto>>(model);
        return new Responce<List<GetNotificationDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetNotificationDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}