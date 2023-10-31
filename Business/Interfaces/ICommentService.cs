
using Models.Requests.Comments;
using Models.Requests.Post;
using Models.Response;

namespace Business.Interfaces
{
    public interface ICommentService
    {
        public string GetLoggedInUserId();

        public Task<ApiResponse> CreateComment(CommentRequest request);
    }
}
