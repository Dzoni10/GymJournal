using FluentResults;
using GymJournal.DTOs;
using GymJournal.Model;

namespace GymJournal.ServiceInterfaces
{
    public interface ITokenGenerator
    {
        Result<AuthenticationTokenDTO> GenerateAccessToken(User user, long personId);
    }
}
