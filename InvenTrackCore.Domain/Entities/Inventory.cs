namespace InvenTrackCore.Domain.Entities;

public class Inventory : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Active { get; set; } = null!;
    public int EquipmentTypeId { get; set; }
    public string Brand { get; set; } = null!;
    public string Series { get; set; } = null!;
    public string Model { get; set; } = null!;
    public decimal? Price { get; set; }
    public string? Details { get; set; }
    public string? Image { get; set; }

    public virtual EquipmentType EquipmentTypes { get; set; } = null!;
    public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();
}