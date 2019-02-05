using Blog.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.BusinessLogic.Interfaces
{
    public interface IArticleService
    {
        Task<ICollection<Article>> GetMostRatedArticlesAsync();
        Task<ICollection<Article>> GetArticlesByTagAsync(string tag);
        Task<ICollection<Article>> GetArticlesByTitleAsync(string title);
        void UpdateArticle(int id, Article article);
        void Create(Article article);
    }
}
