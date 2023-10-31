using Models.Requests.Role;
using Models.Response;


namespace Business.Interfaces
{
    public interface IAdminService
    {
        public Task<ApiResponse> CreateRole(RoleRequest request);
    }
}
