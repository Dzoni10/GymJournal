using FluentResults;
using GymJournal.DTOs;
using GymJournal.Infrastructure;

namespace GymJournal.ServiceInterfaces
{
    public interface ITrainingService
    {
        Result<TrainingDTO> Get(int id);
        Result<TrainingDTO> Create(TrainingDTO trainingDTO);
        Result<PagedResult<TrainingDTO>> GetUserTrainings(int userId,int page,int pageSize);
        Task<List<TrainingProgressDTO>> GetWeeklyProgressAsync(long userId, int year, int month);
    }
}
