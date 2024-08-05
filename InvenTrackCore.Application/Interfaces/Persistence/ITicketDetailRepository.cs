using InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.Interfaces.Persistence;

public interface ITicketDetailRepository
{
    Task<IEnumerable<TicketDetail>> GetTicketDetailByTicketId(int id);
}
