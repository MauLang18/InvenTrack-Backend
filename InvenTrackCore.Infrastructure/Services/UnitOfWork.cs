using InvenTrackCore.Application.Interfaces.Persistence;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Infrastructure.Persistence.Context;
using InvenTrackCore.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace InvenTrackCore.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IGenericRepository<Department> _department = null!;
    private readonly IGenericRepository<Employee> _employee = null!;
    private readonly IGenericRepository<EquipmentType> _equipmentType = null!;
    private readonly IGenericRepository<Inventory> _inventory = null!;
    private readonly IGenericRepository<Location> _location = null!;
    private readonly IGenericRepository<Ticket> _ticket = null!;
    private readonly ITicketDetailRepository _ticketDetail = null!;
    private readonly IUsersRepository _users = null!;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public UnitOfWork()
    {

    }

    public IGenericRepository<Department> Department => _department ?? new GenericRepository<Department>(_context);

    public IGenericRepository<Employee> Employee => _employee ?? new GenericRepository<Employee>(_context);

    public IGenericRepository<EquipmentType> EquipmentType => _equipmentType ?? new GenericRepository<EquipmentType>(_context);

    public IGenericRepository<Inventory> Inventory => _inventory ?? new GenericRepository<Inventory>(_context);

    public IGenericRepository<Location> Location => _location ?? new GenericRepository<Location>(_context);

    public IGenericRepository<Ticket> Ticket => _ticket ?? new GenericRepository<Ticket>(_context);

    public ITicketDetailRepository TicketDetail => _ticketDetail ?? new TicketDetailRepository(_context);

    public IUsersRepository Users => _users ?? new UsersRepository(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();

        return transaction.GetDbTransaction();
    }
}