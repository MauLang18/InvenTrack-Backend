using InvenTrackCore.Application.Commons.Bases;
using MediatR;

namespace InvenTrackCore.Application.UseCases.Location.Commands.CreateCommand;

public class CreateLocationCommand : IRequest<BaseResponse<bool>>
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int State { get; set; }
}