using System.Net;
using AutoMapper;
using Domain.Dtos.CommentDtos;
using Domain.Dtos.DirectMessageDtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.DirectMessageService;

public class DIrectMessageService : IDirectMessageService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public DIrectMessageService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Responce<GetDirectMessageDto>> AddDirectMessage(AddDirectMessageDto directMessage)
    {
        try
        {
            var model = _mapper.Map<DirectMessage>(directMessage);
            await _context.DirectMessages.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetDirectMessageDto>(model);
            return new Responce<GetDirectMessageDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetDirectMessageDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetDirectMessageDto>> UpdateDirectMessage(AddDirectMessageDto directMessage)
    {
        try
        {
            var find = await _context.DirectMessages.FindAsync(directMessage.Id);
            _mapper.Map(directMessage, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetDirectMessageDto>(find);
            return new Responce<GetDirectMessageDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetDirectMessageDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteDirectMessage(int id)
    {
        try
        {
            var find = await _context.DirectMessages.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.DirectMessages.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetDirectMessageDto>> GetDirectMessageById(int id)
    {
        try
        {
            var find = await _context.DirectMessages.FindAsync(id);
            if (find == null) return new Responce<GetDirectMessageDto>(new GetDirectMessageDto());
            var result = _mapper.Map<GetDirectMessageDto>(find);
            return new Responce<GetDirectMessageDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetDirectMessageDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetDirectMessageDto>>> GetDirectMessages()
    {
        try
        {
            var model = _context.DirectMessages.ToList();
            var result = _mapper.Map<List<GetDirectMessageDto>>(model);
            return new Responce<List<GetDirectMessageDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetDirectMessageDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}