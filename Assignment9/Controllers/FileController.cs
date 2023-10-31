using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;

        public FileController(IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        [HttpPost("uploadfile")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {
            if(files.Count == 0)
            {
                return BadRequest();
            }
            foreach(var file  in files)
            {
                _fileService.UploadFile(file);
            }
            return Ok("upload successful");
        }

        [HttpGet("downloadfile")]
        public async Task<IActionResult> DownloadFiles(int id)
        {
            if (id == null || id < 0)
            {
                return BadRequest();
            }
            var imageBytes = await _fileService.DownloadFile(id);
            if (imageBytes == null)
            {
                return BadRequest("please enter id between 0 - 4999");
            }
            return File(imageBytes, "image/jpeg", id.ToString());
        }

        [HttpGet("downloadzipfile")]
        public async Task<IActionResult> DownloadZip()
        {
            var (fileType,bytes,fileName) = _fileService.DownloadZipFile("UploadFiles");
            if (bytes == null)
            {
                return BadRequest("no file found");
            }
            return File(bytes,fileType,fileName);
        }

    }
}
