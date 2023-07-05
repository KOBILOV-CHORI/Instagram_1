namespace Domain.Dtos.PostDtos;

public class PostBaseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Media { get; set; }
    public string Caption { get; set; }
    public int LikeCount { get; set; }
    public DateTime CreateDate { get; set; }
}