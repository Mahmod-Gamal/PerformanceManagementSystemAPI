using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.DTOs;
using PerformanceManagementSystem.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PerformanceManagementSystem.Infrastructure.Identity
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private Double DurationInDays;
        public JwtProvider(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
        {
            _jwtOptions = jwtOptions.Value;
            DurationInDays = _jwtOptions.DurationInDays;
            _httpContextAccessor = httpContextAccessor;
        }

        double IJwtProvider.DurationInDays { get => _jwtOptions.DurationInDays; }

        public string GenerateToken(User user)
        {

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier , user.ID.ToString()),
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Role , user.UserTypeId.ToString()),
                new Claim(ClaimTypes.UserData , user.TokenVersion.ToString())
            };

            // GetSecretKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_jwtOptions.SecretKey));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(_jwtOptions.DurationInDays),
                SigningCredentials = signingCredentials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        public UserClaims GetUserClaims()
        {
            var jwtToken = "";// (string)_httpContextAccessor.HttpContext?.Request.Headers.Authorization;
            jwtToken = jwtToken?.Replace("bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(jwtToken);
            UserClaims userClaims = new UserClaims()
            {
                Id = int.Parse(securityToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value),
                AccessMode = bool.Parse(securityToken.Claims.FirstOrDefault(c => c.Type == "AccessMode")?.Value),
                UserType = securityToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value,
                TokenVersion = Guid.Parse(securityToken.Claims.FirstOrDefault(c => c.Type == "UserData")?.Value)
            };
            return userClaims;
        }
    }
}
