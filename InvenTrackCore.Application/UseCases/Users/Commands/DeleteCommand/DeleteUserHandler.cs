using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Users.Commands.DeleteCommand;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var existUser = await _unitOfWork.Users.GetByIdAsync(request.UserId);

            if (existUser is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            await _unitOfWork.Users.DeleteAsync(request.UserId);
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