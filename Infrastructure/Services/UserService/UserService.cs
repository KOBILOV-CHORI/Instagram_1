using AutoMapper;
using Domain.Dtos.UserDtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetUserDto> AddUser(AddUserDto user)
    {
        user.CreateDate = DateTime.SpecifyKind(user.CreateDate, DateTimeKind.Utc);
        user.CreateDate = DateTime.Now;
        var model = _mapper.Map<User>(user);
        await _context.Users.AddAsync(model);
        await _context.SaveChangesAsync();
        var result = _mapper.Map<GetUserDto>(model);
        return result;
    }

    public async Task<GetUserDto> UpdateUser(AddUserDto user)
    {
        var find = await _context.Users.FindAsync(user.Id);
        _mapper.Map(user, find);
        _context.Entry(find).State = EntityState.Modified;
        var result = _mapper.Map<GetUserDto>(find);
        return result;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var find = await _context.Users.FindAsync(id);
        if (find == null) return false;
        _context.Users.Remove(find);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<GetUserDto> GetUserById(int id)
    {
        var find = await _context.Users.FindAsync(id);
        if (find == null) return new GetUserDto();
        var result = _mapper.Map<GetUserDto>(find);
        return result;
    }

    public async Task<List<GetUserDto>> GetUsers()
    {
        var model = _context.Users.ToList();
        var result = _mapper.Map<List<GetUserDto>>(model);
        return result;
    }
}