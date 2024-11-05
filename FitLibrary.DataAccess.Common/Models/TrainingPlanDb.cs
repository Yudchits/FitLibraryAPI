using System.Collections.Generic;

namespace FitLibrary.DataAccess.Common.Models
{
    public class TrainingPlanDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Sport { get; set; }
        //public int CreatorId { get; set; }
        //public virtual UserDb Creator { get; set; }
        public decimal Price { get; set; }
        public decimal? Rating { get; set; }
        public virtual ICollection<ExerciseDb> Exercises { get; set; }
    }
}
