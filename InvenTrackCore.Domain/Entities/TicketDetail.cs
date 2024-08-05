namespace InvenTrackCore.Domain.Entities;

public class TicketDetail
{
    public int TicketId { get; set; }
    public int InventoryId { get; set; }
    public string? Details { get; set; }

    public virtual Ticket Tickets { get; set; } = null!;
    public virtual Inventory Inventories { get; set; } = null!;
}