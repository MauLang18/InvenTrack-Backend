using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using Entity = InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.UseCases.Inventory.Commands.UpdateCommand;

public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileStorageService _fileStorageService;

    public UpdateInventoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
    }

    public async Task<BaseResponse<bool>> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var existInventory = await _unitOfWork.Inventory.GetByIdAsync(request.InventoryId);

            if (existInventory is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            var inventory = _mapper.Map<Entity.Inventory>(request);
            inventory.Id = request.InventoryId;
            if (request.Image is not null)
                inventory.Image = await _fileStorageService.EditFile(Containers.INVENTORY, request.Image, existInventory.Image!);
            if (request.Image is null)
                inventory.Image = existInventory.Image!;
            _unitOfWork.Inventory.UpdateAsync(inventory);
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