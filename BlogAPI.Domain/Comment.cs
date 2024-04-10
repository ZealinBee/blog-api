namespace BlogAPI.Domain;

public class Comment : BaseEntity
{
    public string Content { get; set; } = default!;
    public Blog Blog { get; set; } = default!;
    public User User { get; set; } = default!;
}