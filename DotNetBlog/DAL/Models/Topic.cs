using System.Collections.Generic;

namespace DAL.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
