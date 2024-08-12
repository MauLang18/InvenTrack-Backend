using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Ticket.Commands.CreateCommand;

public class CreateTicketCommand : IRequest<BaseResponse<bool>>
{
    public int AssignedToId { get; set; }
    public int ReceivedById { get; set; }
    public int DeliveredById { get; set; }
    public string? Details { get; set; }
    public IEnumerable<CreateTicketDetailCommand> TicketDetails { get; set; } = null!;
}

public class CreateTicketDetailCommand
{
    public int InventoryId { get; set; }
}