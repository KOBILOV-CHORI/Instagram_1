using Domain.Dtos.UserDtos;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    public Task<GetUserDto> AddUser(AddUserDto User);
    public Task<GetUserDto> UpdateUser(AddUserDto User);
    public Task<bool> DeleteUser(int id);
    public Task<GetUserDto> GetUserById(int id);
    public Task<List<GetUserDto>> GetUsers();
}