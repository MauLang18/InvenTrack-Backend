namespace InvenTrackCore.Domain.Entities;

public class Ticket : BaseEntity
{
    public int LocateId { get; set; }
    public int DepartmentId { get; set; }
    public int AssignedToId { get; set; }
    public int ReceivedById { get; set; }
    public int DeliveredById { get; set; }
    public string? Details { get; set; }

    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();
    public virtual Location Locations { get; set; } = null!;
    public virtual Department Departments { get; set; } = null!;
    public virtual Employee Employees { get; set; } = null!;
    public virtual Users Users { get; set; } = null!;
}