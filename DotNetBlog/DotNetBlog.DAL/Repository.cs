using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DotNetBlog.Abstractions.Interfaces;
using DotNetBlog.Abstractions;
using DotNetBlog.Abstractions.Models;

namespace DotNetBlog.DAL
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

        public virtual void Delete(T entity)
        {
            var contextSet = context.Set<T>();
            contextSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<IQueryable<T>> FindAsync(Specification<T> specification)
        {
           // return context.Set<T>().Where(async (item) => await specification.IsSatisfiedByAsync(item));//????
            throw new System.NotImplementedException();
        }
    }
}
