namespace InvenTrackCore.Domain.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public virtual Location Locations { get; set; } = null!;
    public virtual Department Departments { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}