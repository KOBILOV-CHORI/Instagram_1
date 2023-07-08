using Domain.Dtos.UserDtos;
using Domain.Filters;
using Domain.Wrapper;
using Infrastructure.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }
    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser([FromForm]AddUserDto user)
    {
        var result = await _service.AddUser(user);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromForm]AddUserDto user)
    {
        var result = await _service.UpdateUser(user);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _service.DeleteUser(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _service.GetUserById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var result = await _service.GetUsers();
        return StatusCode((int)result.StatusCode, result);
    }

    [HttpGet("GetUsersByFilter")]
    public async Task<PagedResponce<List<GetUserDto>>> GetUsersByFilter([FromQuery]GetUserFilter filter)
    {
        return await _service.GetUsersByFilter(filter);
    }
}