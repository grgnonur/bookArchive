using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookArchive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        Context context = new Context();
        [HttpGet]
        public List<Book> Get()
        {
            var list = context.Books.Include(x => x.Category).ToList();
            return list;
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            var book = context.Books.Find(id);
            return book;
        }
        [HttpPost]
        public Book Post([FromBody] Book book)
        {
            var temp = context.Categories.Where(x => x.id == book.Category.id).FirstOrDefault();
            book.Category = temp;
            context.Books.Add(book);
            context.SaveChanges();
            return book;
            
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Books.Find(id);
        }

        [HttpPut]
        public Book Put([FromBody]Book book)
        {
            var temp = context.Books.Find(book.id);
            temp.bookName = book.bookName;
            temp.author = book.author;
            var temp2 = context.Categories.Where(x => x.id == book.Category.id).FirstOrDefault();
            temp.Category.id = temp2.id;
            temp.description = book.description;
            context.SaveChanges();
            return book;
        }

    }
}
