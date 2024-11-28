using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

public class RepositoryDbContext : DbContext
{
    public required DbSet<Event> Events { get; set; }
    public required DbSet<Purpose> Purposes { get; set; }
    public required DbSet<Place> Places { get; set; }
    public required DbSet<EventsTable> EventsTables { get; set; }

    public RepositoryDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlaceConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PurposeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventsTableConfiguration).Assembly);

        ApplySqlFile("EventService.sql");
    }

    private void ApplySqlFile(string path)
    {
        var sql = File.ReadAllText(path);
        Database.ExecuteSqlRaw(sql);
    }
}