using AutoMapper;
using Domain.Dtos.HashtagDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.HashtagService;

public class HashtagService : IHashtagService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public HashtagService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetHashtagDto> AddHashtag(AddHashtagDto hashtag)
    {
        var model = _mapper.Map<Hashtag>(hashtag);
        await _context.Hashtags.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetHashtagDto>(model);
        return result;
    }

    public async Task<GetHashtagDto> UpdateHashtag(AddHashtagDto hashtag)
    {
        var find = await _context.Hashtags.FindAsync(hashtag.Id);
        _mapper.Map(hashtag, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetHashtagDto>(find);
        return result;
    }

    public async Task<bool> DeleteHashtag(int id)
    {
        var find = await _context.Hashtags.FindAsync(id);
        if (find == null) return false;
        _context.Hashtags.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetHashtagDto> GetHashtagById(int id)
    {
        var find = await _context.Hashtags.FindAsync(id);
        if (find == null) return new GetHashtagDto();
        var result = _mapper.Map<GetHashtagDto>(find);
        return result;
    }

    public async Task<List<GetHashtagDto>> GetHashtags()
    {
        var model = _context.Hashtags.ToList();
        var result = _mapper.Map<List<GetHashtagDto>>(model);
        return result;
    }
}