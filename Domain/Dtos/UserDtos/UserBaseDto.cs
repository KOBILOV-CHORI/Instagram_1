namespace Domain.Dtos.UserDtos;

public class UserBaseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AboutMe { get; set; }
    public string ProfileImage { get; set; }
    public string Gender { get; set; }
    public DateTime CreateDate { get; set; }
}