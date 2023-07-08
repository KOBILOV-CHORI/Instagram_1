using System.Net;
using AutoMapper;
using Domain.Dtos.PostDtos;
using Domain.Dtos.SavedPostDtos;
using Domain.Entities;
using Domain.Wrapper;
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

    public async Task<Responce<GetSavedPostDto>> AddSavedPost(AddSavedPostDto savedPost)
    {
        try
        {
            var model = _mapper.Map<SavedPost>(savedPost);
            await _context.SavedPosts.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetSavedPostDto>(model);
            return new Responce<GetSavedPostDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetSavedPostDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetSavedPostDto>> UpdateSavedPost(AddSavedPostDto savedPost)
    {
        try
        {
            var find = await _context.SavedPosts.FindAsync(savedPost.Id);
            _mapper.Map(savedPost, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetSavedPostDto>(find);
            return new Responce<GetSavedPostDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetSavedPostDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteSavedPost(int id)
    {
        try
        {
            var find = await _context.SavedPosts.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.SavedPosts.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetSavedPostDto>> GetSavedPostById(int id)
    {
        try
        {
            var find = await _context.SavedPosts.FindAsync(id);
            if (find == null) return new Responce<GetSavedPostDto>(new GetSavedPostDto());
            var result = _mapper.Map<GetSavedPostDto>(find);
            return new Responce<GetSavedPostDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetSavedPostDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetSavedPostDto>>> GetSavedPosts()
    {
        try
        {
            var model = _context.SavedPosts.ToList();
            var result = _mapper.Map<List<GetSavedPostDto>>(model);
            return new Responce<List<GetSavedPostDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetSavedPostDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}