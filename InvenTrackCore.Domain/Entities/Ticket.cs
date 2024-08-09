using System.ComponentModel.DataAnnotations.Schema;

namespace InvenTrackCore.Domain.Entities;

public class Ticket : BaseEntity
{
    public int AssignedToId { get; set; }
    [NotMapped]
    public string? AssignedTo { get; set; }
    public int ReceivedById { get; set; }
    [NotMapped]
    public string? ReceivedBy { get; set; }
    public int DeliveredById { get; set; }
    [NotMapped]
    public string? DeliveredBy { get; set; }
    [NotMapped]
    public string? Department { get; set; }
    [NotMapped]
    public string? Location { get; set; }
    public string? Details { get; set; }

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();
    public virtual Employee Employees { get; set; } = null!;
    public virtual Users Users { get; set; } = null!;
}