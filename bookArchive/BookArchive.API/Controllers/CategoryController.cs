using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookArchive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context = new Context();
        [HttpGet]
        public List<Category> Get()
        {
            var degerler = context.Categories.ToList();
            return degerler;
        }
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var cat =context.Categories.Find(id);
            return cat;
        }

        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }
        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            var cat = context.Categories.Find(category.id);
            cat.categoryName = category.categoryName;
            context.SaveChanges();
            return category;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            context.Categories.Find(id);
        }
    }
}
