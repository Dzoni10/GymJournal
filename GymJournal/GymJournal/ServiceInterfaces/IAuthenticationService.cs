using GymJournal.DTOs;
using FluentResults;

namespace GymJournal.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Result<AuthenticationTokenDTO> Register(AccountRegistrationDTO account);
        Result<AuthenticationTokenDTO> Login(CredentialsDTO ceredentials);
        Result<CredentialsDTO> GetUsername (long userId);
    }
}
