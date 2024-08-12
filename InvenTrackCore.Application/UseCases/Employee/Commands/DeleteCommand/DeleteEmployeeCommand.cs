using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Employee.Commands.DeleteCommand;

public class DeleteEmployeeCommand : IRequest<BaseResponse<bool>>
{
    public int EmployeeId { get; set; }
}