
using Business.Interfaces;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Models.Requests.Comments;
using Models.Requests.Post;
using Models.Response;

namespace Business.Services
{
    public class CommentService : ICommentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CommentService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<ApiResponse> CreateComment(CommentRequest request)
        {
            var newPost = new Comment()
            {
                PostId = 1,
                Name = request.Name,
                Email = request.Email,
                Body = request.Body
            };
            var isCreated = await _context.Comments.AddAsync(newPost);
            if (isCreated != null)
            {
                _context.SaveChanges();
                return new ApiResponse
                {
                    Success = true,
                    Message = "Comment Created Successfully!"
                };
            }
            return new ApiResponse
            {
                Success = false,
                Message = "unable to create Comment!"
            };
        }

        public string GetLoggedInUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        }
    }
}
