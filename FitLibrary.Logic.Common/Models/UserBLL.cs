using FitLibrary.DataAccess.Common.Models;
using System;
using System.Collections.Generic;

namespace FitLibrary.Logic.Common.Models
{
    public class UserBLL
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RoleBLL> Roles { get; set; }
    }
}