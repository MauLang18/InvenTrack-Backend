namespace InvenTrackCore.Domain.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}