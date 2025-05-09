using GymJournal.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FluentResults;
using GymJournal.DTOs;
using GymJournal.ServiceInterfaces;
namespace GymJournal.Infrastructure.Authentication
{
    public class JWTGenerator : ITokenGenerator
    {
        private readonly string _key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "this_is_a_super_secret_key_with_32_chars_and_more_than_that";
        private readonly string _issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "gymjournal";
        private readonly string _audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "gymjournal-front.com";


        public Result<AuthenticationTokenDTO> GenerateAccessToken(User user, long personId) { 
        
            var authenticationResponse = new AuthenticationTokenDTO();

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("id", user.Id.ToString()),
            new("username", user.Username),
            new("personId", personId.ToString())
        };

            var jwt = CreateToken(claims, 60 * 24);
            authenticationResponse.Id = user.Id;
            authenticationResponse.AccessToken = jwt;

            return authenticationResponse;
        }
        private string CreateToken(IEnumerable<Claim> claims, double expirationTimeInMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.Now.AddMinutes(expirationTimeInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }



}
