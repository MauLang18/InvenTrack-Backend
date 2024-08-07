using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Commands.DeleteCommand;

public class DeleteEquipmentTypeCommand : IRequest<BaseResponse<bool>>
{
    public int EquipmentTypeId { get; set; }
}