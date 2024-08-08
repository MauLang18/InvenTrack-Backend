using InvenTrackCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackCore.Infrastructure.Persistence.Context.Configurations;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("InventoryId");
        builder.Property(x => x.Code)
            .IsUnicode();
        builder.Property(x => x.Active)
            .IsUnicode();
        builder.Property(x => x.Brand)
            .HasMaxLength(100);
        builder.Property(x => x.Series)
            .IsUnicode(false);
        builder.Property(x => x.Model)
            .HasMaxLength(200);
        builder.Property(x => x.Price)
            .HasPrecision(20, 2);
        builder.Property(x => x.Details)
            .IsUnicode(false);
        builder.Property(x => x.Image)
            .IsUnicode(false);
        builder.HasOne(x => x.EquipmentTypes)
                .WithMany(y => y.Inventories)
                .HasForeignKey(x => x.EquipmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
    }
}