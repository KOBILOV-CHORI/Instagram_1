using Domain.Dtos.StoryDtos;

namespace Infrastructure.Services.StoryService;

public interface IStoryService
{
    public Task<GetStoryDto> AddStory(AddStoryDto Story);
    public Task<GetStoryDto> UpdateStory(AddStoryDto Story);
    public Task<bool> DeleteStory(int id);
    public Task<GetStoryDto> GetStoryById(int id);
    public Task<List<GetStoryDto>> GetStories();
}