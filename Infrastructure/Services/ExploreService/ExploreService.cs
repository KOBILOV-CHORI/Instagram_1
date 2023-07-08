using System.Net;
using AutoMapper;
using Domain.Dtos.ExploreDtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ExploreService;

public class ExploreService : IExploreService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ExploreService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Responce<GetExploreDto>> AddExplore(AddExploreDto comment)
    {
        try
        {
        var model = _mapper.Map<Explore>(comment);
        await _context.Explores.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetExploreDto>(model);
        return new Responce<GetExploreDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetExploreDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetExploreDto>> UpdateExplore(AddExploreDto comment)
    {
        try
        {
        var find = await _context.Explores.FindAsync(comment.Id);
        _mapper.Map(comment, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetExploreDto>(find);
        return new Responce<GetExploreDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetExploreDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteExplore(int id)
    {
        try
        {
        var find = await _context.Explores.FindAsync(id);
        if (find == null) return new Responce<bool>(false);
        _context.Explores.Remove(find);
        await _context.SaveChangesAsync();
        return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetExploreDto>> GetExploreById(int id)
    {
        try
        {
        var find = await _context.Explores.FindAsync(id);
        if (find == null) return new Responce<GetExploreDto>(new GetExploreDto());
        var result = _mapper.Map<GetExploreDto>(find);
        return new Responce<GetExploreDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetExploreDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetExploreDto>>> GetExplores()
    {
        try
        {
        var model = _context.Explores.ToList();
        var result = _mapper.Map<List<GetExploreDto>>(model);
        return new Responce<List<GetExploreDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetExploreDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}