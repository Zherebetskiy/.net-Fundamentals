using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetBlog.Abstractions.Interfaces;
using DotNetBlog.Abstractions.Models;
using DotNetBlog.Abstractions.Specifications;
using DotNetBlog.BusinessLogic.Interfaces;

namespace DotNetBlog.BusinessLogic.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork unitOfWork;

        public TopicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;           
        }

        public async Task CreateAsync(Topic topic)
        {
            unitOfWork.Set<Topic>().Create(topic);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Topic topic)
        {
            unitOfWork.Set<Topic>().Delete(topic);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<Topic> GetTopicByIdAsync(int? id)
        {
            var topicSpecification = new GetTopicByIdSpecification(id);
            var topic = unitOfWork.Set<Topic>().FindAsync(topicSpecification);

            return topic.FirstOrDefault();
        }

        public async Task<ICollection<Topic>> GetTopicsAsync()
        {
            return await unitOfWork.Set<Topic>().GetAsync();
        }

        public async Task<ICollection<Topic>> GetTopicsByNameAsync(string name)
        {
            var topics = await unitOfWork.Set<Topic>().GetAsync();
            return (ICollection<Topic>)topics.Where(t=> t.Name == name);
        }

        public async Task<ICollection<Topic>> OrderByArticleAsync()
        {
            var topics = await unitOfWork.Set<Topic>().GetAsync();
            return (ICollection<Topic>)topics.OrderByDescending(topic => topic.Articles);
        }

        public async Task UpdateAsync(Topic topic)
        {
            unitOfWork.Set<Topic>().Update(topic);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
