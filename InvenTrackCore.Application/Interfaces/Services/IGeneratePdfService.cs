using InvenTrackCore.Application.Dtos.Ticket.Response;

namespace InvenTrackCore.Application.Interfaces.Services;

public interface IGeneratePdfService
{
    byte[] GeneratePdf(TicketByIdResponseDto ticket);
}