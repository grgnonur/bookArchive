using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookArchive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bookArchive.Controllers
{
    public class BookCnt : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var deger = context.Books.Include(x => x.Category).ToList(); //Kitapları listelerken kategori isminide getirmek için include kullanıldı.
            return View(deger);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> degerler = (from x in context.Categories.ToList()  //dropdownlist ile kategorideki dataları LinQ ile çekme işlemi.
                                             select new SelectListItem
                                             {
                                                 Text = x.categoryName,
                                                 Value = x.id.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b)
        {
            var temp = context.Categories.Where(x => x.id == b.Category.id).FirstOrDefault();
            b.Category = temp;
            context.Books.Add(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var yakala = context.Books.Find(id);
            context.Remove(yakala);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult GetBook()
        {
            List<SelectListItem> list = (from x in context.Categories.ToList() 
                                             select new SelectListItem
                                             {
                                                 Text = x.categoryName,
                                                 Value = x.id.ToString()

                                             }).ToList();
            ViewBag.dgr = list;
            return View();
        }
        [HttpPost]
        public IActionResult GetBook(int id)
        {
            //var degerler = context.Books.Where(x => x.id == id).ToList();
            var degerler = context.Books.Find(id);
            return View("GetBook", degerler);
        }

        public IActionResult Update(Book b)
        {
            var temp = context.Books.Find(b.id);
            temp.bookName = b.bookName;
            temp.author = b.author;
            //temp.Category.categoryName = b.Category.categoryName;
            var temp2 = context.Categories.Where(x => x.id == b.Category.id).FirstOrDefault();
            temp.Category.id = temp2.id;
            temp.description = b.description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
