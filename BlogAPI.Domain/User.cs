namespace BlogAPI.Domain;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;
    public Role Role { get; set; } = Role.USER;
    public List<Blog> Blogs { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
}

public enum Role
{
    ADMIN,
    USER
}