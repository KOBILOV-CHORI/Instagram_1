using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Follower
{
    [Key] public int Id { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("FollowerUser")] public int FollowerUserId { get; set; }
    public User FollowerUser { get; set; }
}