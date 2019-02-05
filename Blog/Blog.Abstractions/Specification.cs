using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Blog.Abstractions.Models;

namespace Blog.Abstractions
{
    public abstract class Specification<T> : ISpecification<T> where T : BaseEntity 
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public Task<bool> IsSatisfiedByAsync(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();

            return Task.FromResult(predicate(entity));
        }
    }
}
