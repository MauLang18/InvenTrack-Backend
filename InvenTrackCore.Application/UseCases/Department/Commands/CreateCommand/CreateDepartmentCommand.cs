using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Department.Commands.CreateCommand;

public class CreateDepartmentCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = null!;
    public string Company { get; set; } = null!;
    public int State { get; set; }
}