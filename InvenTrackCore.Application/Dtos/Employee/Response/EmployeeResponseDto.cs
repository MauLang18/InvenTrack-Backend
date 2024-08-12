namespace InvenTrackCore.Application.Dtos.Employee.Response;

public class EmployeeResponseDto
{
    public int EmployeeId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Department { get; set; } = null!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime AuditCreateDate { get; set; }
    public int State { get; set; }
    public string StateEmployee { get; set; } = null!;
}