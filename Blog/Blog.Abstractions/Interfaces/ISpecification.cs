using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Abstractions.Models;

namespace Blog.Abstractions
{
    public interface ISpecification<T> where T : BaseEntity 
    {
        Expression<Func<T, bool>> ToExpression();

        Task<bool> IsSatisfiedByAsync(T entity);
    }
}
