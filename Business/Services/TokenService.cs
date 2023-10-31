

using Business.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Models.ConfigModels;
using Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtConfig _jwtConfig;
        private readonly UserManager<User> _userManager;

        public TokenService(JwtConfig jwtConfig, UserManager<User> userManager)
        {            
            _jwtConfig = jwtConfig;
            _userManager = userManager;
        }

        public JwtConfig JwtConfig { get; }

        public async Task<ApiResponse> GenerateJwtToken(User user)
        {
            var userRole = await _userManager.GetRolesAsync(user);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, userRole[0]),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwtConfig.ExpirationTime)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return new ApiResponse()
            {
                Token = jwtToken,
                Email = user.Email,
                UserId = user.Id.ToString(),
                Name = user.Name,
                Success = true,
                Role = userRole[0]
            };

        }
    }
}
