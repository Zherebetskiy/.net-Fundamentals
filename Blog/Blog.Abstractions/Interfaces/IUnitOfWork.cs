namespace Blog.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<T> Set<T>() where T : class;

        int SaveChanges();
    }
}
