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

            var departmentId = await _unitOfWork.Employee.GetByIdAsync(ticket.AssignedToId);
            var locationId = await _unitOfWork.Employee.GetByIdAsync(ticket.AssignedToId);
            var department = await _unitOfWork.Department.GetByIdAsync(departmentId.DepartmentId);
            var location = await _unitOfWork.Location.GetByIdAsync(locationId.LocationId);
            var assignedTo = await _unitOfWork.Employee.GetByIdAsync(ticket.AssignedToId);
            var deliveredBy = await _unitOfWork.Users.GetByIdAsync(ticket.DeliveredById);
            var receivedById = await _unitOfWork.Employee.GetByIdAsync(ticket.ReceivedById);
            var ticketDetails = await _unitOfWork.TicketDetail.GetTicketDetailByTicketId(request.TicketId);

            ticket.TicketDetails = ticketDetails.ToList();
            ticket.Department = department.Name;
            ticket.Location = location.Name;
            ticket.AssignedTo = assignedTo.Name + " " + assignedTo.LastName;
            ticket.ReceivedBy = receivedById.Name + " " + receivedById.LastName;
            ticket.DeliveredBy = deliveredBy.Name + " " + deliveredBy.LastName;

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