using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Location.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Location.Queries.GetAllQueries;

public class GetAllLocationQuery : BaseFilters, IRequest<BaseResponse<IEnumerable<LocationResponseDto>>>
{
}