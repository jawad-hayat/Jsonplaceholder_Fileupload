
using Models.Requests.Post;
using Models.Requests.Todo;
using Models.Response;

namespace Business.Interfaces
{
    public interface IPostService
    {
        public string GetLoggedInUserId();

        public Task<ApiResponse> CreatePost(PostRequest request);
    }
}
