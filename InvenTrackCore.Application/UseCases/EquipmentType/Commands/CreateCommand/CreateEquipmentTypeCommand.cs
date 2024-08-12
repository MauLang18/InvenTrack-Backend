using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Commands.CreateCommand;

public class CreateEquipmentTypeCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = null!;
    public int State { get; set; }
}