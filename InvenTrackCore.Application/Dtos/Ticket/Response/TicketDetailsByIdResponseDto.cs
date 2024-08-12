namespace InvenTrackCore.Application.Dtos.Ticket.Response;

public class TicketDetailsByIdResponseDto
{
    public int InventoryId { get; set; }
    public string Code { get; set; } = null!;
    public string Active { get; set; } = null!;
    public string EquipmentType { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Series { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string? Details { get; set; }
}