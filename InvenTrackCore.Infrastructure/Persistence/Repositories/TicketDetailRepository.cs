using InvenTrackCore.Application.Interfaces.Persistence;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InvenTrackCore.Infrastructure.Persistence.Repositories;

public class TicketDetailRepository : ITicketDetailRepository
{
    private readonly ApplicationDbContext _context;

    public TicketDetailRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TicketDetail>> GetTicketDetailByTicketId(int id)
    {
        var response = await _context.Inventories
                .AsNoTracking()
                .Join(_context.TicketDetails, p => p.Id, pd => pd.InventoryId, (p, pd) => new { Inventory = p, TicketDetail = pd })
                .Where(x => x.TicketDetail.TicketId == id)
                .Select(x => new TicketDetail
                {
                    InventoryId = x.Inventory.Id,
                    Inventories = new Inventory
                    {
                        Image = x.Inventory.Image,
                        Code = x.Inventory.Code,
                        Active = x.Inventory.Active,
                        Brand = x.Inventory.Brand,
                        Series = x.Inventory.Series,
                        Model = x.Inventory.Model,
                    },
                    Details = x.TicketDetail.Details,
                })
                .ToListAsync();

        return response!;
    }
}