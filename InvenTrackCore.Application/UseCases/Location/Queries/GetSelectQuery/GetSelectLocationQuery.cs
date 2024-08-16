using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Location.Queries.GetSelectQuery;

public class GetSelectLocationQuery : IRequest<BaseResponse<IEnumerable<SelectResponse>>>
{
}