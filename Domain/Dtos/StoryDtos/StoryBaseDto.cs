namespace Domain.Dtos.StoryDtos;

public class StoryBaseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Media { get; set; }
    public DateTime ExpirationDate { get; set; }
}