using Microsoft.AspNetCore.Http;

namespace FitLibrary.Logic.Common.Models
{
    public class PhotoBLL
    {
        public IFormFile Photo { get; set; }
        public int FrameTop { get; set; }
        public int FrameLeft { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int PhotoWidth { get; set; }
        public int PhotoHeight { get; set; }
    }
}