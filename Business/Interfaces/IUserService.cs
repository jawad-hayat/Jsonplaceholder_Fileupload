using Models.Requests.User;
using Models.Response;

namespace Business.Interfaces
{
    public interface IUserService
    {
        public Task<ApiResponse> CreateAdmin(UserSignupRequest request);
        public Task<ApiResponse> CreateUsers(UserSignupRequest request);
        public Task<ApiResponse> Login(UserSigninRequest request);
    }
}
