using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Hashtag
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public List<PostHashtag> PostHashtags { get; set; }
}