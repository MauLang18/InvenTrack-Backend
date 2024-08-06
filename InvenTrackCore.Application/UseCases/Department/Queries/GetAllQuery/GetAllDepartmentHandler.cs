using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Department.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Department.Queries.GetAllQuery;

public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentQuery, BaseResponse<IEnumerable<DepartmentResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderingQuery _ordering;

    public GetAllDepartmentHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery ordering)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ordering = ordering;
    }

    public async Task<BaseResponse<IEnumerable<DepartmentResponseDto>>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<DepartmentResponseDto>>();

        try
        {
            var departments = _unitOfWork.Department.GetAllQueryable();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        departments = departments.Where(x => x.Name.Contains(request.TextFilter));
                        break;
                    case 2:
                        departments = departments.Where(x => x.Company.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                departments = departments.Where(x => x.State == request.StateFilter);
            }

            if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
            {
                departments = departments.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate).ToUniversalTime() &&
                                                     x.AuditCreateDate <= Convert.ToDateTime(request.EndDate).ToUniversalTime().AddDays(1));
            }

            request.Sort ??= "Id";

            var items = await _ordering.Ordering(request, departments)
                .ToListAsync(cancellationToken);

            response.IsSuccess = true;
            response.TotalRecords = await departments.CountAsync(cancellationToken);
            response.Data = _mapper.Map<IEnumerable<DepartmentResponseDto>>(items);
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