namespace InvenTrackCore.Application.Dtos.EquipmentType.Response;

public class EquipmentTypeByIdResponseDto
{
    public int EquipmentTypeId { get; set; }
    public string Name { get; set; } = null!;
    public int State { get; set; }
}