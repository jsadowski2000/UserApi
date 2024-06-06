using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(e => e.Role)
            .HasConversion<string>();

        modelBuilder
            .Entity<User>()
            .Property(e => e.Status)
            .HasConversion<string>();
    }

}

