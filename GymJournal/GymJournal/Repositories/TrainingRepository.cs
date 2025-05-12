using GymJournal.Infrastructure;
using GymJournal.Infrastructure.Database;
using GymJournal.Model;
using GymJournal.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Globalization;

namespace GymJournal.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly GymJournalContext _dbContext;


        public TrainingRepository(GymJournalContext dbContext)
        {
            _dbContext = dbContext;
        }

       public IQueryable<Training> GetAllUserTrainings(int userId)
        {
            return _dbContext.Training.Where(t => t.UserId == userId);
        }

        public async Task<List<TrainingProgress>> GetWeeklyProgress(long userId, int year, int month)
        {
            var trainingsInMonth = await _dbContext.Training
                .Where(t => t.UserId == userId &&
                            t.Date.Year == year &&
                            t.Date.Month == month)
                .ToListAsync();

            var groupedByWeek = trainingsInMonth
                .GroupBy(t => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    t.Date,
                    CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday)) 
                .Select(g => new TrainingProgress
                {
                    WeekNumber = g.Key,
                    TotalTrainings = g.Count(),
                    TotalDuration = TimeSpan.FromMinutes(g.Sum(t => t.Duration)),
                    AverageDifficulty = g.Average(t => t.Difficulty),
                    AverageFatigue = g.Average(t => t.Fatigue)
                })
                .OrderBy(p => p.WeekNumber)
                .ToList();

            return groupedByWeek;
        }

    }

}
