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
    public async Task<GetStoryDto> AddStory(AddStoryDto story)
    {
        return await _service.AddStory(story);
    }
    [HttpPut("UpdateStory")]
    public async Task<GetStoryDto> UpdateStory(AddStoryDto story)
    {
        return await _service.UpdateStory(story);
    }
    [HttpDelete("DeleteStory")]
    public async Task<bool> DeleteStory(int id)
    {
        return await _service.DeleteStory(id);
    }
    [HttpGet("GetStoryById")]
    public async Task<GetStoryDto> GetStoryById(int id)
    {
        return await _service.GetStoryById(id);
    }
    [HttpGet("GetStorys")]
    public async Task<List<GetStoryDto>> GetStories()
    {
        return await _service.GetStories();
    }
}