using System;
using System.Collections.Generic;

namespace DotNetBlog.Abstractions.Models
{
    public class Article : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }        
        public int Likes { get; set; }
        public DateTime CreationDate { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
