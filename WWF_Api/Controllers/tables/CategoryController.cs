using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WWF_Api.Controllers.tables
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        private readonly WWFContext _context;

        public CategoryController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Category.ToList().OrderBy(t => t.CatId);
        }

        [HttpGet("{id}")]
        public IActionResult GetCat(int id)
        {
            Category cat = _context.Category
                .FirstOrDefault(x => x.CatId == id);
            if (cat == null)
                return NotFound();
            return new ObjectResult(cat);
        }

        [HttpPost]
        public IActionResult PostCat([FromBody]Category cat)
        {
            if (cat == null)
            {
                return BadRequest();
            }

            _context.Category.Add(cat);
            _context.SaveChanges();
            return Ok(cat);
        }

        [HttpPut]
        public IActionResult PutCat([FromBody]Category cat)
        {
            if (cat == null)
            {
                return BadRequest();
            }
            if (!_context.Category.Any(x => x.CatId == cat.CatId))
            {
                return NotFound();
            }

            _context.Update(cat);
            _context.SaveChanges();
            return Ok(cat);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCat(int id)
        {
            Category cat = _context.Category
                .FirstOrDefault(x => x.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }
            _context.Category.Remove(cat);
            _context.SaveChanges();
            return Ok(cat);
        }
    }
}