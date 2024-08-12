namespace InvenTrackCore.Application.Dtos.Ticket.Response;

public class TicketByIdResponseDto
{
    public int TicketId { get; set; }
    public int AssignedToId { get; set; }
    public string? AssignedTo { get; set; }
    public int ReceivedById { get; set; }
    public string? ReceivedBy { get; set; }
    public int DeliveredById { get; set; }
    public string? DeliveredBy { get; set; }
    public string? Department { get; set; }
    public string? Location { get; set; }
    public string? Details { get; set; }
    public ICollection<TicketDetailsByIdResponseDto> TicketDetails { get; set; } = null!;
}