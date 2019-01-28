using Blog.Abstractions.Models;
using System;
using System.Linq.Expressions;

namespace Blog.Abstractions.Specifications
{
    public class GetArticleSpecification : Specification<Article>
    {
        private readonly string title;

        public GetArticleSpecification(string title)
        {
            this.title = title;
        }
        public override Expression<Func<Article, bool>> ToExpression()
        {
            return article => article.Title == title;
        }
    }
}
