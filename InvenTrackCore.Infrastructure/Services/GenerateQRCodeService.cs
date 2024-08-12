using InvenTrackCore.Application.Interfaces.Services;
using IronQr;
using IronSoftware.Drawing;
using System.Text.Json;

namespace InvenTrackCore.Infrastructure.Services;

public class GenerateQRCodeService : IGenerateQRCodeService
{
    public byte[] GenerateQRCode<T>(T data)
    {
        string jsonData = JsonSerializer.Serialize(data);

        QrCode qrCode = QrWriter.Write(jsonData);

        AnyBitmap qrBitmap = qrCode.Save();

        string tempFilePath = Path.GetTempFileName() + ".png";

        qrBitmap.SaveAs(tempFilePath);

        byte[] qrCodeBytes = File.ReadAllBytes(tempFilePath);

        File.Delete(tempFilePath);

        return qrCodeBytes;
    }
}