using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Location.Commands.DeleteCommand;

public class DeleteLocationCommand : IRequest<BaseResponse<bool>>
{
    public int LocationId { get; set; }
}