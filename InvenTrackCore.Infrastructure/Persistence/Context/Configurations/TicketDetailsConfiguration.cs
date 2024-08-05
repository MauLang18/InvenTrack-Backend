using InvenTrackCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackCore.Infrastructure.Persistence.Context.Configurations;

public class TicketDetailsConfiguration : IEntityTypeConfiguration<TicketDetail>
{
    public void Configure(EntityTypeBuilder<TicketDetail> builder)
    {
        builder.HasKey(x => new { x.TicketId, x.InventoryId });
        builder.Property(x => x.Details)
            .IsUnicode(false);
        builder.HasOne(x => x.Tickets)
                .WithMany(y => y.TicketDetails)
                .HasForeignKey(x => x.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Inventories)
                .WithMany(y => y.TicketDetails)
                .HasForeignKey(x => x.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
    }
}