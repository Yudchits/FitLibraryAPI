namespace FitLibrary.DataAccess.Common.Models
{
    public class ExerciseDb
    {
        public int Id { get; set; }
        public int? Week { get; set; }
        public string ExerciseName { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public decimal? Weight { get; set; }
        public string Time { get; set; } = null!;
        public string RestPeriod { get; set; } = null!;
        public int TrainingPlanId { get; set; }
        public virtual TrainingPlanDb TrainingPlan { get; set; }
    }
}
