﻿using DotNetBlog.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetBlog.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Topic)
                .WithMany(t => t.Articles)
                .OnDelete(DeleteBehavior.Cascade);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=NB00LEB106\SQLEXPRESS;Database=BlogDB;Trusted_Connection=True;");
        //}
    }
}
