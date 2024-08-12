using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Employee.Response;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Employee.Queries.GetByIdQuery;

public class GetEmployeeByIdQuery : IRequest<BaseResponse<EmployeeByIdResponseDto>>
{
    public int EmployeeId { get; set; }
}