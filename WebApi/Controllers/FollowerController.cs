using Domain.Dtos.FollowerDtos;
using Infrastructure.Services.FollowerService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FollowerController : ControllerBase
{
    private readonly FollowerService _service;

    public FollowerController(FollowerService service)
    {
        _service = service;
    }
    [HttpPost("AddFollower")]
    public async Task<IActionResult> AddFollower(AddFollowerDto follower)
    {
        var result = await _service.AddFollower(follower);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateFollower")]
    public async Task<IActionResult> UpdateFollower(AddFollowerDto follower)
    {
        var result = await _service.UpdateFollower(follower);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteFollower")]
    public async Task<IActionResult> DeleteFollower(int id)
    {
        var result = await _service.DeleteFollower(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetFollowerById")]
    public async Task<IActionResult> GetFollowerById(int id)
    {
        var result = await _service.GetFollowerById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetFollowers")]
    public async Task<IActionResult> GetFollowers()
    {
        var result = await _service.GetFollowers();
        return StatusCode((int)result.StatusCode, result);
    }
}