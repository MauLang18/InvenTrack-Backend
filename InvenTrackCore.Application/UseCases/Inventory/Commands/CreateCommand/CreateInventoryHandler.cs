using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using Entity = InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.UseCases.Inventory.Commands.CreateCommand;

public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileStorageService _fileStorageService;
    private readonly IGenerateCodeService _generateCodeService;

    public CreateInventoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService, IGenerateCodeService generateCodeService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
        _generateCodeService = generateCodeService;
    }

    public async Task<BaseResponse<bool>> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var inventory = _mapper.Map<Entity.Inventory>(request);
            if (request.Image is not null)
                inventory.Image = await _fileStorageService.SaveFile(Containers.INVENTORY, request.Image!);
            inventory.Active = await _generateCodeService.GenereteActive();
            inventory.Code = await _generateCodeService.GenerateCode(request.EquipmentTypeId);
            await _unitOfWork.Inventory.CreateAsync(inventory);
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