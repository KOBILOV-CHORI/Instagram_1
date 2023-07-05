using Domain.Dtos.HashtagDtos;

namespace Infrastructure.Services.HashtagService;

public interface IHashtagService
{
    public Task<GetHashtagDto> AddHashtag(AddHashtagDto comment);
    public Task<GetHashtagDto> UpdateHashtag(AddHashtagDto comment);
    public Task<bool> DeleteHashtag(int id);
    public Task<GetHashtagDto> GetHashtagById(int id);
    public Task<List<GetHashtagDto>> GetHashtags();
}