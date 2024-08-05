using InvenTrackCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvenTrackCore.Infrastructure.Persistence.Context.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("EmployeeId");
        builder.Property(x => x.Name)
            .HasMaxLength(50);
        builder.Property(x => x.LastName)
            .HasMaxLength(50);
        builder.Property(x => x.Email)
            .HasMaxLength(100);
        builder.Property(x => x.Phone)
            .HasMaxLength(100);
        builder.HasOne(x => x.Locations)
            .WithMany(y => y.Employees)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder.HasOne(x => x.Departments)
            .WithMany(y => y.Employees)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}