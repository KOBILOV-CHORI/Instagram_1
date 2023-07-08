using Domain.Dtos.CommentDtos;
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
    public async Task<IActionResult> AddComment(AddCommentDto comment)
    {
        var result = await _service.AddComment(comment);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateComment")]
    public async Task<IActionResult> UpdateComment(AddCommentDto comment)
    {
        var result = await _service.UpdateComment(comment);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteComment")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var result = await _service.DeleteComment(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetCommentById")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var result = await _service.GetCommentById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetComments")]
    public async Task<IActionResult> GetComments()
    {
        var result = await _service.GetComments();
        return StatusCode((int)result.StatusCode, result);
    }
}