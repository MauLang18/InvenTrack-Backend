using InvenTrackCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackCore.Infrastructure.Persistence.Context.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("UserId");
        builder.Property(x => x.Name)
            .HasMaxLength(100);
        builder.Property(x => x.LastName)
            .HasMaxLength(100);
        builder.Property(x => x.UserName)
            .HasMaxLength(100);
        builder.Property(x => x.PassWord)
            .HasMaxLength(150);
        builder.Property(x => x.Email)
            .HasMaxLength(100);
    }
}