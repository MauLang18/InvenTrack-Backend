namespace InvenTrackCore.Application.Interfaces.Services;

public interface IGeneratePdfService
{
    byte[] GeneratePdf(string ticket);
}