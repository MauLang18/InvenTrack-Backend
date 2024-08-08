using InvenTrackCore.Application.Commons.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace InvenTrackCore.Application.UseCases.Inventory.Commands.CreateCommand;

public class CreateInventoryCommand : IRequest<BaseResponse<bool>>
{
    public int EquipmentTypeId { get; set; }
    public string Brand { get; set; } = null!;
    public string Series { get; set; } = null!;
    public string Model { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Details { get; set; }
    public IFormFile? Image { get; set; }
    public int State { get; set; }
}