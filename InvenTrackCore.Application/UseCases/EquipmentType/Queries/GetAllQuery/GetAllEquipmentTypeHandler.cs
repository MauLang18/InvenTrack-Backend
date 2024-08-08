using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.EquipmentType.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.EquipmentType.Queries.GetAllQuery;

public class GetAllEquipmentTypeHandler : IRequestHandler<GetAllEquipmentTypeQuery, BaseResponse<IEnumerable<EquipmentTypeResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderingQuery _ordering;

    public GetAllEquipmentTypeHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery ordering)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ordering = ordering;
    }

    public async Task<BaseResponse<IEnumerable<EquipmentTypeResponseDto>>> Handle(GetAllEquipmentTypeQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<EquipmentTypeResponseDto>>();

        try
        {
            var equipmentTypes = _unitOfWork.EquipmentType.GetAllQueryable();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumPage)
                {
                    case 1:
                        equipmentTypes = equipmentTypes.Where(x => x.Name.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                equipmentTypes = equipmentTypes.Where(x => x.State == request.StateFilter);
            }

            if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
            {
                equipmentTypes = equipmentTypes.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate).ToUniversalTime() &&
                                                           x.AuditCreateDate <= Convert.ToDateTime(request.EndDate).ToUniversalTime().AddDays(1));
            }

            request.Sort ??= "Id";

            var items = await _ordering.Ordering(request, equipmentTypes)
                .ToListAsync(cancellationToken);

            response.IsSuccess = true;
            response.TotalRecords = await equipmentTypes.CountAsync(cancellationToken);
            response.Data = _mapper.Map<IEnumerable<EquipmentTypeResponseDto>>(items);
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