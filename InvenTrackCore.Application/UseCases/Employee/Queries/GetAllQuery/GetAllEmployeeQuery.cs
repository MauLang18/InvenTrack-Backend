using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Employee.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Employee.Queries.GetAllQuery;

public class GetAllEmployeeQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<EmployeeResponseDto>>>
{
}