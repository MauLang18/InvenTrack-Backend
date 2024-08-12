using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Employee.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Employee.Queries.GetByIdQuery;

public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, BaseResponse<EmployeeByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEmployeeByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<EmployeeByIdResponseDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<EmployeeByIdResponseDto>();

        try
        {
            var employee = await _unitOfWork.Employee.GetByIdAsync(request.EmployeeId);

            if (employee is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<EmployeeByIdResponseDto>(employee);
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