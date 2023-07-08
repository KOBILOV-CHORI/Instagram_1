using Domain.Dtos.ExploreDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.ExploreService;

public interface IExploreService
{
    public Task<Responce<GetExploreDto>> AddExplore(AddExploreDto comment);
    public Task<Responce<GetExploreDto>> UpdateExplore(AddExploreDto comment);
    public Task<Responce<bool>> DeleteExplore(int id);
    public Task<Responce<GetExploreDto>> GetExploreById(int id);
    public Task<Responce<List<GetExploreDto>>> GetExplores();
}