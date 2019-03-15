using DotNetBlog.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DotNetBlog.Abstractions.Specifications
{
    public class GetTopicByIdSpecification : Specification<Topic>
    {
        private readonly int? id;

        public GetTopicByIdSpecification(int? id)
        {
            this.id = id;
        }
        public override Expression<Func<Topic, bool>> ToExpression()
        {
            return topic => topic.Id == id;
        }
    }
}
