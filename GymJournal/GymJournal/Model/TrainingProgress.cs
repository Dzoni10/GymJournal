namespace GymJournal.Model
{
    public class TrainingProgress
    {
        public int WeekNumber { get; init; }
        public int TotalTrainings { get; init; }
        public TimeSpan TotalDuration { get; init; }
        public double AverageDifficulty { get; set; }
        public double AverageFatigue { get; init; }

        public TrainingProgress() { }

        public TrainingProgress(int weekNumber, int totalTrainings, TimeSpan totalDuration, double averageDifficulty, double averageFatigue)
        {
            WeekNumber = weekNumber;
            TotalTrainings = totalTrainings;
            TotalDuration = totalDuration;
            AverageDifficulty = averageDifficulty;
            AverageFatigue = averageFatigue;
        }
    }
}
