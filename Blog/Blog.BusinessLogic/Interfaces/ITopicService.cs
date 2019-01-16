using Blog.DAL.Models;
using System.Collections.Generic;

namespace Blog.BusinessLogic.Interfaces
{
    public interface ITopicService
    {
        ICollection<Topic> OrderByArticle();
        Topic GetTopicByName(string name);

    }
}
