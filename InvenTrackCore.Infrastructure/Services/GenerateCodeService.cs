using InvenTrackCore.Application.Interfaces.Services;
using InvenTrackCore.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace InvenTrackCore.Infrastructure.Services;

public class GenerateCodeService : IGenerateCodeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;

    public GenerateCodeService(IUnitOfWork unitOfWork, ApplicationDbContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<string> GenerateCode(int EquipmentTypeId)
    {
        var equipmentType = await _unitOfWork.EquipmentType.GetByIdAsync(EquipmentTypeId);

        if (equipmentType is null)
        {
            return null!;
        }

        var prefix = equipmentType.Name.Substring(0, 3).ToUpper();

        var lastInventory = await _context.Inventories
            .Where(i => i.EquipmentTypeId == EquipmentTypeId)
            .OrderByDescending(i => i.Id)
            .FirstOrDefaultAsync();

        var number = lastInventory == null ? 1 : int.Parse(lastInventory.Code.Substring(3)) + 1;

        return $"{prefix}{number}";
    }

    public async Task<string> GenereteActive()
    {
        var lastInventory = await _context.Inventories
            .OrderByDescending(i => i.Id)
            .FirstOrDefaultAsync();

        var number = lastInventory == null ? 1 : int.Parse(lastInventory.Active.Substring(1)) + 1;

        return $"A{number}";
    }
}