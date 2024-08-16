using AutoMapper;
using InvenTrackCore.Application.Commons.Select.Response;
using InvenTrackCore.Application.Dtos.Department.Response;
using InvenTrackCore.Application.UseCases.Department.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Department.Commands.UpdateCommand;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Utilities.Static;

namespace InvenTrackCore.Application.Mappings;

public class DepartmentMapping : Profile
{
    public DepartmentMapping()
    {
        CreateMap<Department, DepartmentResponseDto>()
            .ForMember(x => x.DepartmentId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.StateDepartment, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Activo) ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Department, SelectResponse>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Description, x => x.MapFrom(y => y.Name))
            .ReverseMap();

        CreateMap<Department, DepartmentByIdResponseDto>()
            .ForMember(x => x.DepartmentId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<CreateDepartmentCommand, Department>();

        CreateMap<UpdateDepartmentCommand, Department>();
    }
}