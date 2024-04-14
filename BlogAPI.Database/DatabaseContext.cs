namespace BlogAPI.Database;

using Npgsql;
using Microsoft.EntityFrameworkCore;

using BlogAPI.Domain;

public class DatabaseContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<Role>();
        modelBuilder.Entity<User>()
            .HasMany(e => e.Blogs)
            .WithOne(e => e.User);
        modelBuilder.Entity<Blog>()
            .HasMany(e => e.Comments)
            .WithOne(e => e.Blog);
        modelBuilder.Entity<Comment>()
            .HasOne(e => e.User);
    }

}
