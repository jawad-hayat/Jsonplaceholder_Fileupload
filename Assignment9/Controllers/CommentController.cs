using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Comments;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {            
            _commentService = commentService;
        }
        [HttpPost("createcomment")]
        public async Task<IActionResult> CreateComment(CommentRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _commentService.CreateComment(request);
                return Ok(result);
            }
            return BadRequest("provide comment details");
        }
    }
}
