using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWF_Api;
using WWF_Api.Models;


namespace WWF_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/animal")]
    public class AnimalController : Controller
    {
        private readonly WWFContext _context;
        public AnimalController(WWFContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Animal> GetAnimal()
        {
            return _context.Animal.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            Animal am = _context.Animal.FirstOrDefault(x => x.AnimalId == id);
            if (am == null)
                return NotFound();
            return new ObjectResult(am);
        }

        [HttpPost]
        public IActionResult PostAnimal([FromBody]Animal animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }

            _context.Animal.Add(animal);
            _context.SaveChanges();
            return Ok(animal);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Animal animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }
            if (!_context.Animal.Any(x => x.AnimalId == animal.AnimalId))
            {
                return NotFound();
            }

            _context.Update(animal);
            _context.SaveChanges();
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Animal animal = _context.Animal.FirstOrDefault(x => x.AnimalId == id);
            if (animal == null)
            {
                return NotFound();
            }
            _context.Animal.Remove(animal);
            _context.SaveChanges();
            return Ok(animal);
        }
    }
}
