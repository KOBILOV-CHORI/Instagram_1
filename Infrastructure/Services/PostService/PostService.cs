using System.Net;
using AutoMapper;
using Domain.Dtos.PostDtos;
using Domain.Dtos.PostHashtagDtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PostService;

public class PostService : IPostService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Responce<GetPostDto>> AddPost(AddPostDto post)
    {
        try
        {
            var model = _mapper.Map<Post>(post);
            await _context.Posts.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetPostDto>(model);
            return new Responce<GetPostDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetPostDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetPostDto>> UpdatePost(AddPostDto post)
    {
        try
        {
            var find = await _context.Posts.FindAsync(post.Id);
            _mapper.Map(post, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetPostDto>(find);
            return new Responce<GetPostDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetPostDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeletePost(int id)
    {
        try
        {
            var find = await _context.Posts.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Posts.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetPostDto>> GetPostById(int id)
    {
        try
        {
            var find = await _context.Posts.FindAsync(id);
            if (find == null) return new Responce<GetPostDto>(new GetPostDto());
            var result = _mapper.Map<GetPostDto>(find);
            return new Responce<GetPostDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetPostDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetPostDto>>> GetPosts()
    {
        try
        {
            var model = _context.Posts.ToList();
            var result = _mapper.Map<List<GetPostDto>>(model);
            return new Responce<List<GetPostDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetPostDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}