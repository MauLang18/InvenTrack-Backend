using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Inventory.Commands.DeleteCommand;

public class DeleteInventoryCommand : IRequest<BaseResponse<bool>>
{
    public int InventoryId { get; set; }
}