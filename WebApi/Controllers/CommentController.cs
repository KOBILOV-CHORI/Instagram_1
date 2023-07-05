using Domain.Dtos.CommentDtos;
using Domain.Wrapper;
using Infrastructure.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _service;

    public CommentController(CommentService service)
    {
        _service = service;
    }

    [HttpPost("AddComment")]
    public async Task<Responce<GetCommentDto>> AddComment(AddCommentDto comment)
    {
        return await _service.AddComment(comment);
    }
    [HttpPut("UpdateComment")]
    public async Task<Responce<GetCommentDto>> UpdateComment(AddCommentDto comment)
    {
        return await _service.UpdateComment(comment);
    }
    [HttpDelete("DeleteComment")]
    public async Task<Responce<bool>> DeleteComment(int id)
    {
        return await _service.DeleteComment(id);
    }
    [HttpGet("GetCommentById")]
    public async Task<Responce<GetCommentDto>> GetCommentById(int id)
    {
        return await _service.GetCommentById(id);
    }
    [HttpGet("GetComments")]
    public async Task<Responce<List<GetCommentDto>>> GetComments()
    {
        return await _service.GetComments();
    }
}