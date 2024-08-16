using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using BC = BCrypt.Net.BCrypt;
using Entity = InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.UseCases.Users.Commands.UpdateCommand;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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

            var user = _mapper.Map<Entity.Users>(request);
            user.Id = request.UserId;

            if (request.PassWord is not null)
                user.PassWord = BC.HashPassword(request.PassWord);
            else
                user.PassWord = existUser.PassWord;

            _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_UPDATE;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            WatchLogger.LogError(ex.Message);
        }

        return response;
    }
}