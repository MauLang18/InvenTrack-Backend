using AutoMapper;
using InvenTrackCore.Application.Dtos.Location.Response;
using InvenTrackCore.Application.UseCases.Location.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Location.Commands.UpdateCommand;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Utilities.Static;

namespace InvenTrackCore.Application.Mappings;

public class LocationMapping : Profile
{
    public LocationMapping()
    {
        CreateMap<Location, LocationResponseDto>()
            .ForMember(x => x.LocationId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.StateLocate, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Activo) ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Location, LocationByIdResponseDto>()
            .ForMember(x => x.LocationId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<CreateLocationCommand, Location>();

        CreateMap<UpdateLocationCommand, Location>();
    }
}