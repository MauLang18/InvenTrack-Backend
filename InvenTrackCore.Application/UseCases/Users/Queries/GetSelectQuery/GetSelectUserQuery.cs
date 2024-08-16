using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Queries.GetSelectQuery;

public class GetSelectUserQuery : IRequest<BaseResponse<IEnumerable<SelectResponse>>>
{
}