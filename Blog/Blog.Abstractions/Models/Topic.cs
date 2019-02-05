using System.Collections.Generic;

namespace Blog.Abstractions.Models
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
