using System.Diagnostics;
using BSLibrary.Database;
using BSLibrary.Models;
using Microsoft.AspNetCore.Mvc;


namespace BSLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly MemoryDatabase _db;

        public HomeController(MemoryDatabase db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to our BS Library Mangement";
            var books = _db.Get();
            return View(books);
        }
        public ActionResult Details(int id)
        {
            var book = _db.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _db.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingbook = _db.Get(book.Id);
                if (existingbook == null)
                {
                    return NotFound();
                }

                _db.Update(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Delete(int id)
        {
            var book = _db.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(book);
            }
            return RedirectToAction("Index");
        }
    }
}
