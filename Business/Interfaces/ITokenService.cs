
using Domain.Models;
using Models.Response;

namespace Business.Interfaces
{
    public interface ITokenService
    {
        Task<ApiResponse> GenerateJwtToken(User user);
    }
}
