using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Inventory.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Inventory.Queries.GetByIdQuery;

public class GetInventoryByIdQuery : IRequest<BaseResponse<InventoryByIdResponseDto>>
{
    public int InventoryId { get; set; }
}