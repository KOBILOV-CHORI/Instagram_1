using System.Net;
using AutoMapper;
using Domain.Dtos.PostHashtagDtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PostHashtagService;

public class PostHashtagService : IPostHashtagService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PostHashtagService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Responce<GetPostHashtagDto>> AddPostHashtag(AddPostHashtagDto postHashtag)
    {
        try
        {
            var model = _mapper.Map<PostHashtag>(postHashtag);
            await _context.PostHashtags.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetPostHashtagDto>(model);
            return new Responce<GetPostHashtagDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetPostHashtagDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetPostHashtagDto>> UpdatePostHashtag(AddPostHashtagDto postHashtag)
    {
        try
        {
            var find = await _context.PostHashtags.FindAsync(postHashtag.Id);
            _mapper.Map(postHashtag, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetPostHashtagDto>(find);
            return new Responce<GetPostHashtagDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetPostHashtagDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeletePostHashtag(int id)
    {
        try
        {
            var find = await _context.PostHashtags.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.PostHashtags.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetPostHashtagDto>> GetPostHashtagById(int id)
    {
        try
        {
            var find = await _context.PostHashtags.FindAsync(id);
            if (find == null) return new Responce<GetPostHashtagDto>(new GetPostHashtagDto());
            var result = _mapper.Map<GetPostHashtagDto>(find);
            return new Responce<GetPostHashtagDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetPostHashtagDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetPostHashtagDto>>> GetPostHashtags()
    {
        try
        {
            var model = _context.PostHashtags.ToList();
            var result = _mapper.Map<List<GetPostHashtagDto>>(model);
            return new Responce<List<GetPostHashtagDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetPostHashtagDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}