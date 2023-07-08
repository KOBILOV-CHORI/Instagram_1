using System.Net;
using AutoMapper;
using Domain.Dtos.CommentDtos;
using Domain.Dtos.ExploreDtos;
using Domain.Dtos.FollowerDtos;
using Domain.Entities;
using Domain.Wrapper;
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

    public async Task<Responce<GetFollowerDto>> AddFollower(AddFollowerDto hashtag)
    {
        try
        {
            var model = _mapper.Map<Follower>(hashtag);
            await _context.Followers.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetFollowerDto>(model);
            return new Responce<GetFollowerDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetFollowerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetFollowerDto>> UpdateFollower(AddFollowerDto hashtag)
    {
        try
        {
            var find = await _context.Followers.FindAsync(hashtag.Id);
            _mapper.Map(hashtag, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetFollowerDto>(find);
            return new Responce<GetFollowerDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetFollowerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteFollower(int id)
    {
        try
        {
            var find = await _context.Followers.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Followers.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetFollowerDto>> GetFollowerById(int id)
    {
        try
        {
            var find = await _context.Followers.FindAsync(id);
            if (find == null) return new Responce<GetFollowerDto>(new GetFollowerDto());
            var result = _mapper.Map<GetFollowerDto>(find);
            return new Responce<GetFollowerDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetFollowerDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetFollowerDto>>> GetFollowers()
    {
        try
        {
            var model = _context.Followers.ToList();
            var result = _mapper.Map<List<GetFollowerDto>>(model);
            return new Responce<List<GetFollowerDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetFollowerDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}