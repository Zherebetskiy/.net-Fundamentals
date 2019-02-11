using DotNetBlog.Abstractions.Models;
using System.Threading.Tasks;

namespace DotNetBlog.Abstractions.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Set<T>() where T : BaseEntity;

        Task SaveChangesAsync();
    }
}
