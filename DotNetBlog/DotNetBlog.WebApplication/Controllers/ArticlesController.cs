using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetBlog.Abstractions.Models;
using DotNetBlog.DAL;
using DotNetBlog.BusinessLogic.Interfaces;
using Serilog;

namespace DotNetBlog.WebApplication.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ITopicService topicService;

        public ArticlesController(IArticleService articleService, ITopicService topicService)
        {
            this.articleService = articleService;
            this.topicService = topicService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            return View(await articleService.GetAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articles = await articleService.GetAsync();

            var article = articles.FirstOrDefault(m => m.Id == id);
            Log.Information("Article name {@article} retrieved", article.Title);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public async Task<IActionResult> Create()
        {
            var topics = await topicService.GetTopicsAsync();
            ViewData["TopicId"] = new SelectList(topics.ToList(), "Id", "Id");
            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,Tags,Likes,TopicId,Id")] Article article)
        {
            var topics = await topicService.GetTopicsAsync();

            if (ModelState.IsValid)
            {
                await articleService.CreateAsync(article);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicId"] = new SelectList(topics.ToList(), "Id", "Id", article.TopicId);
            return View(article);
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var topics = await topicService.GetTopicsAsync();
            if (id == null)
            {
                return NotFound();
            }

            var article = await articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(topics.ToList(), "Id", "Id", article.TopicId);
            return View(article);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Content,Tags,Likes,TopicId,Id")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await articleService.UpdateAsync(article);                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var topics = await topicService.GetTopicsAsync();
            ViewData["TopicId"] = new SelectList(topics.ToList(), "Id", "Id", article.TopicId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await articleService.GetArticleByIdAsync(id);
            await articleService.DeleteAsync(article);
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            var articles = articleService.GetAsync().GetAwaiter().GetResult().ToList();
            return articles.Any(e => e.Id == id);
        }
    }
}
