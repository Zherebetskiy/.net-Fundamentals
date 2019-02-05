﻿using Blog.Abstractions.Models;
using Blog.DAL.Interfaces;

namespace Blog.DAL
{
    class UnitOfWork : IUnitOfWork
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

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
