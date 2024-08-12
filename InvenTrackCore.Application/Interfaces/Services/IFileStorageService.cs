using Microsoft.AspNetCore.Http;

namespace InvenTrackCore.Application.Interfaces.Services;

public interface IFileStorageService
{
    Task<string> SaveFile(string container, IFormFile file);
    Task<string> EditFile(string container, IFormFile file, string route);
    Task RemoveFile(string route, string container);
}