using Business.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Post;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpPost("createpost")]
        public async Task<IActionResult> CreatePost(PostRequest request)
        {
            request.UserId = int.Parse(_postService.GetLoggedInUserId());
            if (ModelState.IsValid)
            {
                var result = _postService.CreatePost(request);
                return Ok(result);
            }
            return BadRequest("provide todo details");
        }
    }
}
