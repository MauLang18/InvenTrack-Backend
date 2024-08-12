using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Application.UseCases.Ticket.Queries.GetByIdQuery;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Ticket.Commands.DeleteCommand;

public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public DeleteTicketHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task<BaseResponse<bool>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        using var transaction = _unitOfWork.BeginTransaction();

        try
        {
            var ticket = await _mediator.Send(new GetTicketByIdQuery { TicketId = request.TicketId }, cancellationToken);

            if (ticket is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            await _unitOfWork.Ticket.DeleteAsync(request.TicketId);
            await _unitOfWork.SaveChangesAsync();

            foreach (var detail in ticket.Data!.TicketDetails)
            {
                var inventoryState = await _unitOfWork.Inventory.GetByIdAsync(detail.InventoryId);
                inventoryState.State = 1;
                _unitOfWork.Inventory.UpdateAsync(inventoryState);
                await _unitOfWork.SaveChangesAsync();
            }

            transaction.Commit();
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