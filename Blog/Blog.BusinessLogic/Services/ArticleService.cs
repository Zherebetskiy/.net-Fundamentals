using Blog.Abstractions.Models;
using Blog.BusinessLogic.Interfaces;
using Blog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public Article GetArticleByTitle(string title)
        {
            return articles.Where(article => article.Title == title).FirstOrDefault();
        }

        public ICollection<Article> GetArticleByTag(string tag)
        {
            return (ICollection<Article>)articles.Where(article => !string.IsNullOrEmpty(article.Tags.FirstOrDefault(t => t == tag)));
        }

        public ICollection<Article> GetMostRatedArticle()
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
