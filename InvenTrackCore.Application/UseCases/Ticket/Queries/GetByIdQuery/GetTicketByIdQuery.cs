using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Ticket.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Ticket.Queries.GetByIdQuery;

public class GetTicketByIdQuery : IRequest<BaseResponse<TicketByIdResponseDto>>
{
    public int TicketId { get; set; }
}