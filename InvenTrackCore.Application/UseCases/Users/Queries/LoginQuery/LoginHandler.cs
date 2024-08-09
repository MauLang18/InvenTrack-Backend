using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using BC = BCrypt.Net.BCrypt;

namespace InvenTrackCore.Application.UseCases.Users.Queries.LoginQuery;

public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<string>();

        try
        {
            var user = await _unitOfWork.Users.UserByUsername(request.UserName);

            if (user is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
                return response;
            }

            if (!BC.Verify(request.PassWord, user.PassWord))
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_ERROR_PASSWORD;
            }

            response.IsSuccess = true;
            //response.Data = _jwtTokenGenerator.GenerateToken(user);
            response.Message = ReplyMessage.MESSAGE_TOKEN;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            WatchLogger.LogError(ex.Message);
        }

        return response;
    }
}