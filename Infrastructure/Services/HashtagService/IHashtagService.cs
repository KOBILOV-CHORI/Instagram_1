using Domain.Dtos.HashtagDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.HashtagService;

public interface IHashtagService
{
    public Task<Responce<GetHashtagDto>> AddHashtag(AddHashtagDto comment);
    public Task<Responce<GetHashtagDto>> UpdateHashtag(AddHashtagDto comment);
    public Task<Responce<bool>> DeleteHashtag(int id);
    public Task<Responce<GetHashtagDto>> GetHashtagById(int id);
    public Task<Responce<List<GetHashtagDto>>> GetHashtags();
}