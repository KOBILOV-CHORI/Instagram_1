using AutoMapper;
using Domain.Dtos.PostHashtagDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PostHashtagService;

public class PostHashtagService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostHashtagService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetPostHashtagDto> AddPostHashtag(AddPostHashtagDto postHashtag)
    {
        var model = _mapper.Map<PostHashtag>(postHashtag);
        await _context.PostHashtags.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetPostHashtagDto>(model);
        return result;
    }

    public async Task<GetPostHashtagDto> UpdatePostHashtag(AddPostHashtagDto postHashtag)
    {
        var find = await _context.PostHashtags.FindAsync(postHashtag.Id);
        _mapper.Map(postHashtag, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetPostHashtagDto>(find);
        return result;
    }

    public async Task<bool> DeletePostHashtag(int id)
    {
        var find = await _context.PostHashtags.FindAsync(id);
        if (find == null) return false;
        _context.PostHashtags.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetPostHashtagDto> GetPostHashtagById(int id)
    {
        var find = await _context.PostHashtags.FindAsync(id);
        if (find == null) return new GetPostHashtagDto();
        var result = _mapper.Map<GetPostHashtagDto>(find);
        return result;
    }

    public async Task<List<GetPostHashtagDto>> GetPostHashtags()
    {
        var model = _context.PostHashtags.ToList();
        var result = _mapper.Map<List<GetPostHashtagDto>>(model);
        return result;
    }
}