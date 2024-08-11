using System.Collections.Generic;

namespace FitLibrary.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
