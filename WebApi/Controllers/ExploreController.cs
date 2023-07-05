using Domain.Dtos.ExploreDtos;
using Infrastructure.Services.ExploreService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExploreController : ControllerBase
{
    private readonly ExploreService _service;

    public ExploreController(ExploreService service)
    {
        _service = service;
    }
    [HttpPost("AddExplore")]
    public async Task<GetExploreDto> AddExplore(AddExploreDto explore)
    {
        return await _service.AddExplore(explore);
    }
    [HttpPut("UpdateExplore")]
    public async Task<GetExploreDto> UpdateExplore(AddExploreDto explore)
    {
        return await _service.UpdateExplore(explore);
    }
    [HttpDelete("DeleteExplore")]
    public async Task<bool> DeleteExplore(int id)
    {
        return await _service.DeleteExplore(id);
    }
    [HttpGet("GetExploreById")]
    public async Task<GetExploreDto> GetExploreById(int id)
    {
        return await _service.GetExploreById(id);
    }
    [HttpGet("GetExplores")]
    public async Task<List<GetExploreDto>> GetExplores()
    {
        return await _service.GetExplores();
    }
}