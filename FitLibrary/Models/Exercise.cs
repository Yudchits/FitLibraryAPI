namespace FitLibrary.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
        public string RestPeriod { get; set; }
    }
}
