namespace InvenTrackCore.Application.Dtos.Users.Response;

public class UsersResponseDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime AuditCreateDate { get; set; }
    public int State { get; set; }
    public string StateUser { get; set; } = null!;
}