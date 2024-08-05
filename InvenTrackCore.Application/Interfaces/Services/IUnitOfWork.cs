using InvenTrackCore.Application.Interfaces.Persistence;
using InvenTrackCore.Domain.Entities;
using System.Data;

namespace InvenTrackCore.Application.Interfaces.Services;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Department> Department { get; }
    IGenericRepository<Employee> Employee { get; }
    IGenericRepository<EquipmentType> EquipmentType { get; }
    IGenericRepository<Inventory> Inventory { get; }
    IGenericRepository<Location> Location { get; }
    IGenericRepository<Ticket> Ticket { get; }
    ITicketDetailRepository TicketDetail { get; }
    IUsersRepository Users { get; }
    Task SaveChangesAsync();
    IDbTransaction BeginTransaction();
}