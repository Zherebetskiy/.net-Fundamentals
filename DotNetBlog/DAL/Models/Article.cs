using System.Collections.Generic;

namespace DAL.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}
