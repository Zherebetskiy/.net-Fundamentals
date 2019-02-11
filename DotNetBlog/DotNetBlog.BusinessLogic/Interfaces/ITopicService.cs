using DotNetBlog.Abstractions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetBlog.BusinessLogic.Interfaces
{
    public interface ITopicService
    {
        Task<ICollection<Topic>> GetTopicsAsync();
        Task<ICollection<Topic>> OrderByArticleAsync();
        Task<ICollection<Topic>> GetTopicsByNameAsync(string name);
    }
}
