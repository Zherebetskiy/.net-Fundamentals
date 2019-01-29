using System.Collections.Generic;

namespace Blog.Abstractions.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
