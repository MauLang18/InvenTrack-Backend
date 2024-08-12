using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Queries.LoginQuery;

public class LoginQuery : IRequest<BaseResponse<string>>
{
    public string UserName { get; set; } = null!;
    public string PassWord { get; set; } = null!;
}