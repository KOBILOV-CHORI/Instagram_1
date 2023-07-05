using AutoMapper;
using Domain.Dtos.FollowerDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.FollowerService;

public class FollowerService : IFollowerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public FollowerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetFollowerDto> AddFollower(AddFollowerDto hashtag)
    {
        var model = _mapper.Map<Follower>(hashtag);
        await _context.Followers.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetFollowerDto>(model);
        return result;
    }

    public async Task<GetFollowerDto> UpdateFollower(AddFollowerDto hashtag)
    {
        var find = await _context.Followers.FindAsync(hashtag.Id);
        _mapper.Map(hashtag, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetFollowerDto>(find);
        return result;
    }

    public async Task<bool> DeleteFollower(int id)
    {
        var find = await _context.Followers.FindAsync(id);
        if (find == null) return false;
        _context.Followers.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetFollowerDto> GetFollowerById(int id)
    {
        var find = await _context.Followers.FindAsync(id);
        if (find == null) return new GetFollowerDto();
        var result = _mapper.Map<GetFollowerDto>(find);
        return result;
    }

    public async Task<List<GetFollowerDto>> GetFollowers()
    {
        var model = _context.Followers.ToList();
        var result = _mapper.Map<List<GetFollowerDto>>(model);
        return result;
    }
}