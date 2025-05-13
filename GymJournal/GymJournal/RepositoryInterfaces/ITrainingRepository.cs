using GymJournal.DTOs;
using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface ITrainingRepository
    {
        IQueryable<Training> GetAllUserTrainings(int userId);
        Task<List<TrainingProgress>> GetWeeklyProgress(long userId, int year, int month);

    }
}
