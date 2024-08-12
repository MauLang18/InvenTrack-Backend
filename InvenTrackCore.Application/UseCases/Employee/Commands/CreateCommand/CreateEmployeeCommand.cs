using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Employee.Commands.CreateCommand;

public class CreateEmployeeCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int LocationId { get; set; }
    public int DepartmentId { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int State { get; set; }
}