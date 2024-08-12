using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Ticket.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Ticket.Queries.GetAllQuery;

public class GetAllTicketHandler : IRequestHandler<GetAllTicketQuery, BaseResponse<IEnumerable<TicketResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderingQuery _ordering;

    public GetAllTicketHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery ordering)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ordering = ordering;
    }

    public async Task<BaseResponse<IEnumerable<TicketResponseDto>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<TicketResponseDto>>();

        try
        {
            var ticket = _unitOfWork.Ticket.GetAllQueryable()
                .AsNoTracking()
                .Include(x => x.Employees)
                .Include(x => x.Employees.Locations)
                .Include(x => x.Employees.Departments)
                .Include(x => x.Users)
                .AsQueryable();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        ticket = ticket.Where(x => x.Employees.Name.Contains(request.TextFilter));
                        break;
                }
            }

            if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
            {
                ticket = ticket.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate).ToUniversalTime() &&
                                           x.AuditCreateDate <= Convert.ToDateTime(request.EndDate).ToUniversalTime().AddDays(1));
            }

            request.Sort ??= "Id";

            var items = await _ordering.Ordering(request, ticket)
                .ToListAsync(cancellationToken);

            response.IsSuccess = true;
            response.TotalRecords = await ticket.CountAsync(cancellationToken);
            response.Data = _mapper.Map<IEnumerable<TicketResponseDto>>(items);
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