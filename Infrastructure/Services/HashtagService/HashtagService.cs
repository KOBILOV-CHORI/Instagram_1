using System.Net;
using AutoMapper;
using Domain.Dtos.HashtagDtos;
using Domain.Entities;
using Domain.Wrapper;
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

    public async Task<Responce<GetHashtagDto>> AddHashtag(AddHashtagDto hashtag)
    {
        try
        {
            var model = _mapper.Map<Hashtag>(hashtag);
            await _context.Hashtags.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetHashtagDto>(model);
            return new Responce<GetHashtagDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetHashtagDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetHashtagDto>> UpdateHashtag(AddHashtagDto hashtag)
    {
        try
        {
            var find = await _context.Hashtags.FindAsync(hashtag.Id);
            _mapper.Map(hashtag, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetHashtagDto>(find);
            return new Responce<GetHashtagDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetHashtagDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteHashtag(int id)
    {
        try
        {
            var find = await _context.Hashtags.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Hashtags.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetHashtagDto>> GetHashtagById(int id)
    {
        try
        {
            var find = await _context.Hashtags.FindAsync(id);
            if (find == null) return new Responce<GetHashtagDto>(new GetHashtagDto());
            var result = _mapper.Map<GetHashtagDto>(find);
            return new Responce<GetHashtagDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetHashtagDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetHashtagDto>>> GetHashtags()
    {
        try
        {
            var model = _context.Hashtags.ToList();
            var result = _mapper.Map<List<GetHashtagDto>>(model);
            return new Responce<List<GetHashtagDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetHashtagDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}