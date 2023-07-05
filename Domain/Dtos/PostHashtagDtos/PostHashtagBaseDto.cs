namespace Domain.Dtos.PostHashtagDtos;

public class PostHashtagBaseDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int HashtagId { get; set; }
}