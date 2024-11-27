using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Time)
                .IsRequired();

            builder.HasMany(e => e.Purposes)
                .WithOne()
                .HasForeignKey(p => p.EventId);

            builder.HasMany(e => e.EventsTables)
                .WithOne()
                .HasForeignKey(et => et.EventId);
        }
    }
}
