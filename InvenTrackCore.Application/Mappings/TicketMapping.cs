using AutoMapper;
using InvenTrackCore.Application.Dtos.Ticket.Response;
using InvenTrackCore.Application.UseCases.Ticket.Commands.CreateCommand;
using InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.Mappings;

public class TicketMapping : Profile
{
    public TicketMapping()
    {
        CreateMap<Ticket, TicketResponseDto>()
            .ForMember(x => x.TicketId, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.Department, x => x.MapFrom(y => y.Employees.Departments.Name))
            .ForMember(x => x.Location, x => x.MapFrom(y => y.Employees.Locations.Name))
            .ForMember(x => x.AssignedTo, x => x.MapFrom(y => y.Employees.Name + " " + y.Employees.LastName))
            .ForMember(x => x.DeliveredBy, x => x.MapFrom(y => y.Users.Name + " " + y.Users.LastName))
            .ForMember(x => x.ReceivedBy, x => x.MapFrom(y => y.Employees.Name + " " + y.Employees.LastName))
            .ReverseMap();

        CreateMap<Ticket, TicketByIdResponseDto>()
            .ForMember(x => x.TicketId, x => x.MapFrom(y => y.Id))
            .ReverseMap();

        CreateMap<TicketDetail, TicketDetailsByIdResponseDto>()
            .ForMember(x => x.InventoryId, x => x.MapFrom(y => y.InventoryId))
            .ForMember(x => x.Code, x => x.MapFrom(y => y.Inventories.Code))
            .ForMember(x => x.Active, x => x.MapFrom(y => y.Inventories.Active))
            .ForMember(x => x.EquipmentType, x => x.MapFrom(y => y.Inventories.EquipmentTypes.Name))
            .ForMember(x => x.Brand, x => x.MapFrom(y => y.Inventories.Brand))
            .ForMember(x => x.Series, x => x.MapFrom(y => y.Inventories.Series))
            .ForMember(x => x.Model, x => x.MapFrom(y => y.Inventories.Model))
            .ReverseMap();

        CreateMap<CreateTicketCommand, Ticket>();
        CreateMap<CreateTicketDetailCommand, TicketDetail>();


    }
}