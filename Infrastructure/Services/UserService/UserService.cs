using System.Net;
using AutoMapper;
using Domain.Dtos.UserDtos;
using Domain.Entities;
using Domain.Filters;
using Domain.Wrapper;
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

    public async Task<Responce<GetUserDto>> AddUser(AddUserDto user)
    {
        try
        {
            user.CreateDate = DateTime.SpecifyKind(user.CreateDate, DateTimeKind.Utc);
            user.CreateDate = DateTime.UtcNow;
            var model = _mapper.Map<User>(user);
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<GetUserDto>(model);
            return new Responce<GetUserDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetUserDto>> UpdateUser(AddUserDto user)
    {
        try
        {
            var find = await _context.Users.FindAsync(user.Id);
            _mapper.Map(user, find);
            _context.Entry(find).State = EntityState.Modified;
            var result = _mapper.Map<GetUserDto>(find);
            return new Responce<GetUserDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<bool>> DeleteUser(int id)
    {
        try
        {
            var find = await _context.Users.FindAsync(id);
            if (find == null) return new Responce<bool>(false);
            _context.Users.Remove(find);
            await _context.SaveChangesAsync();
            return new Responce<bool>(true);
        }
        catch (Exception e)
        {
            return new Responce<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<GetUserDto>> GetUserById(int id)
    {
        try
        {
            var find = await _context.Users.FindAsync(id);
            if (find == null) return new Responce<GetUserDto>(new GetUserDto());
            var result = _mapper.Map<GetUserDto>(find);
            return new Responce<GetUserDto>(result);
        }
        catch (Exception e)
        {
            return new Responce<GetUserDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responce<List<GetUserDto>>> GetUsers()
    {
        try
        {
            var model = _context.Users.ToList();
            var result = _mapper.Map<List<GetUserDto>>(model);
            return new Responce<List<GetUserDto>>(result);
        }
        catch (Exception e)
        {
            return new Responce<List<GetUserDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<PagedResponce<List<GetUserDto>>> GetUsersByFilter(GetUserFilter filter)
    {
        var filters = new PaginationFilter(filter.PageNumber, filter.PageSize);
        var model = _context.Users.AsQueryable();
        if (string.IsNullOrEmpty(filter.UserName) == false)
        {
            model = model.Where(x => x.UserName.ToLower().Contains(filter.UserName.ToLower()));
        }

        var list = _mapper.Map<List<GetUserDto>>(model);
        var result = list.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).ToList();
        var totalRecords = result.Count();
        return new PagedResponce<List<GetUserDto>>(result, totalRecords, filter.PageNumber, filter.PageSize);
    }
}