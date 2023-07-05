using Domain.Dtos.UserDtos;
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
    public async Task<GetUserDto> AddUser([FromForm]AddUserDto user)
    {
        return await _service.AddUser(user);
    }
    [HttpPut("UpdateUser")]
    public async Task<GetUserDto> UpdateUser([FromForm]AddUserDto user)
    {
        return await _service.UpdateUser(user);
    }
    [HttpDelete("DeleteUser")]
    public async Task<bool> DeleteUser(int id)
    {
        return await _service.DeleteUser(id);
    }
    [HttpGet("GetUserById")]
    public async Task<GetUserDto> GetUserById(int id)
    {
        return await _service.GetUserById(id);
    }
    [HttpGet("GetUsers")]
    public async Task<List<GetUserDto>> GetUsers()
    {
        return await _service.GetUsers();
    }
}