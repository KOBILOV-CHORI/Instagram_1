using System.Net;
using AutoMapper;
using Domain.Dtos.CommentDtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CommentService;

public class CommentService : ICommentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CommentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Responce<GetCommentDto>> AddComment(AddCommentDto comment)
    {
        try
        {
            var model = _mapper.Map<Comment>(comment);
            await _context.Comments.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetCommentDto>(model);
            return new Responce<GetCommentDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetCommentDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetCommentDto>> UpdateComment(AddCommentDto comment)
    {
        try
        {
            var find = await _context.Comments.FindAsync(comment.Id);
            _mapper.Map(comment, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetCommentDto>(find);
            return new Responce<GetCommentDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetCommentDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteComment(int id)
    {
        try
        {
            var find = await _context.Comments.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Comments.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetCommentDto>> GetCommentById(int id)
    {
        try
        {
            var find = await _context.Comments.FindAsync(id);
            if (find == null) return new Responce<GetCommentDto>(new GetCommentDto());
            var result = _mapper.Map<GetCommentDto>(find);
            return new Responce<GetCommentDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetCommentDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetCommentDto>>> GetComments()
    {
        try
        {
            var model = _context.Comments.ToList();
            var result = _mapper.Map<List<GetCommentDto>>(model);
            return new Responce<List<GetCommentDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetCommentDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}