﻿using System;
using System.Linq.Expressions;

namespace Blog.Abstractions
{
    public abstract class Specification<T> where T : class 
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression().Compile();

            return predicate(entity);
        }
    }
}