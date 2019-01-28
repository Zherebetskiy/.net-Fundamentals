using Blog.Abstractions.Models;
using System.Collections.Generic;

namespace Blog.BusinessLogic.Interfaces
{
    public interface IArticleService
    {
        ICollection<Article> GetMostRatedArticle();
        ICollection<Article> GetArticleByTag(string tag);
        Article GetArticleByTitle(string title);
        void UpdateArticle(int id, Article article);
        void Create(Article article);
    }
}
