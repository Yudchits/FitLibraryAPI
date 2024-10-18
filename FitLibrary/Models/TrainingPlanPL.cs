using FitLibrary.Logic.Common.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FitLibrary.Models
{
    public class TrainingPlanPL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string Sport { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int CreatorId { get; set; }
        public ICollection<ExerciseBLL> Exercises { get; set; }
    }
}