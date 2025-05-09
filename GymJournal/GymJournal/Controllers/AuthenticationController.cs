using GymJournal.DTOs;
using GymJournal.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymJournal.Controllers
{
    [Route("api/users")]
    public class AuthenticationController : BaseApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authentificationService)
        {
            _authenticationService = authentificationService;
        }

        [HttpPost]
        public ActionResult<AuthenticationTokenDTO> Register([FromBody] AccountRegistrationDTO account)
        {
            var result = _authenticationService.Register(account);
            return CreateResponse(result);
        }

        [HttpPost("login")]
        public ActionResult<AuthenticationTokenDTO> Login([FromBody] CredentialsDTO credentials)
        {
            var result = _authenticationService.Login(credentials);
            return CreateResponse(result);
        }

        [HttpGet("username/{userId:int}")]
        public ActionResult<CredentialsDTO> GetUsername([FromRoute] int userId)
        {
            var result = _authenticationService.GetUsername(userId);
            return CreateResponse(result);
        }
    }
}
