using InvenTrackCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackCore.Infrastructure.Persistence.Context.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("TicketId");
        builder.Property(x => x.Details)
            .IsUnicode(false);
        builder.HasOne(x => x.Locations)
                .WithMany(y => y.Tickets)
                .HasForeignKey(x => x.LocateId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Departments)
                .WithMany(y => y.Tickets)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Employees)
                .WithMany(y => y.Tickets)
                .HasForeignKey(x => x.AssignedToId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Employees)
                .WithMany(y => y.Tickets)
                .HasForeignKey(x => x.ReceivedById)
                .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Users)
                .WithMany(y => y.Tickets)
                .HasForeignKey(x => x.DeliveredById)
                .OnDelete(DeleteBehavior.ClientSetNull);
    }
}