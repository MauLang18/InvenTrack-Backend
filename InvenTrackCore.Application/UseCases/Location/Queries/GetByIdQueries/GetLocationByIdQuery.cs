using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Location.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Location.Queries.GetByIdQueries;

public class GetLocationByIdQuery : IRequest<BaseResponse<LocationByIdResponseDto>>
{
    public int LocationId { get; set; }
}