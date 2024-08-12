using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;
using Entity = InvenTrackCore.Domain.Entities;

namespace InvenTrackCore.Application.UseCases.Ticket.Commands.CreateCommand;

public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTicketHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<bool>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        using var transaction = _unitOfWork.BeginTransaction();

        try
        {
            var ticket = _mapper.Map<Entity.Ticket>(request);
            await _unitOfWork.Ticket.CreateAsync(ticket);
            await _unitOfWork.SaveChangesAsync();

            foreach (var detail in ticket.TicketDetails)
            {
                var inventoryState = await _unitOfWork.Inventory.GetByIdAsync(detail.InventoryId);
                inventoryState.State = 0;
                _unitOfWork.Inventory.UpdateAsync(inventoryState);
                await _unitOfWork.SaveChangesAsync();
            }

            transaction.Commit();
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