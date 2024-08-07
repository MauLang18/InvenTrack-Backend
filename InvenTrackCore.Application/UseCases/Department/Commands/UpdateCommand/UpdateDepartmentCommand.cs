using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Department.Commands.UpdateCommand;

public class UpdateDepartmentCommand : IRequest<BaseResponse<bool>>
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = null!;
    public string Company { get; set; } = null!;
    public int State { get; set; }
}