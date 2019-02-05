using Blog.Abstractions.Models;
using Blog.BusinessLogic.Interfaces;
using Blog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Abstractions.Specifications;

namespace Blog.BusinessLogic.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;           
        }

        public void Create(Article article)
        {
            unitOfWork.Set<Article>().Create(article);
        }

        public ICollection<Article> GetArticlesByTitle(string title)
        {
            var articleSpecification = new GetArticleSpecification(title);
            var article = unitOfWork.Set<Article>().FindAsync(articleSpecification);

            return (ICollection<Article>)article;
        }

        public async Task<ICollection<Article>> GetArticlesByTag(string tag)
        {
            var articles = await unitOfWork.Set<Article>().GetAsync();
            return (ICollection<Article>)articles.Where(article => !string.IsNullOrEmpty(article.Tags.FirstOrDefault(t => t == tag)));
        }

        public async Task<ICollection<Article>> GetMostRatedArticles()
        {
            var articles = await unitOfWork.Set<Article>().GetAsync();
            return (ICollection<Article>)articles.OrderByDescending(article => article.Likes).Take(10);    
        }

        public void UpdateArticle(int id, Article article)
        {
            unitOfWork.Set<Article>().Update(article);
            unitOfWork.SaveChanges();
        }
    }
}
