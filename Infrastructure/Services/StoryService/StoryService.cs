using AutoMapper;
using Domain.Dtos.StoryDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StoryService;

public class StoryService : IStoryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StoryService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetStoryDto> AddStory(AddStoryDto notification)
    {
        var model = _mapper.Map<Story>(notification);
        await _context.Stories.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetStoryDto>(model);
        return result;
    }

    public async Task<GetStoryDto> UpdateStory(AddStoryDto notification)
    {
        var find = await _context.Stories.FindAsync(notification.Id);
        _mapper.Map(notification, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetStoryDto>(find);
        return result;
    }

    public async Task<bool> DeleteStory(int id)
    {
        var find = await _context.Stories.FindAsync(id);
        if (find == null) return false;
        _context.Stories.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetStoryDto> GetStoryById(int id)
    {
        var find = await _context.Stories.FindAsync(id);
        if (find == null) return new GetStoryDto();
        var result = _mapper.Map<GetStoryDto>(find);
        return result;
    }

    public async Task<List<GetStoryDto>> GetStories()
    {
        var model = _context.Stories.ToList();
        var result = _mapper.Map<List<GetStoryDto>>(model);
        return result;
    }
}