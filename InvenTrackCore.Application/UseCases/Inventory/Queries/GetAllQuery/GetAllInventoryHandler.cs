﻿using AutoMapper;
using InvenTrackCore.Application.Commons.Bases;
using InvenTrackCore.Application.Dtos.Inventory.Response;
using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Utilities.Static;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WatchDog;

namespace InvenTrackCore.Application.UseCases.Inventory.Queries.GetAllQuery;

public class GetAllInventoryHandler : IRequestHandler<GetAllInventoryQuery, BaseResponse<IEnumerable<InventoryResponseDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderingQuery _ordering;

    public GetAllInventoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IOrderingQuery ordering)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _ordering = ordering;
    }

    public async Task<BaseResponse<IEnumerable<InventoryResponseDto>>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<IEnumerable<InventoryResponseDto>>();

        try
        {
            var inventories = _unitOfWork.Inventory.GetAllQueryable();

            if (request.NumFilter is not null && !string.IsNullOrEmpty(request.TextFilter))
            {
                switch (request.NumFilter)
                {
                    case 1:
                        inventories = inventories.Where(x => x.Code.Contains(request.TextFilter));
                        break;
                    case 2:
                        inventories = inventories.Where(x => x.Active.Contains(request.TextFilter));
                        break;
                    case 3:
                        inventories = inventories.Where(x => x.EquipmentTypes.Name.Contains(request.TextFilter));
                        break;
                    case 4:
                        inventories = inventories.Where(x => x.Brand.Contains(request.TextFilter));
                        break;
                    case 5:
                        inventories = inventories.Where(x => x.Series.Contains(request.TextFilter));
                        break;
                    case 6:
                        inventories = inventories.Where(x => x.Model.Contains(request.TextFilter));
                        break;
                }
            }

            if (request.StateFilter is not null)
            {
                inventories = inventories.Where(x => x.State == request.StateFilter);
            }

            if (!string.IsNullOrEmpty(request.StartDate) && !string.IsNullOrEmpty(request.EndDate))
            {
                inventories = inventories.Where(x => x.AuditCreateDate >= Convert.ToDateTime(request.StartDate).ToUniversalTime() &&
                                                     x.AuditCreateDate <= Convert.ToDateTime(request.EndDate).ToUniversalTime().AddDays(1));
            }

            request.Sort ??= "Id";

            var items = await _ordering.Ordering(request, inventories)
                .ToListAsync(cancellationToken);

            response.IsSuccess = true;
            response.TotalRecords = await inventories.CountAsync(cancellationToken);
            response.Data = _mapper.Map<IEnumerable<InventoryResponseDto>>(items);
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