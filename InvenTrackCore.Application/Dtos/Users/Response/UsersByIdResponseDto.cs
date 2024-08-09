namespace InvenTrackCore.Application.Dtos.Users.Response;

public class UsersByIdResponseDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Email { get; set; }
    public int State { get; set; }
}