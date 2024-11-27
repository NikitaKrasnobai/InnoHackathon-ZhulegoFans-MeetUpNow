using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class DocumentationConfiguration : IEntityTypeConfiguration<Documentation>
{
    public void Configure(EntityTypeBuilder<Documentation> builder)
    {
        builder.ToTable("Documentations");

        builder.HasKey(d => d.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(d => d.DateTime)
            .IsRequired();

        builder.HasMany(d => d.Employees)
            .WithMany(e => e.Documentations)
            .UsingEntity(j => j.ToTable("DocumentationEmployees"));
    }
}
