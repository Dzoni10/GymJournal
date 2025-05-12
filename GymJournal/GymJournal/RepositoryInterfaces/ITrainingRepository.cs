using GymJournal.DTOs;
using GymJournal.Model;

namespace GymJournal.RepositoryInterfaces
{
    public interface ITrainingRepository
    {
        ICollection<Training> GetAll();
        IQueryable<Training> GetAllUserTrainings(int userId);
        Training GetByTrainingId(int trainingId);
        void Create(Training training);
        IQueryable<Training> GetCardio();
        IQueryable<Training> GetStrength();
        IQueryable<Training> GetFlexibility();

        Task<List<TrainingProgress>> GetWeeklyProgress(long userId, int year, int month);

    }
}
