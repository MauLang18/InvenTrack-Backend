namespace InvenTrackCore.Application.Dtos.EquipmentType.Response;

public class EquipmentTypeResponseDto
{
    public int EquipmentTypeId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime AuditCreateDate { get; set; }
    public int State { get; set; }
    public string StateEquipmentType { get; set; } = null!;
}