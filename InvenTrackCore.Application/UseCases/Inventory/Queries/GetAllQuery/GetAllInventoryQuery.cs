using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Inventory.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Inventory.Queries.GetAllQuery;

public class GetAllInventoryQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<InventoryResponseDto>>>
{
}