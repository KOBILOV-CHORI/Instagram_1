using Domain.Dtos.LikeDtos;
using Infrastructure.Services.LikeService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : ControllerBase
{
    private readonly LikeService _service;

    public LikeController(LikeService service)
    {
        _service = service;
    }
    [HttpPost("AddLike")]
    public async Task<IActionResult> AddLike(AddLikeDto like)
    {
        var result = await _service.AddLike(like);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateLike")]
    public async Task<IActionResult> UpdateLike(AddLikeDto like)
    {
        var result = await _service.UpdateLike(like);
        return StatusCode((int)result.StatusCode, result);

    }
    [HttpDelete("DeleteLike")]
    public async Task<IActionResult> DeleteLike(int id)
    {
        var result = await _service.DeleteLike(id);
        return StatusCode((int)result.StatusCode, result);

    }
    [HttpGet("GetLikeById")]
    public async Task<IActionResult> GetLikeById(int id)
    {
        var result = await _service.GetLikeById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetLikes")]
    public async Task<IActionResult> GetLikes()
    {
        var result = await _service.GetLikes();
        return StatusCode((int)result.StatusCode, result);
    }
}