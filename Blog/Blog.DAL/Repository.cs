using Blog.Abstractions;
using Blog.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly BlogContext context;

        public Repository(BlogContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
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

        public virtual void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public Task<IQueryable<T>> FindAsync(ISpecification<T> specification)
        {          
            return context.Set<T>().Where(async (item) => await specification.IsSatisfiedByAsync(item));//????
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
