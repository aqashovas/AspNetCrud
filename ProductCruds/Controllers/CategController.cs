using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductCruds.Models;

namespace ProductCruds.Controllers
{
    public class CategController : Controller
    {
        private readonly ProductContext _context = new ProductContext();

        // GET: Categ
        public ActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (_context.Categories.Any(b => b.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Eyni adda kateqoriya mövcuddur");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return Redirect("index");
            }

            return View(category);
        }

        public ActionResult Edit(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (_context.Categories.Any(b => b.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Eyni adda kateqoriya mövcuddur");
            }
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}