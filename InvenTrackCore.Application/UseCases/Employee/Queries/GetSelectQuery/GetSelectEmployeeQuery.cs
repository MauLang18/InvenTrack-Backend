using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Employee.Queries.GetSelectQuery;

public class GetSelectEmployeeQuery : IRequest<BaseResponse<IEnumerable<SelectResponse>>>
{
}