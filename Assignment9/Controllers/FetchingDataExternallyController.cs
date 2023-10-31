using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Common.Utilities.Utility;


namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FetchingDataExternallyController : ControllerBase
    {
        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {

            var posts = new List<dynamic>();
            var url = "https://jsonplaceholder.typicode.com/posts/";
            posts = await GetData(url);
            return Ok(posts);
            
        }

        [HttpGet("comments")]
        public async Task<IActionResult> GetComments()
        {

            var comments = new List<dynamic>();
            comments = await GetData("https://jsonplaceholder.typicode.com/comments/");
            return Ok(comments);

        }

        [HttpGet("albums")]
        public async Task<IActionResult> GetAlbums()
        {

            var albums = new List<dynamic>();
            albums = await GetData("https://jsonplaceholder.typicode.com/albums/");
            return Ok(albums);

        }
        [HttpGet("photos")]
        public async Task<IActionResult> GetPhotos()
        {

            var photos = new List<dynamic>();
            photos = await GetData("https://jsonplaceholder.typicode.com/photos/");
            return Ok(photos);

        }
        [HttpGet("todos")]
        public async Task<IActionResult> GetTodos()
        {

            var todos = new List<dynamic>();
            todos = await GetData("https://jsonplaceholder.typicode.com/todos/");
            return Ok(todos);

        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {

            var users = new List<dynamic>();
            users = await GetData("https://jsonplaceholder.typicode.com/users/");
            return Ok(users);

        }           

    }
}
