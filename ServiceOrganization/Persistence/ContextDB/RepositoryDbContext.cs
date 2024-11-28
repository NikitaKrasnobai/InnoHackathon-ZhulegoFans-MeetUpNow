using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.ContextDB
{
    public class RepositoryDbContext : DbContext
    {
        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Organization> Organizations { get; set; }
        public required DbSet<Documentation> Documentations { get; set; }

        public RepositoryDbContext(DbContextOptions options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentationConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationConfiguration).Assembly);
        }
    }
}
