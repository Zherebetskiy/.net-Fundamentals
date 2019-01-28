using System.Collections.Generic;

namespace Blog.Abstractions.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<string> Tags { get; set; }
        public User Owner { get; set; }
        public int Likes { get; set; }
    }
}
