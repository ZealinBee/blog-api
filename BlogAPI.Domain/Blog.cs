using System.Reflection;

namespace BlogAPI.Domain;

public class Blog : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public User User { get; set; } = default!;
    public List<Comment> Comments { get; set; } = new List<Comment>();
}