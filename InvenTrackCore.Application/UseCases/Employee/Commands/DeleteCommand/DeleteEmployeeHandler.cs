using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Employee.Commands.DeleteCommand;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var existsEmployee = await _unitOfWork.Employee.GetByIdAsync(request.EmployeeId);

            if (existsEmployee is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            await _unitOfWork.Employee.DeleteAsync(request.EmployeeId);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_DELETE;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            WatchLogger.LogError(ex.Message);
        }

        return response;
    }
}