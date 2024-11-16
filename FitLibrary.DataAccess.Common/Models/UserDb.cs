using System;
using System.Collections.Generic;

namespace FitLibrary.DataAccess.Common.Models
{
    public class UserDb
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RoleDb> Roles { get; set; }
        public virtual ICollection<TrainingPlanDb> TrainingPlans { get; set; }
    }
}