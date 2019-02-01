using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductCruds.Models;
using System.IO;

namespace ProductCruds.Controllers
{
    public class OffMakeController : Controller
    {
        private readonly ProductContext _context = new ProductContext();

        // GET: OffMake
        public ActionResult Index()
        {
            List<Product> products = _context.Products.Include("brand").Include("category").ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Photo)
        {
            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
            string path = Path.Combine(Server.MapPath("~/Uploads"), filename);

            Photo.SaveAs(path);

            product.Photo = filename;
            //if (ModelState.IsValid)
            //{
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("index");

            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(product);

            //}




            //return View(product);


        }

        public ActionResult Edit(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase Photo)
        {
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;

            if (Photo == null)
            {
                _context.Entry(product).Property(m => m.Photo).IsModified = false;
            }
            else
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);

                Photo.SaveAs(path);

                product.Photo = filename;
            }
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            System.IO.File.Delete(Path.Combine(Server.MapPath("~/Uploads"), product.Photo));

            _context.Products.Remove(product);
            _context.SaveChanges();

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Brands = _context.Brands.ToList();
            return RedirectToAction("index");
        }
    }
}