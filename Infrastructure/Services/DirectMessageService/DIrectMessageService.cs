using AutoMapper;
using Domain.Dtos.DirectMessageDtos;
using Domain.Entities;
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
    public async Task<GetDirectMessageDto> AddDirectMessage(AddDirectMessageDto directMessage)
    {
        var model = _mapper.Map<DirectMessage>(directMessage);
        await _context.DirectMessages.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetDirectMessageDto>(model);
        return result;
    }

    public async Task<GetDirectMessageDto> UpdateDirectMessage(AddDirectMessageDto directMessage)
    {
        var find = await _context.DirectMessages.FindAsync(directMessage.Id);
        _mapper.Map(directMessage, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetDirectMessageDto>(find);
        return result;
    }

    public async Task<bool> DeleteDirectMessage(int id)
    {
        var find = await _context.DirectMessages.FindAsync(id);
        if (find == null) return false;
        _context.DirectMessages.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetDirectMessageDto> GetDirectMessageById(int id)
    {
        var find = await _context.DirectMessages.FindAsync(id);
        if (find == null) return new GetDirectMessageDto();
        var result = _mapper.Map<GetDirectMessageDto>(find);
        return result;
    }

    public async Task<List<GetDirectMessageDto>> GetDirectMessages()
    {
        var model = _context.DirectMessages.ToList();
        var result = _mapper.Map<List<GetDirectMessageDto>>(model);
        return result;
    }
}