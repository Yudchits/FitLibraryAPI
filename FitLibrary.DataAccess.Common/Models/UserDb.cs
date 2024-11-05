using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FitLibrary.DataAccess.Common.Models
{
    public class UserDb : IdentityUser
    {
        public ICollection<TrainingPlanDb> TrainingPlans { get; set; }
    }
}
