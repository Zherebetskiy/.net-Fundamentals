using System.Collections.Generic;
using System.Threading.Tasks;

using DotNetBlog.Abstractions.Models;

namespace DotNetBlog.BusinessLogic.Interfaces
{
    public interface IArticleService
    {
        Task<ICollection<Article>> GetAsync();
        Task<ICollection<Article>> GetMostRatedArticlesAsync();
        Task<ICollection<Article>> GetNewestArticlesAsync();
        Task<ICollection<Article>> GetArticlesByTagAsync(string tag);
        Task<ICollection<Article>> GetArticlesByTitleAsync(string title);
        Task<Article> GetArticleByIdAsync(int? id);
        Task UpdateAsync(Article article);
        Task CreateAsync(Article article);
        Task DeleteAsync(Article article);
    }
}
