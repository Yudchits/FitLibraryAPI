namespace FitLibrary.Logic.Common.Models
{
    public class ExerciseBLL
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
