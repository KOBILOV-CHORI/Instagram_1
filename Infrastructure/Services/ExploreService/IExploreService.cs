using Domain.Dtos.ExploreDtos;

namespace Infrastructure.Services.ExploreService;

public interface IExploreService
{
    public Task<GetExploreDto> AddExplore(AddExploreDto comment);
    public Task<GetExploreDto> UpdateExplore(AddExploreDto comment);
    public Task<bool> DeleteExplore(int id);
    public Task<GetExploreDto> GetExploreById(int id);
    public Task<List<GetExploreDto>> GetExplores();
}