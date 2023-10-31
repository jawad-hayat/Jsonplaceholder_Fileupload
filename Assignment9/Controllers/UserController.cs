using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Requests.User;
using System.Text.Json.Nodes;
using static Common.Utilities.Utility;

namespace Assignment9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createadmin")]
        public async Task<IActionResult> CreateAdmin(UserSignupRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateAdmin(request);
                return Ok(result);
            }
            return BadRequest("provide name");
        }

        [HttpGet("createuser")]
        public async Task<IActionResult> CreateUser([FromQuery] string url)
        {
            if (ModelState.IsValid)
            {
                var users = new List<dynamic>();
                users = await GetData(url);
                var request = new UserSignupRequest();
                foreach (dynamic user in users)
                {
                    var dataString = user.ToString();
                    JsonNode data = JsonNode.Parse(dataString);
                    request.Name = (string)data["name"];
                    request.UserName = (string)data["username"];
                    request.Email = (string)data["email"];
                    request.Phone = (string)data["phone"];
                    request.Website = (string)data["website"];
                    request.Street = (string)data["address"]["street"];
                    request.Suite = (string)data["address"]["suite"];
                    request.City = (string)data["address"]["city"];
                    request.ZipCode = (string)data["address"]["zipcode"];
                    request.Lat = (string)data["address"]["geo"]["lat"];
                    request.Lng = (string)data["address"]["geo"]["lng"];
                    request.CompanyName = (string)data["company"]["name"];
                    request.CatchPhrase = (string)data["company"]["catchPhrase"];
                    request.Bs = (string)data["company"]["bs"];
                    request.Password = "String@123";
                    await _userService.CreateUsers(request);                    
                }
                return Ok("all users have been created successfully");
            }
            return BadRequest("provide name");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(UserSigninRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(request);
                return Ok(result);
            }
            return BadRequest("provide name");
        }
    }
}
