using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<SavedPost> SavedPosts { get; set; }
    public DbSet<PostHashtag> PostHashtags { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<Explore> Explores { get; set; }
    public DbSet<DirectMessage> DirectMessages { get; set; }
    public DbSet<Comment> Comments { get; set; }
}