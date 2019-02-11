using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetBlog.Abstractions.Interfaces;
using DotNetBlog.Abstractions.Models;
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
    }
}
