using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookArchive.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookArchive.Controllers
{
    public class CategoryController1 : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var degerler = context.Categories.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Category x)
        {
            context.Categories.Add(x);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var yakala = context.Categories.Find(id);
            context.Categories.Remove(yakala);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetCategory(int id)
        {
            var yakala = context.Categories.Find(id);

            return View("GetCategory", yakala);
        }

        public IActionResult Update(Category x)
        {
            var cat = context.Categories.Find(x.id);
            cat.categoryName = x.categoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
