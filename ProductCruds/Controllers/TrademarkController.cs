using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductCruds.Models;

namespace ProductCruds.Controllers
{
    public class TrademarkController : Controller
    {
        private readonly ProductContext _context = new ProductContext();
        // GET: Trademark
        public ActionResult Index()
        {
            List<Brand> brands = _context.Brands.ToList();
            return View(brands);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (_context.Brands.Any(b => b.Name == brand.Name))
            {
                ModelState.AddModelError("Name", "Eyni adda marka mövcuddur");
            }
            if (ModelState.IsValid)
            {
                _context.Brands.Add(brand);
                _context.SaveChanges();
                return Redirect("index");
            }

            return View(brand);
        }

        public ActionResult Edit(int id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }

            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            if (_context.Brands.Any(b => b.Name == brand.Name))
            {
                ModelState.AddModelError("Name", "Eyni adda marka mövcuddur");
            }
            if (ModelState.IsValid)
            {
                _context.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            return View(brand);
        }

        public ActionResult Delete(int id)
        {
            Brand brand = _context.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}