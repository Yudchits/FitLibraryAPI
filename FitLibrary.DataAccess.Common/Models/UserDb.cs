using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitLibrary.DataAccess.Common.Models
{
    public class UserDb
    {
        public virtual ICollection<TrainingPlanDb> TrainingPlans { get; set; }
    }
}
