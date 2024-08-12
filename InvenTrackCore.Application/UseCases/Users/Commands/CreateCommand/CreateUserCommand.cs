using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Commands.CreateCommand;

public class CreateUserCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string PassWord { get; set; } = null!;
    public string? Email { get; set; }
    public int State { get; set; }
}