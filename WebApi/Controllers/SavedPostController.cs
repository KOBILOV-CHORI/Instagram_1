using Domain.Dtos.SavedPostDtos;
using Infrastructure.Services.SavedPostService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SavedPostController : ControllerBase
{
    private readonly SavedPostService _service;

    public SavedPostController(SavedPostService service)
    {
        _service = service;
    }
    [HttpPost("AddSavedPost")]
    public async Task<IActionResult> AddSavedPost(AddSavedPostDto savedPost)
    {
        var result = await _service.AddSavedPost(savedPost);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateSavedPost")]
    public async Task<IActionResult> UpdateSavedPost(AddSavedPostDto savedPost)
    {
        var result = await _service.UpdateSavedPost(savedPost);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteSavedPost")]
    public async Task<IActionResult> DeleteSavedPost(int id)
    {
        var result = await _service.DeleteSavedPost(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetSavedPostById")]
    public async Task<IActionResult> GetSavedPostById(int id)
    {
        var result = await _service.GetSavedPostById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetSavedPosts")]
    public async Task<IActionResult> GetSavedPosts()
    {
        var result = await _service.GetSavedPosts();
        return StatusCode((int)result.StatusCode, result);
    }
}