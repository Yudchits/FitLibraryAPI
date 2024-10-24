using FitLibrary.DataAccess.Common.Helpers;

namespace FitLibrary.Logic.Common.Models
{
    public class ExerciseBLL
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public Weekday Weekday { get; set; }
        public string ExerciseName { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public double? Weight { get; set; }
        public int? Time { get; set; }
        public int? RestPeriod { get; set; }
    }
}