using System.Collections.Generic;

namespace FitLibrary.Logic.Common.Models
{
    public class TrainingPlanFullBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public int CreatorId { get; set; }
        public UserBLL Creator { get; set; }
        public ICollection<ExerciseBLL> Exercises { get; set; }
    }
}