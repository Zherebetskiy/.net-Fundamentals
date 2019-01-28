using Blog.Abstractions.Models;
using Blog.BusinessLogic.Interfaces;
using Blog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.BusinessLogic.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICollection<Topic> topics;

        public TopicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            topics = this.unitOfWork.Set<Topic>().Get();
        }

        public Topic GetTopicByName(string name)
        {
            return topics.FirstOrDefault(topic => topic.Name == name);
        }

        public ICollection<Topic> OrderByArticle()
        {
            return (ICollection <Topic>)topics.OrderByDescending(topic => topic.Articles);
        }
    }
}
