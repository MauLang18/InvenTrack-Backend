using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Ticket.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Ticket.Queries.GetAllQuery;

public class GetAllTicketQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<TicketResponseDto>>>
{
}