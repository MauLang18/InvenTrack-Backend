using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Users.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Queries.GetByIdQuery;

public class GetUserByIdQuery : IRequest<BaseResponse<UsersByIdResponseDto>>
{
    public int UserId { get; set; }
}