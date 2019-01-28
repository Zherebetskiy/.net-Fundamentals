using System.Collections.Generic;

namespace Blog.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        ICollection<T> Get();

        void Create(T entity);

        void Update(int id, T entity);

        void Delete(int id);
    }
}
