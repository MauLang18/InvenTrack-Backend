using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Department.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Department.Queries.GetAllQuery;

public class GetAllDepartmentQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<DepartmentResponseDto>>>
{
}