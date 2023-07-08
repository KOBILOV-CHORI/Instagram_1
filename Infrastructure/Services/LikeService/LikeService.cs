using System.Net;
using AutoMapper;
using Domain.Dtos.HashtagDtos;
using Domain.Dtos.LikeDtos;
using Domain.Entities;
using Domain.Wrapper;
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

    public async Task<Responce<GetLikeDto>> AddLike(AddLikeDto like)
    {
        try
        {
            var model = _mapper.Map<Like>(like);
            await _context.Likes.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetLikeDto>(model);
            return new Responce<GetLikeDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetLikeDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetLikeDto>> UpdateLike(AddLikeDto like)
    {
        try
        {
            var find = await _context.Likes.FindAsync(like.Id);
            _mapper.Map(like, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetLikeDto>(find);
            return new Responce<GetLikeDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetLikeDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteLike(int id)
    {
        try
        {
            var find = await _context.Likes.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Likes.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetLikeDto>> GetLikeById(int id)
    {
        try
        {
            var find = await _context.Likes.FindAsync(id);
            if (find == null) return new Responce<GetLikeDto>(new GetLikeDto());
            var result = _mapper.Map<GetLikeDto>(find);
            return new Responce<GetLikeDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetLikeDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetLikeDto>>> GetLikes()
    {
        try
        {
            var model = _context.Likes.ToList();
            var result = _mapper.Map<List<GetLikeDto>>(model);
            return new Responce<List<GetLikeDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetLikeDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}