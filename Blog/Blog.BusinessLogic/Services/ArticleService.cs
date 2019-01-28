using Blog.Abstractions.Models;
using Blog.BusinessLogic.Interfaces;
using Blog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Blog.Abstractions.Specifications;

namespace Blog.BusinessLogic.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICollection<Article> articles;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            articles = this.unitOfWork.Set<Article>().Get();
        }

        public void Create(Article article)
        {
            unitOfWork.Set<Article>().Create(article);
        }

        public ICollection<Article> GetArticlesByTitle(string title)
        {
            var articleSpecification = new GetArticleSpecification(title);
            var article = unitOfWork.Set<Article>().Find(articleSpecification);

            return (ICollection<Article>)article;
        }

        public ICollection<Article> GetArticlesByTag(string tag)
        {
            return (ICollection<Article>)articles.Where(article => !string.IsNullOrEmpty(article.Tags.FirstOrDefault(t => t == tag)));
        }

        public ICollection<Article> GetMostRatedArticles()
        {
            return (ICollection<Article>)articles.OrderByDescending(article => article.Likes).Take(10);    
        }

        public void UpdateArticle(int id, Article article)
        {
            unitOfWork.Set<Article>().Update(id, article);
            unitOfWork.SaveChanges();
        }
    }
}
