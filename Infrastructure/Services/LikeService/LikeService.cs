using AutoMapper;
using Domain.Dtos.LikeDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.LikeService;

public class LikeService : ILikeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public LikeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetLikeDto> AddLike(AddLikeDto like)
    {
        var model = _mapper.Map<Like>(like);
        await _context.Likes.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetLikeDto>(model);
        return result;
    }

    public async Task<GetLikeDto> UpdateLike(AddLikeDto like)
    {
        var find = await _context.Likes.FindAsync(like.Id);
        _mapper.Map(like, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetLikeDto>(find);
        return result;
    }

    public async Task<bool> DeleteLike(int id)
    {
        var find = await _context.Likes.FindAsync(id);
        if (find == null) return false;
        _context.Likes.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetLikeDto> GetLikeById(int id)
    {
        var find = await _context.Likes.FindAsync(id);
        if (find == null) return new GetLikeDto();
        var result = _mapper.Map<GetLikeDto>(find);
        return result;
    }

    public async Task<List<GetLikeDto>> GetLikes()
    {
        var model = _context.Likes.ToList();
        var result = _mapper.Map<List<GetLikeDto>>(model);
        return result;
    }
}