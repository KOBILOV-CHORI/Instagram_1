using System.Net;
using AutoMapper;
using Domain.Dtos.PostDtos;
using Domain.Dtos.StoryDtos;
using Domain.Entities;
using Domain.Wrapper;
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
    public async Task<Responce<GetStoryDto>> AddStory(AddStoryDto notification)
    {
        try
        {
        var model = _mapper.Map<Story>(notification);
        await _context.Stories.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetStoryDto>(model);
        return new Responce<GetStoryDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetStoryDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetStoryDto>> UpdateStory(AddStoryDto notification)
    {
        try
        {
        var find = await _context.Stories.FindAsync(notification.Id);
        _mapper.Map(notification, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetStoryDto>(find);
        return new Responce<GetStoryDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetStoryDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteStory(int id)
    {
        try
        {
        var find = await _context.Stories.FindAsync(id);
        if (find == null) return new Responce<bool>(false);
        _context.Stories.Remove(find);
        await _context.SaveChangesAsync();
        return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetStoryDto>> GetStoryById(int id)
    {
        try
        {
        var find = await _context.Stories.FindAsync(id);
        if (find == null) return new Responce<GetStoryDto>(new GetStoryDto());
        var result = _mapper.Map<GetStoryDto>(find);
        return new Responce<GetStoryDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetStoryDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetStoryDto>>> GetStories()
    {
        try
        {
        var model = _context.Stories.ToList();
        var result = _mapper.Map<List<GetStoryDto>>(model);
        return new Responce<List<GetStoryDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetStoryDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}