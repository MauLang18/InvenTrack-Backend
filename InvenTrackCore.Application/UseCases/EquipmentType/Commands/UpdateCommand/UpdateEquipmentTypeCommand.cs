using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Commands.UpdateCommand;

public class UpdateEquipmentTypeCommand : IRequest<BaseResponse<bool>>
{
    public int EquipmentTypeId { get; set; }
    public string Name { get; set; } = null!;
    public int State { get; set; }
}