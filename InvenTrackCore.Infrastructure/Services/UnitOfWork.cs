using InvenTrackCore.Application.Interfaces.Persistence;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Infrastructure.Persistence.Context;
using InvenTrackCore.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace InvenTrackCore.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private bool _disposed = false;

    private IGenericRepository<Department> _department = null!;
    private IGenericRepository<Employee> _employee = null!;
    private IGenericRepository<EquipmentType> _equipmentType = null!;
    private IGenericRepository<Inventory> _inventory = null!;
    private IGenericRepository<Location> _location = null!;
    private IGenericRepository<Ticket> _ticket = null!;
    private ITicketDetailRepository _ticketDetail = null!;
    private IUsersRepository _users = null!;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<Department> Department => _department ??= new GenericRepository<Department>(_context);

    public IGenericRepository<Employee> Employee => _employee ??= new GenericRepository<Employee>(_context);

    public IGenericRepository<EquipmentType> EquipmentType => _equipmentType ??= new GenericRepository<EquipmentType>(_context);

    public IGenericRepository<Inventory> Inventory => _inventory ??= new GenericRepository<Inventory>(_context);

    public IGenericRepository<Location> Location => _location ??= new GenericRepository<Location>(_context);

    public IGenericRepository<Ticket> Ticket => _ticket ??= new GenericRepository<Ticket>(_context);

    public ITicketDetailRepository TicketDetail => _ticketDetail ??= new TicketDetailRepository(_context);

    public IUsersRepository Users => _users ??= new UsersRepository(_context);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }

    ~UnitOfWork()
    {
        Dispose(false);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}