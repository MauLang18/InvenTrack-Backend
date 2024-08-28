namespace InvenTrackCore.Application.Dtos.Location.Response;

public class LocationResponseDto
{
    public int LocationId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime AuditCreateDate { get; set; }
    public int State { get; set; }
    public string StateLocation { get; set; } = null!;
}