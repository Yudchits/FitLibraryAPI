using System.Collections.Generic;

namespace FitLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TrainingPlan> TrainingPlans { get; set; }
    }
}
