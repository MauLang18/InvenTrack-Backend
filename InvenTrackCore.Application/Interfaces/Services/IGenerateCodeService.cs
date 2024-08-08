namespace InvenTrackCore.Application.Interfaces.Services;

public interface IGenerateCodeService
{
    Task<string> GenerateCode(int EquipmentTypeId);
    Task<string> GenereteActive();
}