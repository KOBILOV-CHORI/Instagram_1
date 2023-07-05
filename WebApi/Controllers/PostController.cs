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
    public async Task<GetPostDto> AddPost(AddPostDto post)
    {
        return await _service.AddPost(post);
    }
    [HttpPut("UpdatePost")]
    public async Task<GetPostDto> UpdatePost(AddPostDto post)
    {
        return await _service.UpdatePost(post);
    }
    [HttpDelete("DeletePost")]
    public async Task<bool> DeletePost(int id)
    {
        return await _service.DeletePost(id);
    }
    [HttpGet("GetPostById")]
    public async Task<GetPostDto> GetPostById(int id)
    {
        return await _service.GetPostById(id);
    }
    [HttpGet("GetPosts")]
    public async Task<List<GetPostDto>> GetPosts()
    {
        return await _service.GetPosts();
    }
}