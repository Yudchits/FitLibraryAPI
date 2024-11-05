using System;

namespace FitLibrary.DataAccess.Common.Models
{
    public class PostDb
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}