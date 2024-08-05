namespace InvenTrackCore.Domain.Entities;

public class Users : BaseEntity
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string PassWord { get; set; } = null!;
    public string? Email { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}