namespace BlogAPI.Domain;

public class BaseEntity
{
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; set; } = default!;
    public DateTime UpdatedDate { get; set;} = default!;
}