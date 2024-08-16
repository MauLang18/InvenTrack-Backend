using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Location.Queries.GetSelectQuery;

public class GetSelectLocationHandler : IRequestHandler<GetSelectLocationQuery, BaseResponse<IEnumerable<SelectResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSelectLocationHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<IEnumerable<SelectResponse>>> Handle(GetSelectLocationQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<SelectResponse>>();

        try
        {
            var locations = await _unitOfWork.Location.GetSelectAsync();

            response.IsSuccess = true;
            response.Data = _mapper.Map<IEnumerable<SelectResponse>>(locations);
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