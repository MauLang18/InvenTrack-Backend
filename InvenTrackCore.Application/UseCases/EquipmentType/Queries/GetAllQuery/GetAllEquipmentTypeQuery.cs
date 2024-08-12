using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.EquipmentType.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetAllQuery;

public class GetAllEquipmentTypeQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<EquipmentTypeResponseDto>>>
{
}