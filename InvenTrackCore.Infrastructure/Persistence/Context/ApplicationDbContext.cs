using InvenTrackCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InvenTrackCore.Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions) { }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EquipmentType> EquipmentTypes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketDetail> TicketDetails { get; set; }
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}