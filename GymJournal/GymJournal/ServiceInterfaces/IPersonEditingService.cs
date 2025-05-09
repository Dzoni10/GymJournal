using FluentResults;
using GymJournal.DTOs;
using GymJournal.Infrastructure;

namespace GymJournal.ServiceInterfaces
{
    public interface IPersonEditingService
    {
        Result<PersonDTO> Get(int id);
        Result<PersonDTO> Update(PersonDTO personDTO);
        Result<PagedResult<PersonDTO>> GetPaged(int page,int pageSize);
        Result<PersonDTO> GetPersonByUserId(int userId);
    }
}
