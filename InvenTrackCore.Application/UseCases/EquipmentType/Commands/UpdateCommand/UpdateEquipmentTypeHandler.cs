using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using Entity = InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Commands.UpdateCommand;

public class UpdateEquipmentTypeHandler : IRequestHandler<UpdateEquipmentTypeCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEquipmentTypeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(UpdateEquipmentTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var equipmentType = _mapper.Map<Entity.EquipmentType>(request);
            equipmentType.Id = request.EquipmentTypeId;
            _unitOfWork.EquipmentType.UpdateAsync(equipmentType);
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