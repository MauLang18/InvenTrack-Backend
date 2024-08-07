using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.EquipmentType.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetByIdQuery;

public class GetEquipmentTypeByIdQuery : IRequest<BaseResponse<EquipmentTypeByIdResponseDto>>
{
    public int EquipmentTypeId { get; set; }
}