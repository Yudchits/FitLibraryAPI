namespace FitLibrary.Logic.Common.Models
{
    public class TrainingPlanShortBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Sport { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public int CreatorId { get; set; }
    }
}
