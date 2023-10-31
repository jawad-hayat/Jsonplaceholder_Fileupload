using Microsoft.AspNetCore.Http;
using Models.Requests.Image;

namespace Business.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFile(IFormFile file);
        Task<byte[]> DownloadFile(int id);
        (string fileType, byte[] archiveData, string archiveName) DownloadZipFile(string dirName);
    }
}
