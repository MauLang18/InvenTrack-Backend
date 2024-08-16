using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Commands.UpdateCommand;

public class UpdateUserCommand : IRequest<BaseResponse<bool>>
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? PassWord { get; set; }
    public string? Email { get; set; }
    public int State { get; set; }
}