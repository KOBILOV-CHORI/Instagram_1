using Domain.Dtos.PostHashtagDtos;
using Infrastructure.Services.PostHashtagService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PostHashtagController : ControllerBase
{
    private readonly PostHashtagService _service;

    public PostHashtagController(PostHashtagService service)
    {
        _service = service;
    }
    [HttpPost("AddPostHashtag")]
    public async Task<GetPostHashtagDto> AddPostHashtag(AddPostHashtagDto postHashtag)
    {
        return await _service.AddPostHashtag(postHashtag);
    }
    [HttpPut("UpdatePostHashtag")]
    public async Task<GetPostHashtagDto> UpdatePostHashtag(AddPostHashtagDto postHashtag)
    {
        return await _service.UpdatePostHashtag(postHashtag);
    }
    [HttpDelete("DeletePostHashtag")]
    public async Task<bool> DeletePostHashtag(int id)
    {
        return await _service.DeletePostHashtag(id);
    }
    [HttpGet("GetPostHashtagById")]
    public async Task<GetPostHashtagDto> GetPostHashtagById(int id)
    {
        return await _service.GetPostHashtagById(id);
    }
    [HttpGet("GetPostHashtags")]
    public async Task<List<GetPostHashtagDto>> GetPostHashtags()
    {
        return await _service.GetPostHashtags();
    }
}