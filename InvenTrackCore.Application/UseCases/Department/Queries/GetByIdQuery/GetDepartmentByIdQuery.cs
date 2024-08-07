using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Department.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Department.Queries.GetByIdQuery;

public class GetDepartmentByIdQuery : IRequest<BaseResponse<DepartmentByIdResponseDto>>
{
    public int DepartmentId { get; set; }
}