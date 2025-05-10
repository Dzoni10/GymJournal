using GymJournal.Infrastructure;
using GymJournal.Infrastructure.Database;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GymJournal.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly GymJournalContext _dbContext;


        public TrainingRepository(GymJournalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Training> GetAll()
        {
            return _dbContext.Training.ToList();
        }

       public ICollection<Training> GetAllUserTrainings(int userId)
        {
            return _dbContext.Training.Where(t => t.UserId == userId).ToList();
        }

        public Training GetByTrainingId(int trainingId)
        {
            return _dbContext.Training.SingleOrDefault(t => t.Id == trainingId);
        }

        public void Create(Training training)
        {
            _dbContext.Training.Add(training);
            _dbContext.SaveChanges();
        }

        public IQueryable<Training> GetCardio()
        {
            return _dbContext.Training.Where(t=>t.ExerciseType == ExerciseType.CARDIO); 
        }

        public IQueryable<Training> GetStrength()
        {
            return _dbContext.Training.Where(t => t.ExerciseType == ExerciseType.STRENGTH);
        }

        public IQueryable<Training> GetFlexibility()
        {
            return _dbContext.Training.Where(t => t.ExerciseType == ExerciseType.FLEXIBILITY);
        }
    }

}
