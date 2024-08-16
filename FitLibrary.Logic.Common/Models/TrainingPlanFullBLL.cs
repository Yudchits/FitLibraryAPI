using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitLibrary.Logic.Common.Models
{
    public class TrainingPlanFullBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sport { get; set; }
        public UserBLL Creator { get; set; }
    }
}
