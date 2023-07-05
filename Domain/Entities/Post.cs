using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Post
{
    [Key] public int Id { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; }
    public string Media { get; set; }
    [MaxLength(100)] public string Caption { get; set; }
    public int LikeCount { get; set; }
    [Required] public DateTime CreateDate { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
    public List<PostHashtag> PostHashtags { get; set; }
    public List<SavedPost> SavedPosts { get; set; }
    public List<Explore> Explores { get; set; }
}