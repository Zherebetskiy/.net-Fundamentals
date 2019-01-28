using Blog.Abstractions;
using Blog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Blog.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly BlogContext context;

        public Repository(BlogContext context)
        {
            this.context = context;
        }

        public virtual ICollection<T> Get()
        {
            return (ICollection<T>)context.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(int id)
        {
            var contextSet = context.Set<T>();
            contextSet.Remove(contextSet.Find(id));
        }

        public virtual void Update(int id, T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T Find(Specification<T> specification)
        {          
                return context.Set<T>()
                    .Where(specification.ToExpression())
                    .ToList().FirstOrDefault();           
        }
    }
}
