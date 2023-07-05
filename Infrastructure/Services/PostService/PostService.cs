using AutoMapper;
using Domain.Dtos.PostDtos;
using Domain.Entities;
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
    public async Task<GetPostDto> AddPost(AddPostDto post)
    {
        var model = _mapper.Map<Post>(post);
        await _context.Posts.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetPostDto>(model);
        return result;
    }

    public async Task<GetPostDto> UpdatePost(AddPostDto post)
    {
        var find = await _context.Posts.FindAsync(post.Id);
        _mapper.Map(post, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetPostDto>(find);
        return result;
    }

    public async Task<bool> DeletePost(int id)
    {
        var find = await _context.Posts.FindAsync(id);
        if (find == null) return false;
        _context.Posts.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetPostDto> GetPostById(int id)
    {
        var find = await _context.Posts.FindAsync(id);
        if (find == null) return new GetPostDto();
        var result = _mapper.Map<GetPostDto>(find);
        return result;
    }

    public async Task<List<GetPostDto>> GetPosts()
    {
        var model = _context.Posts.ToList();
        var result = _mapper.Map<List<GetPostDto>>(model);
        return result;
    }
}