using Domain.Dtos.PostDtos;
using Infrastructure.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly PostService _service;

    public PostController(PostService service)
    {
        _service = service;
    }
    [HttpPost("AddPost")]
    public async Task<IActionResult> AddPost(AddPostDto post)
    {
        var result = await _service.AddPost(post);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdatePost")]
    public async Task<IActionResult> UpdatePost(AddPostDto post)
    {
        var result = await _service.UpdatePost(post);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeletePost")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var result = await _service.DeletePost(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetPostById")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var result = await _service.GetPostById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetPosts")]
    public async Task<IActionResult> GetPosts()
    {
        var result = await _service.GetPosts();
        return StatusCode((int)result.StatusCode, result);
    }
}