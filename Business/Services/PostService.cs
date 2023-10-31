
using Business.Interfaces;
using Data.Context;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Models.Requests.Post;
using Models.Requests.Todo;
using Models.Response;

namespace Business.Services
{
    public class PostService : IPostService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public PostService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<ApiResponse> CreatePost(PostRequest request)
        {
            var newPost = new Post()
            {
                UserId = request.UserId,
                Title = request.Title,
                Body = request.Body
            };
            var isCreated = await _context.Posts.AddAsync(newPost);
            if (isCreated != null)
            {
                _context.SaveChanges();
                return new ApiResponse
                {
                    Success = true,
                    Message = "Post Created Successfully!"
                };
            }
            return new ApiResponse
            {
                Success = false,
                Message = "unable to create Post!"
            };
        }

        public string GetLoggedInUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        }
    }
}
