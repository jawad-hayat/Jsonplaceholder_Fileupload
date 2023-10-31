using Business.Interfaces;
using Business.Services;
using Dapper;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models.Requests.Album;
using Models.Requests.Post;
using Models.Requests.Todo;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlbumController : ControllerBase
    {        
        private readonly IAlbumService _albumService;
        
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
            
        }
        [HttpPost("createalbum")]
        public async Task<IActionResult> CreateAlbum(AlbumRequest request)
        {
            request.UserId = int.Parse(_albumService.GetLoggedInUserId());
            if (ModelState.IsValid)
            {
                var result = _albumService.CreateAlbum(request);
                if (result != null) return Ok(result);
                return Ok("unable to create album!");
            }
            return BadRequest("provide album details");
        }

        [HttpPost("updatealbum")]
        public async Task<IActionResult> UpdateAlbum([FromBody] AlbumRequest request, int id)
        {
            request.UserId = int.Parse(_albumService.GetLoggedInUserId());
            if (ModelState.IsValid)
            {
                var result = _albumService.UpdateAlbum(request, id);
                if (result != null) return Ok(result);
                return Ok("unable to create album!");
            }
            return BadRequest("provide valid albums details!");
        }

        [HttpGet("getalbums")]
        public async Task<IActionResult> GetAllAlbums()
        {
            var result = _albumService.GetAllAlbums();
            if (result != null) return Ok(result);
            return Ok("no albums found!");           

        }
        
        [HttpGet("getalbumbyid")]
        public async Task<IActionResult> GetAlbumById([FromQuery] int id)
        {
            var result = _albumService.GetAlbumById(id);
            if (result != null) return Ok(result);
            return Ok("no album found!");

        }

        [HttpGet("deletealbumbyid")]
        public async Task<IActionResult> DeleteAlbumById([FromQuery] int id)
        {
            var result = _albumService.DeleteAlbumById(id);
            if (result) return Ok("Album deleted successfully");
            return Ok("no album found!");

        }

    }
}
