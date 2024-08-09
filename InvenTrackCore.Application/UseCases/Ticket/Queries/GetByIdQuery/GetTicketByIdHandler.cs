using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Ticket.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Ticket.Queries.GetByIdQuery;

public class GetTicketByIdHandler : IRequestHandler<GetTicketByIdQuery, BaseResponse<TicketByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTicketByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<TicketByIdResponseDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<TicketByIdResponseDto>();

        try
        {
            var ticket = await _unitOfWork.Ticket.GetByIdAsync(request.TicketId);

            if (ticket is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            var ticketDetails = await _unitOfWork.TicketDetail.GetTicketDetailByTicketId(request.TicketId);

            ticket.TicketDetails = ticketDetails.ToList();

            response.IsSuccess = true;
            response.Data = _mapper.Map<TicketByIdResponseDto>(ticket);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            WatchLogger.LogError(ex.Message);
        }

        return response;
    }
}