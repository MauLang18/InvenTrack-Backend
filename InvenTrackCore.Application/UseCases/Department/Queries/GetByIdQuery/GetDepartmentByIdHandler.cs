using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Department.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Department.Queries.GetByIdQuery;

public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, BaseResponse<DepartmentByIdResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDepartmentByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<DepartmentByIdResponseDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<DepartmentByIdResponseDto>();

        try
        {
            var department = await _unitOfWork.Department.GetByIdAsync(request.DepartmentId);

            if (department is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                return response;
            }

            response.IsSuccess = true;
            response.Data = _mapper.Map<DepartmentByIdResponseDto>(department);
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