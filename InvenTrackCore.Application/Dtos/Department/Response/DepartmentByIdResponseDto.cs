namespace InvenTrackCore.Application.Dtos.Department.Response;

public class DepartmentByIdResponseDto
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = null!;
    public string Company { get; set; } = null!;
    public int State { get; set; }
}