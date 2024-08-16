using AutoMapper;
using InvenTrackCore.Application.Commons.Select.Response;
using InvenTrackCore.Application.Dtos.Users.Response;
using InvenTrackCore.Application.UseCases.Users.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Users.Commands.UpdateCommand;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Utilities.Static;

namespace InvenTrackCore.Application.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<Users, UsersResponseDto>()
            .ForMember(x => x.UserId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.StateUser, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Activo) ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Users, SelectResponse>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Description, x => x.MapFrom(y => y.Name + " " + y.LastName))
            .ReverseMap();

        CreateMap<Users, UsersByIdResponseDto>()
            .ForMember(x => x.UserId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<CreateUserCommand, Users>();

        CreateMap<UpdateUserCommand, Users>();
    }
}