using FitLibrary.DataAccess.Common.Helpers;

namespace FitLibrary.DataAccess.Common.Models
{
    public class ExerciseDb
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public Weekday Weekday { get; set; }
        public string ExerciseName { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public decimal? Weight { get; set; }
        public int? Time { get; set; }
        public int? RestPeriod { get; set; }
        public int TrainingPlanId { get; set; }
        public virtual TrainingPlanDb TrainingPlan { get; set; }
    }
}
