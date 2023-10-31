using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Models.Requests.Role;
using Models.Response;

namespace Business.Services
{
    public class AdminService : IAdminService
    {
        private readonly RoleManager<Role> _roleManager;

        public AdminService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ApiResponse> CreateRole(RoleRequest request)
        {
            Role identityRole = new Role
            {
                Name = request.Name
            };
            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return new ApiResponse()
                {
                    Message = "Role Created Successfully",
                    Success = true
                };
            }
            return new ApiResponse()
            {
                ErrorMessage = "Role Already Exists",
                Success = false
            };
        }
    }
}
