using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Department.Commands.DeleteCommand;

public class DeleteDepartmentCommand : IRequest<BaseResponse<bool>>
{
    public int DepartmentId { get; set; }
}