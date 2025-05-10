using GymJournal.Model;

namespace GymJournal.DTOs
{
    public class TrainingDTO
    {
        public long UserId { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public int Duration { get; set; }
        public double Calories { get; set; }
        public int Difficulty { get; set; } //1-10 
        public int Fatigue { get;set; } //1-10
        public string Note { get; set; }

        public DateTime Date {get; set; }
    }
}
