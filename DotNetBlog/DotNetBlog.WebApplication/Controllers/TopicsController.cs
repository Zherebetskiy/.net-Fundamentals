using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetBlog.Abstractions.Models;
using DotNetBlog.BusinessLogic.Interfaces;

namespace DotNetBlog.WebApplication.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ITopicService topicService;

        public TopicsController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        // GET: Topics
        public async Task<IActionResult> Index()
        {
            return View(await topicService.GetTopicsAsync());
        }

        //GET: Topics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topics = await topicService.GetTopicsAsync();

            var topic = topics.FirstOrDefault(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                await topicService.CreateAsync(topic);
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }

        //GET: Topics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await topicService.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return View(topic);
        }

        // POST: Topics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Id")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await topicService.UpdateAsync(topic);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            return View(topic);
        }

        // GET: Topics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await topicService.GetTopicByIdAsync(id);
            await topicService.DeleteAsync(topic);

            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await topicService.GetTopicByIdAsync(id);
            await topicService.DeleteAsync(topic);
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            var topics = topicService.GetTopicsAsync().GetAwaiter().GetResult().ToList();
            return topics.Any(e => e.Id == id);
        }
    }
}
