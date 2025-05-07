using GymJournal.Model;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FluentResults;
using GymJournal.DTOs;
namespace GymJournal.Infrastructure.Authentication
{
    public class JWTGeneratot
    {
        private readonly string _key = Environment.GetEnvironmentVariable("JWT_KEY") ?? "gym_journal_secret_key";
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
