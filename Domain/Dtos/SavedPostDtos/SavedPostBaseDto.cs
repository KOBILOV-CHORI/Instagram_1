namespace Domain.Dtos.SavedPostDtos;

public class SavedPostBaseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public DateTime CreateDate { get; set; }
}