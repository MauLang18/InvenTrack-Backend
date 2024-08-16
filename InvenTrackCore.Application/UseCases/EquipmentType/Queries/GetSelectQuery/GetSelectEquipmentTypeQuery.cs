using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetSelectQuery;

public class GetSelectEquipmentTypeQuery : IRequest<BaseResponse<IEnumerable<SelectResponse>>>
{
}