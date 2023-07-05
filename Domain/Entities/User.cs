using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class User
{
    [Key] public int Id { get; set; }
    [MaxLength(50)] public string FullName { get; set; }
    [MaxLength(50)] public string UserName { get; set; }
    [MaxLength(100)] public string Email { get; set; }
    [MaxLength(30)] public string Password { get; set; }
    [MaxLength(150)] public string AboutMe { get; set; }
    public string ProfileImage { get; set; }
    [Required] public DateTime CreateDate { get; set; }
    [Required] public Gender Gender { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
    [InverseProperty("User")]
    public List<Follower> Users { get; set; }
    [InverseProperty("FollowerUser")]
    public List<Follower> Followers { get; set; }
    public List<Notification> Notifications { get; set; }
    [InverseProperty("Sender")]
    public List<DirectMessage> SentDirectMessages { get; set; }
    [InverseProperty("Receiver")]
    public List<DirectMessage> ReceivedDirectMessages { get; set; }
    public List<Story> Stories { get; set; }
    public List<SavedPost> SavedPosts { get; set; }
}