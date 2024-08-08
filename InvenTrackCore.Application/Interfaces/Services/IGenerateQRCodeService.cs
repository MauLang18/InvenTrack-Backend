namespace InvenTrackCore.Application.Interfaces.Services;

public interface IGenerateQRCodeService
{
    byte[] GenerateQRCode<T>(T data);
}