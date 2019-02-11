using DotNetBlog.Abstractions.Models;
using System.Collections.Generic;

namespace DotNetBlog.Abstractions.ViewModels
{
    public class HomeViewModel
    {
        public ICollection<Article> MostRatedArticles { get; set; }
        public ICollection<Article> NewestArticles { get; set; }
    }
}
