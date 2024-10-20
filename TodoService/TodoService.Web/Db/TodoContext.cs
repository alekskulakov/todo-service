using Microsoft.EntityFrameworkCore;

namespace TodoService.Web.Db;

public class TodoContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().ToTable("Todos");
        
        modelBuilder.Entity<Todo>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        modelBuilder.Entity<Todo>()
            .Property(e => e.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
            .ValueGeneratedOnAddOrUpdate();
        
        modelBuilder.Entity<Todo>()
            .HasQueryFilter(e => !e.IsDeleted);

        modelBuilder.Entity<Todo>()
            .HasData(
                Enumerable.Range(1, 13).Select(i => new Todo
                {
                    IsDeleted = false,
                    Id = i,
                    Title = $"Title {i}",
                    Description = $"Description {i}"
                }));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entity in modifiedEntities)
        {
            entity.Property("UpdatedAt").CurrentValue = DateTime.Now;
        }

        var deletedEntities = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Deleted);

        foreach (var entity in deletedEntities)
        {
            entity.State = EntityState.Modified;
            entity.Property("DeletedAt").CurrentValue = DateTime.Now;
            entity.Property("IsDeleted").CurrentValue = true;
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}