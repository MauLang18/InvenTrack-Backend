using AutoMapper;
using InvenTrackCore.Application.Dtos.Inventory.Response;
using InvenTrackCore.Application.UseCases.Inventory.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Inventory.Commands.UpdateCommand;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Utilities.Static;

namespace InvenTrackCore.Application.Mappings;

public class InventoryMapping : Profile
{
    public InventoryMapping()
    {
        CreateMap<Inventory, InventoryResponseDto>()
            .ForMember(x => x.InventoryId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.EquipmentTypeName, x => x.MapFrom(y => y.EquipmentTypes.Name))
            .ForMember(x => x.StateInventory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Activo) ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Inventory, InventoryByIdResponseDto>()
            .ForMember(x => x.InventoryId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<CreateInventoryCommand, Inventory>();

        CreateMap<UpdateInventoryCommand, Inventory>();
    }
}