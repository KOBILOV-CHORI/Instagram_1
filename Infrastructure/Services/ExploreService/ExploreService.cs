using AutoMapper;
using Domain.Dtos.ExploreDtos;
using Domain.Entities;
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
    public async Task<GetExploreDto> AddExplore(AddExploreDto comment)
    {
        var model = _mapper.Map<Explore>(comment);
        await _context.Explores.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetExploreDto>(model);
        return result;
    }

    public async Task<GetExploreDto> UpdateExplore(AddExploreDto comment)
    {
        var find = await _context.Explores.FindAsync(comment.Id);
        _mapper.Map(comment, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetExploreDto>(find);
        return result;
    }

    public async Task<bool> DeleteExplore(int id)
    {
        var find = await _context.Explores.FindAsync(id);
        if (find == null) return false;
        _context.Explores.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetExploreDto> GetExploreById(int id)
    {
        var find = await _context.Explores.FindAsync(id);
        if (find == null) return new GetExploreDto();
        var result = _mapper.Map<GetExploreDto>(find);
        return result;
    }

    public async Task<List<GetExploreDto>> GetExplores()
    {
        var model = _context.Explores.ToList();
        var result = _mapper.Map<List<GetExploreDto>>(model);
        return result;
    }
}