using DotNetBlog.Abstractions.Models;
using System;
using System.Linq.Expressions;

namespace DotNetBlog.Abstractions.Specifications
{
    public class GetArticleByIdSpecification : Specification<Article>
    {
        private readonly int? id;

        public GetArticleByIdSpecification(int? id)
        {
            this.id = id;
        }
        public override Expression<Func<Article, bool>> ToExpression()
        {
            return article => article.Id == id;
        }
    }
}
