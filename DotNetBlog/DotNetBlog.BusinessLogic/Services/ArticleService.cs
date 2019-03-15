using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DotNetBlog.Abstractions.Specifications;
using DotNetBlog.Abstractions.Models;
using DotNetBlog.BusinessLogic.Interfaces;
using DotNetBlog.Abstractions.Interfaces;

namespace DotNetBlog.BusinessLogic.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Article article)
        {
            unitOfWork.Set<Article>().Create(article);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<Article>> GetArticlesByTitleAsync(string title)
        {
            var articleSpecification = new GetArticleByTitleSpecification(title);
            var article = unitOfWork.Set<Article>().FindAsync(articleSpecification);

            return (ICollection<Article>)article;
        }

        public async Task<ICollection<Article>> GetArticlesByTagAsync(string tag)
        {
            var articles = await unitOfWork.Set<Article>().GetAsync();
            return (ICollection<Article>)articles.Where(article => article.Tags.Contains(tag));
        }

        public async Task<ICollection<Article>> GetMostRatedArticlesAsync()
        {
            var articles = await unitOfWork.Set<Article>().GetAsync();
            var t = (ICollection<Article>)articles.OrderByDescending(article => article.Likes).Take(3).ToList();

            return t;
        }

        public async Task UpdateAsync(Article article)
        {
            unitOfWork.Set<Article>().Update(article);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<Article>> GetNewestArticlesAsync()
        {
            var articles = await unitOfWork.Set<Article>().GetAsync();
            return (ICollection<Article>)articles.OrderByDescending(article => article.CreationDate).Take(3).ToList();
        }

        public async Task<ICollection<Article>> GetAsync()
        {
            return await unitOfWork.Set<Article>().GetAsync();
        }
   
        public async Task DeleteAsync(Article article)
        {
            unitOfWork.Set<Article>().Delete(article);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int? id)
        {
            var articleSpecification = new GetArticleByIdSpecification(id);
            var article = unitOfWork.Set<Article>().FindAsync(articleSpecification);

            return article.FirstOrDefault();
        }
    }
}
