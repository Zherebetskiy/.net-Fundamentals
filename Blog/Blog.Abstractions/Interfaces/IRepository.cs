using Blog.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IQueryable<T>> FindAsync(Specification<T> specification);

        Task<ICollection<T>> GetAsync();

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        Task SaveChangesAsync();
    }
}
