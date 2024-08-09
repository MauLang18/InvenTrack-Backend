namespace InvenTrackCore.Domain.Entities;

public class Ticket : BaseEntity
{
    public int AssignedToId { get; set; }
    public int ReceivedById { get; set; }
    public int DeliveredById { get; set; }
    public string? Details { get; set; }

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();
    public virtual Employee Employees { get; set; } = null!;
    public virtual Users Users { get; set; } = null!;
}