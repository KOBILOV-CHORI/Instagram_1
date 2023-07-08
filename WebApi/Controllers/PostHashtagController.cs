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
    public async Task<IActionResult> AddPostHashtag(AddPostHashtagDto postHashtag)
    {
        var result = await _service.AddPostHashtag(postHashtag);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdatePostHashtag")]
    public async Task<IActionResult> UpdatePostHashtag(AddPostHashtagDto postHashtag)
    {
        var result = await _service.UpdatePostHashtag(postHashtag);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeletePostHashtag")]
    public async Task<IActionResult> DeletePostHashtag(int id)
    {
        var result = await _service.DeletePostHashtag(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetPostHashtagById")]
    public async Task<IActionResult> GetPostHashtagById(int id)
    {
        var result = await _service.GetPostHashtagById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetPostHashtags")]
    public async Task<IActionResult> GetPostHashtags()
    {
        var result = await _service.GetPostHashtags();
        return StatusCode((int)result.StatusCode, result);
    }
}