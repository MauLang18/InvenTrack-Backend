using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Location.Commands.UpdateCommand;

public class UpdateLocationCommand : IRequest<BaseResponse<bool>>
{
    public int LocationId { get; set; }
    public string Name { get; set; } = null!;
    public string Adress { get; set; } = null!;
    public int State { get; set; }
}