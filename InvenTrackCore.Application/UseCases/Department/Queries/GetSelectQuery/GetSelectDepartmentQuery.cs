using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Department.Queries.GetSelectQuery;

public class GetSelectDepartmentQuery : IRequest<BaseResponse<IEnumerable<SelectResponse>>>
{
}