using Microsoft.AspNetCore.Http;

namespace FitLibrary.Logic.Common.Models
{
    public class PhotoBLL
    {
        public IFormFile Photo { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}