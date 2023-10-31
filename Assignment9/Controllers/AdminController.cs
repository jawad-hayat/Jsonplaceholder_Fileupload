using Business.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.Role;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("createrole")]
        public async Task<IActionResult> CreateRole([FromQuery] RoleRequest role)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.CreateRole(role);
                return Ok(result);
            }
            return BadRequest("provide name");
        }

    }
}
