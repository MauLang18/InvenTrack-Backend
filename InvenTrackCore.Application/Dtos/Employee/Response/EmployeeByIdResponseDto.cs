namespace InvenTrackCore.Application.Dtos.Employee.Response;

public class EmployeeByIdResponseDto
{
    public int EmployeeId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int State { get; set; }
}