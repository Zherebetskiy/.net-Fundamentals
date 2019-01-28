using Blog.Abstractions.Models;
using System.Collections.Generic;

namespace Blog.BusinessLogic.Interfaces
{
    public interface IArticleService
    {
        ICollection<Article> GetMostRatedArticles();
        ICollection<Article> GetArticlesByTag(string tag);
        ICollection<Article> GetArticlesByTitle(string title);
        void UpdateArticle(int id, Article article);
        void Create(Article article);
    }
}
