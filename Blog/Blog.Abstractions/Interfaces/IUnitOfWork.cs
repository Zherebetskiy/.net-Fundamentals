using Blog.Abstractions.Models;

namespace Blog.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Set<T>() where T : BaseEntity;

        int SaveChanges();
    }
}
