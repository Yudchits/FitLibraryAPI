using System.Collections.Generic;

namespace FitLibrary.DataAccess.Common.Models
{
    public class RoleDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserDb> Users { get; set; }
    }
}