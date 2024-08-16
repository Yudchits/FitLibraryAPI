namespace FitLibrary.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public int? Week { get; set; }
        public string ExerciseName { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public double? Weight { get; set; }
        public string Time { get; set; } = null!;
        public string RestPeriod { get; set; } = null!;
        public int TrainingPlanId { get; set; }
        public virtual TrainingPlan TrainingPlan { get; set; }
    }
}
