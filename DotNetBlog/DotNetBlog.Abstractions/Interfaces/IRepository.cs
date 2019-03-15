using DotNetBlog.Abstractions.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetBlog.Abstractions.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> FindAsync(Specification<T> specification);

        Task<ICollection<T>> GetAsync();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
