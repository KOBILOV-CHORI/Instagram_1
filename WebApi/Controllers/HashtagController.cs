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
    public async Task<GetHashtagDto> AddHashtag(AddHashtagDto hashtag)
    {
        return await _service.AddHashtag(hashtag);
    }
    [HttpPut("UpdateHashtag")]
    public async Task<GetHashtagDto> UpdateHashtag(AddHashtagDto hashtag)
    {
        return await _service.UpdateHashtag(hashtag);
    }
    [HttpDelete("DeleteHashtag")]
    public async Task<bool> DeleteHashtag(int id)
    {
        return await _service.DeleteHashtag(id);
    }
    [HttpGet("GetHashtagById")]
    public async Task<GetHashtagDto> GetHashtagById(int id)
    {
        return await _service.GetHashtagById(id);
    }
    [HttpGet("GetHashtags")]
    public async Task<List<GetHashtagDto>> GetHashtags()
    {
        return await _service.GetHashtags();
    }
}