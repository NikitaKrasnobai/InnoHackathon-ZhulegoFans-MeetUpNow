using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class EventsTableConfiguration : IEntityTypeConfiguration<EventsTable>
{
    public void Configure(EntityTypeBuilder<EventsTable> builder)
    {
        builder.ToTable("EventsTables");

        builder.HasKey(et => et.Id);

        builder.Property(et => et.CountOfVisits)
            .IsRequired();

        builder.HasOne<Event>()
            .WithMany(e => e.EventsTables)
            .HasForeignKey(et => et.EventId);

        builder.HasOne<Place>()
            .WithMany()
            .HasForeignKey(et => et.PlaceId);
    }
}