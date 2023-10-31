
using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Models.Requests.User;
using Models.Response;


namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public UserService(UserManager<User> userManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<ApiResponse> CreateAdmin(UserSignupRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return new ApiResponse { 
                    Success = false,
                    ErrorMessage = "User Already Exists!"
                };
            }
            var newUser = new User 
            {
                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                Website = request.Website,
                Street = request.Street,
                Suite = request.Suite,
                City = request.City,
                ZipCode = request.ZipCode,
                Lat = request.Lat,
                Lng = request.Lng,
                CompanyName = request.CompanyName,
                CatchPhrase = request.CatchPhrase,
                Bs = request.Bs
            };
            var isCreated = await _userManager.CreateAsync(newUser, request.Password);
            if (isCreated.Succeeded)
            {
                //Assign the Admin Role
                var result = await _userManager.AddToRoleAsync(newUser, "Admin");
                if (result.Succeeded)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "User "+newUser.UserName+" has admin access now!"
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        ErrorMessage = "User " + newUser.UserName + " has been created but doesnot have admin rights!"
                    };
                }
            }
            else
            {
                return new ApiResponse
                {
                    Success = false,
                    ErrorMessage = "unable to create Admin!"
                };
            }


        }

        public async Task<ApiResponse> CreateUsers(UserSignupRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return new ApiResponse
                {
                    Success = false,
                    ErrorMessage = "User Already Exists!"
                };
            }
            var newUser = new User
            {
                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                Website = request.Website,
                Street = request.Street,
                Suite = request.Suite,
                City = request.City,
                ZipCode = request.ZipCode,
                Lat = request.Lat,
                Lng = request.Lng,
                CompanyName = request.CompanyName,
                CatchPhrase = request.CatchPhrase,
                Bs = request.Bs
            };
            var isCreated = await _userManager.CreateAsync(newUser, request.Password);
            if (isCreated.Succeeded)
            {
                //Assign the Admin Role
                var result = await _userManager.AddToRoleAsync(newUser, "Employee");
                if (result.Succeeded)
                {
                    return new ApiResponse
                    {
                        Success = true,
                        Message = "User " + newUser.UserName + " has employee rights!"
                    };
                }
                else
                {
                    return new ApiResponse
                    {
                        Success = false,
                        ErrorMessage = "User " + newUser.UserName + " has been created but doesnot have Employee rights!"
                    };
                }
            }
            else
            {
                return new ApiResponse
                {
                    Success = false,
                    ErrorMessage = "unable to create user!"
                };
            }
        }

        public async Task<ApiResponse> Login(UserSigninRequest request)
        {
            var userExist = await _userManager.FindByEmailAsync(request.Email);
            if (userExist == null)
            {
                return new ApiResponse()
                {
                    ErrorMessage = "User Doesnot Exists! Please Register First",
                    Success = false
                };
            }

            var isValid = await _userManager.CheckPasswordAsync(userExist, request.Password);

            if (!isValid)
            {                
                return new ApiResponse()
                {
                    ErrorMessage = "Password Doesnot Match",
                    Success = false
                };
            }
            if (!userExist.EmailConfirmed)
            {
                return new ApiResponse()
                {
                    ErrorMessage = "Please check your email and confirm your email before trying to login",
                    Success = false
                };
            }

            var jwtToken = await _tokenService.GenerateJwtToken(userExist);
            return jwtToken;
        }
    }
}
