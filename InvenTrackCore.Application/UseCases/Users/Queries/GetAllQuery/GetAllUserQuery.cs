using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Users.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Users.Queries.GetAllQuery;

public class GetAllUserQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<UsersResponseDto>>>
{
}