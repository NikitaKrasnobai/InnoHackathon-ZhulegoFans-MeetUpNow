using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

public class RepositoryDbContext : DbContext
    {
        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Organization> Organizations { get; set; }
        public required DbSet<Documentation> Documentations { get; set; }

        public RepositoryDbContext(DbContextOptions options)
        : base(options)
        {
        InitializeDatabase();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentationConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizationConfiguration).Assembly);

        }
        public void InitializeDatabase()
            {
                string sqlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "OrganizationService.sql");
                 ApplySqlFile(sqlFilePath);
            }

        private void ApplySqlFile(string path)
            {
                var sql = File.ReadAllText(path);
                Database.ExecuteSqlRaw(sql);
            }
    }