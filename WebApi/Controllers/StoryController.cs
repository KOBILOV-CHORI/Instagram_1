using Domain.Dtos.StoryDtos;
using Infrastructure.Services.StoryService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StoryController : ControllerBase
{
    private readonly StoryService _service;

    public StoryController(StoryService service)
    {
        _service = service;
    }
    [HttpPost("AddStory")]
    public async Task<IActionResult> AddStory(AddStoryDto story)
    {
        var result = await _service.AddStory(story);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateStory")]
    public async Task<IActionResult> UpdateStory(AddStoryDto story)
    {
        var result = await _service.UpdateStory(story);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteStory")]
    public async Task<IActionResult> DeleteStory(int id)
    {
        var result = await _service.DeleteStory(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetStoryById")]
    public async Task<IActionResult> GetStoryById(int id)
    {
        var result = await _service.GetStoryById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetStorys")]
    public async Task<IActionResult> GetStories()
    {
        var result = await _service.GetStories();
        return StatusCode((int)result.StatusCode, result);
    }
}