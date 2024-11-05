using System.Collections.Generic;

namespace FitLibrary.DataAccess.Common.Models
{
    public class UserDb
    {
        public string Name { get; set; }
        public ICollection<TrainingPlanDb> TrainingPlans { get; set; }
    }
}
