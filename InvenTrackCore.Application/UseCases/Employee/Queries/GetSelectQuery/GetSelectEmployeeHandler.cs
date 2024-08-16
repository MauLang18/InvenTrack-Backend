using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Commons.Select.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Employee.Queries.GetSelectQuery;

public class GetSelectEmployeeHandler : IRequestHandler<GetSelectEmployeeQuery, BaseResponse<IEnumerable<SelectResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSelectEmployeeHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<IEnumerable<SelectResponse>>> Handle(GetSelectEmployeeQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<SelectResponse>>();

        try
        {
            var employees = await _unitOfWork.Employee.GetSelectAsync();

            response.IsSuccess = true;
            response.Data = _mapper.Map<IEnumerable<SelectResponse>>(employees);
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