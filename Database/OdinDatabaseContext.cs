using FVA.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FVA.Database;

public class OdinDatabaseContext(
    DbContextOptions
        <OdinDatabaseContext> options) : DbContext(options)
{
    public DbSet<TestModel> TestModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestModel>().Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow);
        modelBuilder.Entity<TestModel>().Property(x => x.UpdatedAt).HasDefaultValue(DateTime.UtcNow);
        modelBuilder.Entity<TestModel>().Property(x => x.DeletedAt).HasDefaultValue(null);
        modelBuilder.Entity<TestModel>().Property(x => x.Deleted).HasDefaultValue(false);
        base.OnModelCreating(modelBuilder);
    }
}