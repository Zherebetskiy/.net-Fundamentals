using DotNetBlog.Abstractions.Models;
using DotNetBlog.Abstractions.Interfaces;
using System.Threading.Tasks;

namespace DotNetBlog.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BlogContext context;

        public UnitOfWork(BlogContext context)
        {
            this.context = context;
        }

        public IRepository<T> Set<T>() where T : BaseEntity
        {
            return new Repository<T>(context);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
