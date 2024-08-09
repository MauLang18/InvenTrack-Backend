using AutoMapper;
using InvenTrackCore.Application.Dtos.Employee.Response;
using InvenTrackCore.Application.UseCases.Employee.Commands.CreateCommand;
using InvenTrackCore.Application.UseCases.Employee.Commands.UpdateCommand;
using InvenTrackCore.Domain.Entities;
using InvenTrackCore.Utilities.Static;

namespace InvenTrackCore.Application.Mappings;

public class EmployeeMapping : Profile
{
    public EmployeeMapping()
    {
        CreateMap<Employee, EmployeeResponseDto>()
            .ForMember(x => x.EmployeeId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Location, x => x.MapFrom(y => y.Locations.Name))
            .ForMember(x => x.Department, x => x.MapFrom(y => y.Departments.Name))
            .ForMember(x => x.StateEmployee, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Activo) ? "ACTIVO" : "INACTIVO"))
            .ReverseMap();

        CreateMap<Employee, EmployeeByIdResponseDto>()
            .ForMember(x => x.EmployeeId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<CreateEmployeeCommand, Employee>();

        CreateMap<UpdateEmployeeCommand, Employee>();
    }
}