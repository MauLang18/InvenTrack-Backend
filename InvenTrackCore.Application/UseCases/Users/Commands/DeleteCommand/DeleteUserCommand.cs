using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Commands.DeleteCommand;

public class DeleteUserCommand : IRequest<BaseResponse<bool>>
{
    public int UserId { get; set; }
}