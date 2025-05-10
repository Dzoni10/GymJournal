namespace GymJournal.Model
{
    public enum ExerciseType
    {
        CARDIO,
        STRENGTH,
        FLEXIBILITY
    }
    
    public class Training : Entity
    {
        public long UserId {  get; init; }
        public ExerciseType ExerciseType { get; init; }
        public int Duration { get; init; }
        public double Calories { get; init; }
        public int Difficulty { get;init;} //1-10 
        public int Fatigue { get; init; } //1-10
        public string Note { get; init; }

        public DateTime Date { get; init; }

        public Training(long userId,ExerciseType exerciseType,int duration,double calories,int difficulty,int fatigue,string note, DateTime date)
        {
            UserId = userId;
            ExerciseType = exerciseType;
            Duration = duration;
            Calories = calories;
            Difficulty = difficulty;
            Fatigue = fatigue;
            Note = note;
            Date = date;
        }

        public Training() { }
    }
}
