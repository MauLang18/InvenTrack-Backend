namespace InvenTrackCore.Domain.Entities;

public class EquipmentType : BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}