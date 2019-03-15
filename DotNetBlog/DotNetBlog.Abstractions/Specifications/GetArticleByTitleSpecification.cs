using DotNetBlog.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DotNetBlog.Abstractions.Specifications
{
    public class GetArticleByTitleSpecification : Specification<Article>
    {
        private readonly string title;

        public GetArticleByTitleSpecification(string title)
        {
            this.title = title;
        }
        public override Expression<Func<Article, bool>> ToExpression()
        {
            return article => article.Title == title;
        }
    }
}
