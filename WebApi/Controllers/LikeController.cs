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
    public async Task<GetLikeDto> AddLike(AddLikeDto like)
    {
        return await _service.AddLike(like);
    }
    [HttpPut("UpdateLike")]
    public async Task<GetLikeDto> UpdateLike(AddLikeDto like)
    {
        return await _service.UpdateLike(like);
    }
    [HttpDelete("DeleteLike")]
    public async Task<bool> DeleteLike(int id)
    {
        return await _service.DeleteLike(id);
    }
    [HttpGet("GetLikeById")]
    public async Task<GetLikeDto> GetLikeById(int id)
    {
        return await _service.GetLikeById(id);
    }
    [HttpGet("GetLikes")]
    public async Task<List<GetLikeDto>> GetLikes()
    {
        return await _service.GetLikes();
    }
}