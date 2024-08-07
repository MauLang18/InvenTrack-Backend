using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Employee.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Employee.Queries.GetAllQuery;

public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, BaseResponse<IEnumerable<EmployeeResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderingQuery _ordering;

    public GetAllEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery ordering)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ordering = ordering;
    }

    public async Task<BaseResponse<IEnumerable<EmployeeResponseDto>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<EmployeeResponseDto>>();

        try
        {
            var employees = _unitOfWork.Employee.GetAllQueryable();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        employees = employees.Where(x => x.Name.Contains(request.TextFilter));
                        break;
                    case 2:
                        employees = employees.Where(x => x.LastName.Contains(request.TextFilter));
                        break;
                    case 3:
                        employees = employees.Where(x => x.Email!.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                employees = employees.Where(x => x.State == request.StateFilter);
            }

            if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
            {
                employees = employees.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate).ToUniversalTime() &&
                                                 x.AuditDeleteDate <= Convert.ToDateTime(request.EndDate).ToUniversalTime().AddDays(1));
            }

            request.Sort ??= "Id";

            var items = await _ordering.Ordering(request, employees)
                .ToListAsync(cancellationToken);

            response.IsSuccess = true;
            response.TotalRecords = await employees.CountAsync(cancellationToken);
            response.Data = _mapper.Map<IEnumerable<EmployeeResponseDto>>(items);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        catch (Exception ex)
        {
            response.Message = ex.ToString();
            WatchLogger.LogError(ex.ToString());
        }

        return response;
    }
}