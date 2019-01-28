using Blog.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace Blog.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IReadOnlyList<T> Find(Specification<T> specification);

        ICollection<T> Get();

        void Create(T entity);

        void Update(int id, T entity);

        void Delete(int id);
    }
}
