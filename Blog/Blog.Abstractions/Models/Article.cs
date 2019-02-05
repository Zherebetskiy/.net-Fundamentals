using System.Collections.Generic;

namespace Blog.Abstractions.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<string> Tags { get; set; }        
        public int Likes { get; set; }

        public virtual User Owner { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
