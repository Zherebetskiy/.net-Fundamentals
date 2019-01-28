﻿using Blog.Abstractions;
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

        public IReadOnlyList<T> Find(Specification<T> specification)
        {          
            var res = new List<T>();

            foreach (var item in context.Set<T>())
            {
                if (specification.IsSatisfiedBy(item))
                {
                    res.Add(item);
                }            
            }

            return res;
        }
    }
}