using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Inventory.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Inventory.Queries.GetByIdQuery;

public class GetInventoryByIdHandler : IRequestHandler<GetInventoryByIdQuery, BaseResponse<InventoryByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInventoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<InventoryByIdResponseDto>> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<InventoryByIdResponseDto>();

        try
        {
            var inventory = await _unitOfWork.Inventory.GetByIdAsync(request.InventoryId);

            if (inventory is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<InventoryByIdResponseDto>(inventory);
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