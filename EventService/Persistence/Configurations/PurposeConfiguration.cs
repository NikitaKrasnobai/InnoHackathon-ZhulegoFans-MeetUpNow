using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class PurposeConfiguration : IEntityTypeConfiguration<Purpose>
{
    public void Configure(EntityTypeBuilder<Purpose> builder)
    {
        builder.ToTable("Purposes");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.StartDate)
            .IsRequired();

        builder.Property(p => p.EndDate)
            .IsRequired();

        builder.HasOne<Event>()
            .WithMany(e => e.Purposes)
            .HasForeignKey(p => p.EventId);
    }
}