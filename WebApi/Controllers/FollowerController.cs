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
    public async Task<GetFollowerDto> AddFollower(AddFollowerDto follower)
    {
        return await _service.AddFollower(follower);
    }
    [HttpPut("UpdateFollower")]
    public async Task<GetFollowerDto> UpdateFollower(AddFollowerDto follower)
    {
        return await _service.UpdateFollower(follower);
    }
    [HttpDelete("DeleteFollower")]
    public async Task<bool> DeleteFollower(int id)
    {
        return await _service.DeleteFollower(id);
    }
    [HttpGet("GetFollowerById")]
    public async Task<GetFollowerDto> GetFollowerById(int id)
    {
        return await _service.GetFollowerById(id);
    }
    [HttpGet("GetFollowers")]
    public async Task<List<GetFollowerDto>> GetFollowers()
    {
        return await _service.GetFollowers();
    }
}