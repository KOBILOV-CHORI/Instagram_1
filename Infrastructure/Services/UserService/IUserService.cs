using Domain.Dtos.UserDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    public Task<Responce<GetUserDto>> AddUser(AddUserDto User);
    public Task<Responce<GetUserDto>> UpdateUser(AddUserDto User);
    public Task<Responce<bool>> DeleteUser(int id);
    public Task<Responce<GetUserDto>> GetUserById(int id);
    public Task<Responce<List<GetUserDto>>> GetUsers();
}