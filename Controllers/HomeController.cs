using System.Diagnostics;
using BSLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "First Task", Description = "This is the first task" },
            new TaskItem { Id = 2, Title = "Second Task", Description = "This is the second task" }
        };

        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to our Website";
            return View(_tasks);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem task)
        {
            if (ModelState.IsValid)
            {
                task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
                _tasks.Add(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }
        
        public IActionResult Edit(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( TaskItem task)
        {
            if (ModelState.IsValid)
            {
                var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
                if (existingTask == null)
                {
                    return NotFound();
                }
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;

                return RedirectToAction("Index");
            }
            return View(task);
        }
        
        public IActionResult Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }else
            {
                _tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }
    }
}
