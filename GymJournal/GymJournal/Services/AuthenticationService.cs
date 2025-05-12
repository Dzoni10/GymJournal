

using FluentResults;
using GymJournal.DTOs;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using GymJournal.ServiceInterfaces;
using GymJournal.Startup;

namespace GymJournal.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly ICrudRepository<Person> _personRepository;

        public AuthenticationService(IUserRepository userRepository, ICrudRepository<Person> personRepository, ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
            _personRepository = personRepository;
        }


        public Result<AuthenticationTokenDTO> Login(CredentialsDTO credentials)
        {
            var user = _userRepository.GetActiveByName(credentials.Username);
            if (user == null || credentials.Password != user.Password) return Result.Fail(FailureCode.NotFound);

            long personId;
            try
            {
                personId = _userRepository.GetPersonId(user.Id);
            }
            catch (KeyNotFoundException)
            {
                personId = 0;
            }
            return _tokenGenerator.GenerateAccessToken(user, personId);
        }


        public Result<AuthenticationTokenDTO> Register(AccountRegistrationDTO account)
        {
            if (_userRepository.Exists(account.Username)) return Result.Fail(FailureCode.NonUniqueUsername);

            try
            {
                var user = _userRepository.Create(new User(account.Username, account.Password));
                var person = _personRepository.Create(new Person(user.Id, account.Name, account.Surname, account.Email, account.Phone));

                return _tokenGenerator.GenerateAccessToken(user, person.Id);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<CredentialsDTO> GetUsername(long userId)
        {
            var user = _userRepository.GetUsername(userId);
            CredentialsDTO dto = new CredentialsDTO { Password = user.Password, Username = user.Username };
            return dto;
        }

        public Result<string> GetUserNameById(long userId)
        {
            var name = _userRepository.GetUserNameById(userId);
            return Result.Ok(name);
        }
    }

}
