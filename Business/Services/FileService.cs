using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Models.Requests.Image;
using static Common.Utilities.Utility;
using System.Net.Http;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Compression;

namespace Business.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<byte[]> DownloadFile(int id)
        {
            string url = "https://jsonplaceholder.typicode.com/photos";
            var data = await GetData(url);
            if(id >= data.Count)
            {
                return null;
            }
            using HttpClient client = new HttpClient();
            var image = new ImageRequest();
            foreach (var item in data)
            {
                var DeserializeObj = JsonSerializer.Deserialize<ImageRequest>(item, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (DeserializeObj.Id == id)
                {
                    image = new ImageRequest
                    {
                        Id = DeserializeObj.Id,
                        Url = DeserializeObj.Url,
                        Title = DeserializeObj.Title,
                        ThumbnailUrl = DeserializeObj.ThumbnailUrl,
                        AlbumId = DeserializeObj.AlbumId
                    };
                    break;
                }
            }
            if (image == null)
            {
                return null;
            }
            // Download the image and return it as a file response
            var imageBytes = client.GetByteArrayAsync(image.Url).Result;
            return imageBytes;
            
        }

        public (string fileType, byte[] archiveData, string archiveName) DownloadZipFile(string dirName)
        {
            var files = Directory.GetFiles(Path.Combine(_webHostEnvironment.ContentRootPath, dirName)).ToList();
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream,ZipArchiveMode.Create))
                {
                    foreach (var file in files)
                    {
                        archive.CreateEntryFromFile(file,Path.GetFileName(file));
                    }
                }
                return ("application/zip", memoryStream.ToArray(), "images.zip");
            }
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadFiles");
            string filePath = Path.Combine(directoryPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return "file coppied successfully!";
        }
    }
}
