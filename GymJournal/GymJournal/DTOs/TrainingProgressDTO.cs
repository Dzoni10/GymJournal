namespace GymJournal.DTOs
{
    public class TrainingProgressDTO
    {
        public int WeekNumber { get; set; }
        public int TotalTrainings { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public double AverageDifficulty { get; set; }
        public double AverageFatigue { get; set; }
    }
}
