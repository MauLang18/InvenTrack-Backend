namespace InvenTrackCore.Application.Dtos.Department.Response;

public class DepartmentResponseDto
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = null!;
    public string Company { get; set; } = null!;
    public DateTime AuditCreateDate { get; set; }
    public int State { get; set; }
    public string StateDepartment { get; set; } = null!;
}