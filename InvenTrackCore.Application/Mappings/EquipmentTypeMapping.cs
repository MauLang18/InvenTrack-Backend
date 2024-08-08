using AutoMapper;
using InvenTrackCore.Application.Dtos.EquipmentType.Response;
using InvenTrackCore.Application.UseCases.EquipmentType.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.EquipmentType.Commands.UpdateCommand;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Utilities.Static;

namespace InvenTrackCore.Application.Mappings;

public class EquipmentTypeMapping : Profile
{
    public EquipmentTypeMapping()
    {
        CreateMap<EquipmentType, EquipmentTypeResponseDto>()
            .ForMember(x => x.EquipmentTypeId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.StateEquipmentType, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Activo) ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<EquipmentType, EquipmentTypeByIdResponseDto>()
            .ForMember(x => x.EquipmentTypeId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<CreateEquipmentTypeCommand, EquipmentType>();

        CreateMap<UpdateEquipmentTypeCommand, EquipmentType>();
    }
}