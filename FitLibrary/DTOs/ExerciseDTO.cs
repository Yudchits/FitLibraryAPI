namespace FitLibrary.DTOs
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
        public string Time { get; set; }
        public string RestPeriod { get; set; }
        public int TrainingPlanId { get; set; }
    }
}
