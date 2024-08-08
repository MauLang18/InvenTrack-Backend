using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using Entity = InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Commands.CreateCommand;

public class CreateEquipmentTypeHandler : IRequestHandler<CreateEquipmentTypeCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEquipmentTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(CreateEquipmentTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var equipmentType = _mapper.Map<Entity.EquipmentType>(request);
            await _unitOfWork.EquipmentType.CreateAsync(equipmentType);
            await _unitOfWork.SaveChangesAsync();

            response.IsSuccess = true;
            response.Message = ReplyMessage.MESSAGE_SAVE;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            WatchLogger.LogError(ex.Message);
        }

        return response;
    }
}