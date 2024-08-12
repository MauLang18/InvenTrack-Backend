namespace InvenTrackCore.Application.Dtos.Ticket.Response;

public class TicketResponseDto
{
    public int TicketId { get; set; }
    public string Location { get; set; } = null!;
    public string Department { get; set; } = null!;
    public string AssignedTo { get; set; } = null!;
    public string ReceivedBy { get; set; } = null!;
    public string DeliveredBy { get; set; } = null!;
    public DateTime AuditCreateDate { get; set; }
}