using Domain.Dtos.StoryDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.StoryService;

public interface IStoryService
{
    public Task<Responce<GetStoryDto>> AddStory(AddStoryDto Story);
    public Task<Responce<GetStoryDto>> UpdateStory(AddStoryDto Story);
    public Task<Responce<bool>> DeleteStory(int id);
    public Task<Responce<GetStoryDto>> GetStoryById(int id);
    public Task<Responce<List<GetStoryDto>>> GetStories();
}