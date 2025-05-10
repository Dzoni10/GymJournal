using FluentResults;
using GymJournal.DTOs;
using GymJournal.Infrastructure;

namespace GymJournal.ServiceInterfaces
{
    public interface ITrainingService
    {
        Result<TrainingDTO> Get(int id);
        Result<TrainingDTO> Create(TrainingDTO trainingDTO);
        Result<TrainingDTO> Update(TrainingDTO trainingDTO);
        Result<PagedResult<TrainingDTO>> GetPaged(int page,int pageSize);
        Result<PagedResult<TrainingDTO>> GetCardio(int page,int pageSize);

        Result<PagedResult<TrainingDTO>> GetStrength(int page, int pageSize);

        Result<PagedResult<TrainingDTO>> GetFlexibility(int page, int pageSize);
        //Result<PagedResult<TrainingDTO>> GetTrainingsByUserId(int userId);
    }
}
