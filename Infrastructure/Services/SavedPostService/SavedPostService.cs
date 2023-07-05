using AutoMapper;
using Domain.Dtos.SavedPostDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.SavedPostService;

public class SavedPostService : ISavedPostService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SavedPostService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetSavedPostDto> AddSavedPost(AddSavedPostDto savedPost)
    {
        var model = _mapper.Map<SavedPost>(savedPost);
        await _context.SavedPosts.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetSavedPostDto>(model);
        return result;
    }

    public async Task<GetSavedPostDto> UpdateSavedPost(AddSavedPostDto savedPost)
    {
        var find = await _context.SavedPosts.FindAsync(savedPost.Id);
        _mapper.Map(savedPost, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetSavedPostDto>(find);
        return result;
    }

    public async Task<bool> DeleteSavedPost(int id)
    {
        var find = await _context.SavedPosts.FindAsync(id);
        if (find == null) return false;
        _context.SavedPosts.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetSavedPostDto> GetSavedPostById(int id)
    {
        var find = await _context.SavedPosts.FindAsync(id);
        if (find == null) return new GetSavedPostDto();
        var result = _mapper.Map<GetSavedPostDto>(find);
        return result;
    }

    public async Task<List<GetSavedPostDto>> GetSavedPosts()
    {
        var model = _context.SavedPosts.ToList();
        var result = _mapper.Map<List<GetSavedPostDto>>(model);
        return result;
    }
}