using AutoMapper;
using GymJournal.DTOs;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using GymJournal.ServiceInterfaces;
using FluentResults;

namespace GymJournal.Services
{
    public class PersonEditingService : CrudService<PersonDTO,Person>, IPersonEditingService
    {
        private readonly IPersonRepository _personRepository;

        public PersonEditingService(ICrudRepository<Person> repository,IPersonRepository personRepository, IMapper mapper) : base(repository,mapper)
        {
            _personRepository = personRepository;
        }

        public Result<PersonDTO> GetPersonByUserId(int userId)
        {
            return MapToDto(_personRepository.GetByUserId(userId));
        }
    }
}
