namespace InvenTrackCore.Application.Dtos.Location.Response;

public class LocationByIdResponseDto
{
    public int LocationId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int State { get; set; }
}