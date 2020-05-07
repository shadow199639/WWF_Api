using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WWF_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/AnimalOnContinents")]
    public class AnimalOnContinentsController : Controller
    {
        private readonly WWFContext _context;

        public AnimalOnContinentsController(WWFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Animalonconttinents> Get()
        {
            return _context.Animalonconttinents.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            Animalonconttinents aoc = _context.Animalonconttinents
                .FirstOrDefault(x => x.AocId == id);
            if (aoc == null)
                return NotFound();
            return new ObjectResult(aoc);
        }

        [HttpPost]
        public IActionResult PostAnimal([FromBody]Animalonconttinents aoc)
        {
            if (aoc == null)
            {
                return BadRequest();
            }

            _context.Animalonconttinents.Add(aoc);
            _context.SaveChanges();
            return Ok(aoc);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Animalonconttinents aoc)
        {
            if (aoc == null)
            {
                return BadRequest();
            }
            if (!_context.Animalonconttinents.Any(x => x.AocId == aoc.AocId))
            {
                return NotFound();
            }

            _context.Update(aoc);
            _context.SaveChanges();
            return Ok(aoc);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Animalonconttinents aoc = _context.Animalonconttinents
                .FirstOrDefault(x => x.AocId == id);
            if (aoc == null)
            {
                return NotFound();
            }
            _context.Animalonconttinents.Remove(aoc);
            _context.SaveChanges();
            return Ok(aoc);
        }
    }
}