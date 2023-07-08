using Domain.Dtos.HashtagDtos;
using Infrastructure.Services.HashtagService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HashtagController : ControllerBase
{
    private readonly HashtagService _service;

    public HashtagController(HashtagService service)
    {
        _service = service;
    }
    [HttpPost("AddHashtag")]
    public async Task<IActionResult> AddHashtag(AddHashtagDto hashtag)
    {
        var result = await _service.AddHashtag(hashtag);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateHashtag")]
    public async Task<IActionResult> UpdateHashtag(AddHashtagDto hashtag)
    {
        var result = await _service.UpdateHashtag(hashtag);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteHashtag")]
    public async Task<IActionResult> DeleteHashtag(int id)
    {
        var result = await _service.DeleteHashtag(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetHashtagById")]
    public async Task<IActionResult> GetHashtagById(int id)
    {
        var result = await _service.GetHashtagById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetHashtags")]
    public async Task<IActionResult> GetHashtags()
    {
        var result = await _service.GetHashtags();
        return StatusCode((int)result.StatusCode, result);
    }
}