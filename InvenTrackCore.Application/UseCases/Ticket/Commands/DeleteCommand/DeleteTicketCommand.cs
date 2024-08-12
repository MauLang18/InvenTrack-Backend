using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Ticket.Commands.DeleteCommand;

public class DeleteTicketCommand : IRequest<BaseResponse<bool>>
{
    public int TicketId { get; set; }
}