using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.EquipmentType.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetByIdQuery;

public class GetEquipmentTypeByIdHandler : IRequestHandler<GetEquipmentTypeByIdQuery, BaseResponse<EquipmentTypeByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEquipmentTypeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<EquipmentTypeByIdResponseDto>> Handle(GetEquipmentTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<EquipmentTypeByIdResponseDto>();

        try
        {
            var equipmentType = await _unitOfWork.EquipmentType.GetByIdAsync(request.EquipmentTypeId);

            if (equipmentType is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<EquipmentTypeByIdResponseDto>(equipmentType);
            response.Message = ReplyMessage.MESSAGE_QUERY;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            WatchLogger.LogError(ex.Message);
        }

        return response;
    }
}