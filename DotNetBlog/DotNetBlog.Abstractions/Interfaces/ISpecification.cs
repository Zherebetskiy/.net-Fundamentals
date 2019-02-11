using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using DotNetBlog.Abstractions.Models;

namespace DotNetBlog.Abstractions.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity 
    {
        Expression<Func<T, bool>> ToExpression();

        Task<bool> IsSatisfiedByAsync(T entity);
    }
}
