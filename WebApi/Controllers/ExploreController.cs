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
    public async Task<IActionResult> AddExplore(AddExploreDto explore)
    {
        var result = await _service.AddExplore(explore);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateExplore")]
    public async Task<IActionResult> UpdateExplore(AddExploreDto explore)
    {
        var result = await _service.UpdateExplore(explore);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteExplore")]
    public async Task<IActionResult> DeleteExplore(int id)
    {
        var result = await _service.DeleteExplore(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetExploreById")]
    public async Task<IActionResult> GetExploreById(int id)
    {
        var result = await _service.GetExploreById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetExplores")]
    public async Task<IActionResult> GetExplores()
    {
        var result = await _service.GetExplores();
        return StatusCode((int)result.StatusCode, result);
    }
}